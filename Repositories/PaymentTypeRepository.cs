using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Repositories
{
    public class PaymentTypeRepository
    {
        private RestaurantDBEntities objrestaurantDBEntities;
        public PaymentTypeRepository()
        {
            objrestaurantDBEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllPaymentType()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurantDBEntities.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;

        }
    }
}