using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_BurgerBuddy_DataAccessLayer
{
    public class DataAccess
    {
        public int CreateOrder(Order dbOrder)
        {
            int orderId = -1;
            using (var db = new Entities())
            {
                //If Payment Source is MrD---> then get the last OrderNumber
                //If Order is from POINT of Sale get the latest Order that was created Today
                if (dbOrder.PaymentSourceId == 2)
                {
                    Order lastMrDOrder = db.Orders.Where(x => x.PaymentSourceId == 2).OrderByDescending(y => y.OrderDateTime).FirstOrDefault();
                    if (lastMrDOrder != null)
                        dbOrder.OrderNumber = lastMrDOrder.OrderNumber + 1;
                    else
                        dbOrder.OrderNumber = 10000;

                }
                else
                {
                    Order lastPOSOrder = db.Orders.Where(x => x.PaymentSourceId == 1 && x.OrderDateTime <= DateTime.Now).OrderByDescending(y => y.OrderDateTime).FirstOrDefault();
                    if (lastPOSOrder != null)
                        dbOrder.OrderNumber = lastPOSOrder.OrderNumber + 1;
                    else
                        dbOrder.OrderNumber = 1;
                }

                db.Orders.Add(dbOrder);
                db.SaveChanges();
                orderId = dbOrder.Id;
            }

            return orderId;
        }

        public int CreateOrderItems(OrderItem dbOrderItem)
        {
            int orderItemId = -1;
            using (var db = new Entities())
            {
                dbOrderItem.CreatedOn = DateTime.Now;
                db.OrderItems.Add(dbOrderItem);
                db.SaveChanges();
                orderItemId = dbOrderItem.Id;
            }

            return orderItemId;
        }

        public void CreateErrorMessage(ErrorMessage errorMessage)
        {
            using (var db = new Entities())
            {
                db.ErrorMessages.Add(errorMessage);
                db.SaveChanges();
            }
        }


        public bool UpdateOrderQueue(int orderId, int statusId)
        {
            bool isUpdated = false;
            using (var db = new Entities())
            {
                Order order = db.Orders.Where(x => x.Id == orderId).FirstOrDefault();
                if (order == null)
                    return isUpdated;

                order.OrderStatusId = statusId;
                db.SaveChanges();
                isUpdated = true;
            }

            return isUpdated;
        }

        public List<GlobalVariable> GetGlobalVariables()
        {
            List<GlobalVariable> variables = new List<GlobalVariable>();
            using (var db = new Entities())
            {
                variables = db.GlobalVariables.ToList();
            }

            return variables;
        }

        public List<Order> GetOrdersByStatus(int statusId)
        {
            List<Order> orders = new List<Order>();
            using (var db = new Entities())
            {
                orders = db.Orders.Include("OrderItems").Include("PaymentSource").Include("OrderItems.Product")
                    .Where(x => x.OrderStatusId == statusId).OrderBy(y=> y.OrderDateTime).ToList();
            }

            return orders;
        }

        public int GetNumberOfSmileyMealsToday()
        {
            int count = 0;
            using (var db = new Entities())
            {
                count = db.OrderItems.Where(x => x.CreatedOn <= DateTime.Now && x.ProductId == 4).ToList().Count;
            }

            return count;
        }
    }
}