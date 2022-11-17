using RestaurantProject.Models;
using RestaurantProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestaurantProject.Repositories
{


    public class OrderRepository
    {
        private RestaurantDBEntities objrestaurantDBEntities;
        public OrderRepository()
        {
            objrestaurantDBEntities = new RestaurantDBEntities();
        }


        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;
            objrestaurantDBEntities.Orders.Add(objOrder);
            objrestaurantDBEntities.SaveChanges();
            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.Quantity;
                objrestaurantDBEntities.OrderDetails.Add(objOrderDetail);
                objrestaurantDBEntities.SaveChanges();


                Transaction objTransaction = new Transaction();
                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;
                objTransaction.TypeId = 2;
                objrestaurantDBEntities.Transactions.Add(objTransaction);
                objrestaurantDBEntities.SaveChanges();
            }
            return true;

        }
    }
}