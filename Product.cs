using System;
using System.Collections.Generic;
using System.Text;

namespace Apple_Store
{
    public class Product
    {
        public string Category { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public Product(string category, string model, decimal price)
        {
            Category = category;
            Model = model;
            Price = price;
        }
    }
}
