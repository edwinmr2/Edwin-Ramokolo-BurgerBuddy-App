using Edwin_Ramokolo_BurgerBuddy_BusinessLogic;
using Edwin_Ramokolo_BurgerBuddy_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edwin_Ramokolo_BurgerBuddy_App.Controllers
{
    public class OrdersController : ApiController
    {
        public int Post(ObjOrder order, List<ObjOrderItems> orderItems)
        {
            int orderId = new Logic().CreateOrder(order, orderItems);
            return orderId;
        }

        public bool Get()
        {
            bool isCreated = new Logic().SimulateOrders();
            return isCreated;
        }
    }

    public class UpdateOrdersController : ApiController
    {
        public bool Post(int orderId, int statusId)
        {
            bool isUpdated = new Logic().UpdateOrderQueue(orderId, statusId);
            return isUpdated;
        }
        public bool Get()
        {
            bool isCreated = new Logic().SimulateOrderCollection();
            return isCreated;
        }
    }

    public class GetPreparingOrdersController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<ObjOrder> orders = new Logic().GetPreparingOrders();
            return Json(orders);
        }
    }

    public class GetReadyToCollectOrdersController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<ObjOrder> orders = new Logic().GetReadyToCollectOrders();
            return Json(orders);
        }
    }

    public class GetOrdersByStatusController : ApiController
    {
        public IHttpActionResult Get(int orderStatusId)
        {
            List<ObjOrder> orders = new Logic().GetOrdersByStatus(orderStatusId);
            return Json(orders);
        }
    }
}
