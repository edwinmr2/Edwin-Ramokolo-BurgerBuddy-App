
using Edwin_Ramokolo_BurgerBuddy_Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Edwin_Ramokolo_BurgerBuddy_BusinessLogic
{
    public class Simulator
    {
       
        public ObjOrder generateRandomOrder()
        {
            ObjOrder objectItem = new ObjOrder();
            objectItem.OrderDateTime = DateTime.Now;
            objectItem.PaymentSourceId = Faker.RandomNumber.Next(1, 2); //Only to options 1 = POS 2 = MrD
            return objectItem;
              
        }

        public ObjOrderItems generateRandomOrderItems()
        {
            ObjOrderItems objectItem = new ObjOrderItems();
            objectItem.ProductId = Faker.RandomNumber.Next(1, 4);//Only 4 Items that where prepopulated
            return objectItem;

        }
    }
}