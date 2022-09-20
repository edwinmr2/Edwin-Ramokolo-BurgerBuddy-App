using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_BurgerBuddy_Common
{
    public class ObjErrorMessage
    {

        public int Id { get; set; }

        public string Class { get; set; }

        public string Method { get; set; }
        public string Message { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public class ObjProducts
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public bool HasGift { get; set; }
    }

    public class ObjPaymentSource
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class ObjOrderStatus
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
    public class ObjOrder
    {
        public int Id { get; set; }

        public int OrderNumber { get; set; }
        public DateTime OrderDateTime { get; set; }

        public int PaymentSourceId { get; set; }

        public int OrderStatusId { get; set; }

        public List<ObjOrderItems> OrderItems { get; set; }

        public ObjPaymentSource PaymentSource { get; set; }
    }
   

    public class ObjOrderItems
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }

        public ObjProducts Product { get; set; }

    }
    public class ObjGlobalVariable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }
    }

}