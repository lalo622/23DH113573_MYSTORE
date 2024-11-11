using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _23DH113573_MyStore.Models.ViewModel
{
    public class CheckOutVM
    {
       public List<CartItem> CartItems { get; set; }
        public int CustomerID { get; set; }
        [Display(Name="Ngày Đặt  Hàng")]
        public System.DateTime OrderDate {  get; set; }
        [Display(Name ="Tổng Giá Trị")]
        public decimal TotalAmount { get; set; }
        [Display(Name = "Trạng thái thanh toán")]
        public string PaymentStatus { get; set; }
        [Display(Name = "Phương thức thanh toán")]
        public string PaymentMethod { get; set; }
        [Display(Name = "Phương thức giao hàng")]
        public string ShippingMethod { get; set; }
        [Display(Name = "Địa chỉ giao hàng")]
        public string ShippingAddress { get; set; }
        public string Username {  get; set; }
        public List<OrderDetail> OrderDetails { get; set; }

    }
}