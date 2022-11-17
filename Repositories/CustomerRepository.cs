using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Repositories
{
    public class CustomerRepository
    {
        private RestaurantDBEntities objrestaurantDBEntities;
        public CustomerRepository()
        {
            objrestaurantDBEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurantDBEntities.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;

             

        }
    }
}