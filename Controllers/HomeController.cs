using RestaurantProject.Models;
using RestaurantProject.Repositories;
using RestaurantProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantDBEntities objrestaurantDBEntities;
        public HomeController()
        {
            objrestaurantDBEntities = new RestaurantDBEntities();
        }
        // GET: Home
        public ActionResult Index()
        {

            var objCustomerRepository = new CustomerRepository();
            var objItemRepository = new ItemRepository();
            var objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels = new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (objCustomerRepository.GetAllCustomers(), objItemRepository.GetAllItems(), objPaymentTypeRepository.GetAllPaymentType());

            return View(objMultipleModels);
        }
        //public ActionResult Page()
        //{
        //    return View();
        //}

        [HttpGet]
        public JsonResult getItemUnitPrice(int itemId)
        {
            decimal UnitPrice = objrestaurantDBEntities.Items.Single(model => model.ItemId == itemId).ItemPrice;
            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Checkout(int? finalPrice)
        {
            ViewBag.finalPrice = finalPrice;    
            return View();
        }
        [HttpPost]
        public JsonResult Index(OrderViewModel objorderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();
            objOrderRepository.AddOrder(objorderViewModel);
            return Json("",JsonRequestBehavior.AllowGet);
        }
        public ActionResult back()
        {
            return Redirect("/Home/Index");
        }
    }
}