using RestaurantProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Repositories
{
    public class ItemRepository
    {
        private RestaurantDBEntities objrestaurantDBEntities;
        public ItemRepository()
        {
            objrestaurantDBEntities = new RestaurantDBEntities();
        }
        public IEnumerable<SelectListItem> GetAllItems()
        {
            IEnumerable<SelectListItem> objSelectListItems = new List<SelectListItem>();
            objSelectListItems = (from obj in objrestaurantDBEntities.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;

        }
    }
}