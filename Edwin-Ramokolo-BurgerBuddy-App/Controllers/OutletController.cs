using Edwin_Ramokolo_BurgerBuddy_BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edwin_Ramokolo_BurgerBuddy_App.Controllers
{
    public class OutletController : ApiController
    {
       

    }

    public class OutletClosedController : ApiController
    {
        public bool Get()
        {
            bool isOpened = new Logic().CheckStoreStatus();
            return isOpened;
        }

    }

    public class GetNumberOfSmileyMealsTodayController : ApiController
    {
        public int Get()
        {
            int numberOfDay = new Logic().GetNumberOfSmileyMealsToday();
            return numberOfDay;
        }

    }
}
