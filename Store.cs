using System;
using System.Collections.Generic;
using System.Text;

namespace Apple_Store
{
   public class Store
    {
        public List<Product> ProductList { get; set; }
        public List<Product> ShoppingList { get; set; }
        public Store()
        {
            ProductList = new List<Product>();
            ShoppingList = new List<Product>();
        }
        public decimal Checkout()
        {
            decimal total = 0;

            foreach (var item in ShoppingList)
            {
                total += item.Price;
            }
            ShoppingList.Clear();
            return total;
        }
    }
}
