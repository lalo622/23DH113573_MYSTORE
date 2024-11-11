using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _23DH113573_MyStore.Models.ViewModel
{
    public class Cart
    {
        // Sử dụng List<CartItem> để lưu trữ các mục trong giỏ hàng
        private List<CartItem> items = new List<CartItem>();

        // Trả về IEnumerable nhưng cho phép thao tác trên List
        public List<CartItem> Items => items;

        // Thêm sản phẩm vào giỏ hàng
        public void Additem(int productID, string productImage, string productName, decimal unitPrice, int quantity, string category)
        {
            var existingItem = items.FirstOrDefault(i => i.ProductID == productID);
            if (existingItem == null)
            {
                items.Add(new CartItem
                {
                    ProductID = productID,
                    ProductImage = productImage,
                    ProductName = productName,
                    UnitPrice = unitPrice,
                    Quantity = quantity,
                    
                });
            }
            else
            {
                existingItem.Quantity += quantity;
            }
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public void RemoveItem(int productID)
        {
            items.RemoveAll(i => i.ProductID == productID);
        }

        // Tính tổng giá trị giỏ hàng
        public decimal TotalValue()
        {
            return items.Sum(i => i.TotalPrice);
        }

        // Xóa toàn bộ giỏ hàng
        public void Clear()
        {
            items.Clear();
        }

        // Cập nhật số lượng của một sản phẩm trong giỏ hàng
        public void UpdateQuantity(int productID, int quantity)
        {
            var item = items.FirstOrDefault(i => i.ProductID == productID);
            if (item != null)
            {
                item.Quantity = quantity;
            }
        }

        // Đếm số lượng sản phẩm trong giỏ hàng
        public int GetCartCount()
        {
            return items.Sum(i => i.Quantity);
        }
    }

}
