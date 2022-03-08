using System;
using System.Collections.Generic;

namespace Apple_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            Console.WriteLine("Apple stora hoşgeldiniz!");
            int action = selectedAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Yeni ürün eklemeyi seçtiniz.");
                        string category = "";
                        string model = "";
                        string price = "";

                        Console.WriteLine("Lütfen bir kategori yazınız. Mac, Iphone, Airpods vb.");
                        category = Console.ReadLine();

                        Console.WriteLine("Lütfen bir model yazınız. Air, Pro vb.");
                        model = Console.ReadLine();

                        Console.WriteLine("Lütfen fiyatını yazınız.");
                        price = Console.ReadLine();
                        Product newProduct = new Product(category, model, Convert.ToDecimal(price));
                        store.ProductList.Add(newProduct);
                        productList(store);
                        break;
                    case 2:
                        Console.WriteLine("Sepete eklemek için bir ürün seçiniz.");
                        productList(store);
                        Console.WriteLine("Hangi ürünü almak istersiniz?");
                        int selectedProduct = int.Parse(Console.ReadLine());
                        store.ShoppingList.Add(store.ProductList[selectedProduct]);

                        break;
                    case 3:
                        shoppingCart(store);
                        Console.WriteLine("Toplam tutar: " + store.Checkout());

                        break;

                    default: break;


                }
            }
        }

        public static void shoppingCart(Store store)
        {
            for (int i = 0; i < store.ShoppingList.Count; i++)
            {
                Console.WriteLine("Ürün No " + i + " Kategori : " + store.ProductList[i].Category + " Model : " + store.ProductList[i].Model + " Fiyat : " + store.ProductList[i].Price);
            }
        }
        public static void productList(Store store)
        {

            for (int i = 0; i < store.ProductList.Count; i++)
            {
                Console.WriteLine("Ürün No " + i + " Kategori : " + store.ProductList[i].Category + " Model : " + store.ProductList[i].Model + " Fiyat : " + store.ProductList[i].Price);

            }
        }
        public static int selectedAction()
        {
            int selected = 0;
            Console.WriteLine("Lütfen işlemlerden birini seçiniz: Çıkmak için (0) , yeni ürün eklemek için (1) , sepete eklemek için (2) ,alışverişi bitirmek için (3)");

            selected = int.Parse(Console.ReadLine());
            return selected;
        }
    }
    class Product
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
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }



        public Customer(string id, string name, string surname, string phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
    class Store
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
