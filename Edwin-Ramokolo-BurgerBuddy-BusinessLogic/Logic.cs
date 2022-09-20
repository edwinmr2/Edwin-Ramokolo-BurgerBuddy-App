using Edwin_Ramokolo_BurgerBuddy_Common;
using Edwin_Ramokolo_BurgerBuddy_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_BurgerBuddy_BusinessLogic
{
    public class Logic
    {
        //Create Simulated Orders
        public bool SimulateOrders()
        {
            bool isSimulated = false;
            try
            {
                Simulator simulator = new Simulator();

                ObjOrder order = simulator.generateRandomOrder();

                List<ObjOrderItems> orderItems = new List<ObjOrderItems>();

                //Only Simmulating 2 OrderItems
                ObjOrderItems item1 = simulator.generateRandomOrderItems();
                orderItems.Add(item1);
                ObjOrderItems item2 = simulator.generateRandomOrderItems();
                orderItems.Add(item2);

                CreateOrder(order, orderItems);

                isSimulated = true;
            }
            catch (Exception ex)
            {

            }
            return isSimulated; 
        }

        public bool SimulateOrderCollection()
        {
            bool isUpdated = false;

            try
            {
                //get orders currently being prepared 
                List<ObjOrder> orders = GetPreparingOrders();

                //Check for orders that has been waiting 10 sec (10 minutes (BB time) = 10 seconds )
                foreach (ObjOrder objOrder in orders)
                {
                    if (objOrder.OrderDateTime <= DateTime.Now.AddSeconds(-10))
                        UpdateOrderQueue(objOrder.Id, 4); //4 = collected
                }

                isUpdated = true;
            }
            catch (Exception ex)
            {

            }
            return isUpdated;
        }

        //Create Order
        static readonly object _object = new object();
        public int CreateOrder(ObjOrder order, List<ObjOrderItems> orderItems)
        {
            int createdOrderId = -1;
            DataAccess dal = new DataAccess();

            try
            {
                //Check if Order is Smiley meal 
                bool hasToy = orderItems.Any(x => x.ProductId == 4);
                //if order is smiley then check we have created 50 orders today
                int numberOfSmileyMealsToday = GetNumberOfSmileyMealsToday();

                if (numberOfSmileyMealsToday > 50 && hasToy)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Message = string.Format("Order Failed to create. OrderSoureID = {0} because number Smiley Meals exceeded daily limit of 50.", order.PaymentSourceId);
                    errorMessage.Method = "CreateOrder";
                    errorMessage.Class = "DataAccess";
                    errorMessage.DateCreated = DateTime.Now;
                    dal.CreateErrorMessage(errorMessage);
                    return createdOrderId;
                }
                //Lock function to ensure that we complete one order so that we can create order numbers and avoid duplicates
                lock (_object)
                {
                    Order dbOrder = new Order();
                    dbOrder.OrderDateTime = DateTime.Now;
                    dbOrder.OrderStatusId = 2;
                    dbOrder.PaymentSourceId = order.PaymentSourceId;
                    createdOrderId = dal.CreateOrder(dbOrder);
                }

                if (createdOrderId <= 0)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Message = string.Format("Order Failed to create. OrderSoureID = {0}", order.PaymentSourceId);
                    errorMessage.Method = "CreateOrder";
                    errorMessage.Class = "DataAccess";
                    errorMessage.DateCreated = DateTime.Now;
                    dal.CreateErrorMessage(errorMessage);
                    return createdOrderId;
                }

                //Add Order Item
                OrderItem dbOrderItem = null;
                foreach (ObjOrderItems objOrderItem in orderItems)
                {
                    dbOrderItem = new OrderItem();
                    dbOrderItem.ProductId = objOrderItem.ProductId;
                    dbOrderItem.OrderId = createdOrderId;
                    dal.CreateOrderItems(dbOrderItem);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Message = ex.Message;
                errorMessage.Method = "CreateOrder";
                errorMessage.Class = "DataAccess";
                errorMessage.DateCreated = DateTime.Now;

                dal.CreateErrorMessage(errorMessage);
            }


            return createdOrderId;
        }

        public int GetNumberOfSmileyMealsToday()
        {
            return new DataAccess().GetNumberOfSmileyMealsToday();
        }
        //Update Order Queue status
        public bool UpdateOrderQueue(int orderId, int statusId)
        {
            bool isUpdated = false;

            try
            {
                isUpdated = new DataAccess().UpdateOrderQueue(orderId, statusId);

                if (!isUpdated)
                {
                    ErrorMessage errorMessage = new ErrorMessage();
                    errorMessage.Message = string.Format("Failed to update order [OrderId = {0}] with StatusID = {1}", orderId, statusId);
                    errorMessage.Method = "UpdateOrderQueue";
                    errorMessage.Class = "DataAccess";
                    errorMessage.DateCreated = DateTime.Now;

                    new DataAccess().CreateErrorMessage(errorMessage);
                }
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Message = ex.Message;
                errorMessage.Method = "UpdateOrderQueue";
                errorMessage.Class = "DataAccess";
                errorMessage.DateCreated = DateTime.Now;

                new DataAccess().CreateErrorMessage(errorMessage);
            }


            return isUpdated;
        }

        //Check if its oparating 
        public bool CheckStoreStatus()
        {
            bool isOpen = false;

            try
            {
                TimeSpan start = new TimeSpan(09, 0, 0); //09 o'clock
                TimeSpan end = new TimeSpan(17, 0, 0); //17 o'clock
                TimeSpan now = DateTime.Now.TimeOfDay;

                if ((now > start) && (now < end))
                    isOpen = true;
            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Message = ex.Message;
                errorMessage.Method = "UpdateOrderQueue";
                errorMessage.Class = "DataAccess";
                errorMessage.DateCreated = DateTime.Now;

                new DataAccess().CreateErrorMessage(errorMessage);
            }


            return isOpen;
        }

        public List<ObjOrder> GetPreparingOrders()
        {
            return GetOrdersByStatus(2);
        }

        public List<ObjOrder> GetReadyToCollectOrders()
        {
            return GetOrdersByStatus(3);
        }

        public List<ObjOrder> GetOrdersByStatus(int statusId)
        {
            List<ObjOrder> orders = new List<ObjOrder>();

            try
            {
                List<Order> dbOrders = new DataAccess().GetOrdersByStatus(statusId);

                ObjOrder order = null;
                foreach (Order item in dbOrders)
                {
                    order = new ObjOrder();

                    order.Id = item.Id;
                    order.OrderDateTime = item.OrderDateTime;
                    order.OrderNumber = item.OrderNumber;
                    order.PaymentSourceId = item.PaymentSourceId;
                    order.PaymentSource = new ObjPaymentSource();
                    order.PaymentSource.Id = item.PaymentSource.Id;
                    order.PaymentSource.Name = item.PaymentSource.Name;

                    order.OrderItems = new List<ObjOrderItems>();
                    ObjOrderItems objOrderItem = null;

                    foreach (OrderItem orderItem in item.OrderItems)
                    {
                        objOrderItem = new ObjOrderItems();
                        objOrderItem.Id = orderItem.Id;
                        objOrderItem.ProductId = orderItem.ProductId;

                        objOrderItem.Product = new ObjProducts();
                        objOrderItem.Product.Id = orderItem.Product.Id;
                        objOrderItem.Product.Name = orderItem.Product.Name;
                        order.OrderItems.Add(objOrderItem);
                    }
                    orders.Add(order);
                }

            }
            catch (Exception ex)
            {
                ErrorMessage errorMessage = new ErrorMessage();
                errorMessage.Message = ex.Message;
                errorMessage.Method = "CreateOrderQueue";
                errorMessage.Class = "DataAccess";
                errorMessage.DateCreated = DateTime.Now;
                new DataAccess().CreateErrorMessage(errorMessage);
            }
            return orders;

        }
    }
}