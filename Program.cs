using System;
using System.Collections.Generic;

namespace Apple_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            Store store = new Store();
            List<Customer> customers = new List<Customer>() { new Customer("11111111111", "Ogün", "Çimen", "55555555") };
            Console.WriteLine("Apple stora hoşgeldiniz!");
            Console.Write("Lütfen TC Kimlik Numaranızı giriniz : ");
            string tc = Console.ReadLine();
            if (tc.Length != 11)
            {
                Console.WriteLine("TC Kimlik Numaranız 11 haneli olmalıdır.");
            }
            var customer = customers.Find(x => x.Id == tc);

            if (customer != null)
            {
                Console.WriteLine("İlgili müşteri bilgileri : " + "Tc : " + customer.Id + " Ad : " + customer.Name + " Soyad : " + customer.Surname + " Telefon : " + customer.Phone);
            }
            else
            {
                Console.WriteLine("İlgili müşteri bulunamadı. Lütfen yeni bir müşteri oluşturunuz.");
                tc:
                Console.Write("Tc : ");
                tc = Console.ReadLine();
                if (tc.Length!=11)
                {
                    goto tc;
                }
                Console.Write("Ad : ");
                string ad = Console.ReadLine();
                Console.Write("Soyad : ");
                string soyad = Console.ReadLine();
                Console.Write("Telefon : ");
                string telefon = Console.ReadLine();
                Customer newCustomer = new Customer(tc, ad, soyad, telefon);
                customers.Add(newCustomer);
            }
            int action = selectedAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        Console.WriteLine("Yeni ürün eklemeyi seçtiniz. İstediğiniz ürünün ürün numarasınız yazınız.");
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
                action = selectedAction();

            }
        }

        static public void shoppingCart(Store store)
        {
            for (int i = 0; i < store.ShoppingList.Count; i++)
            {
                Console.WriteLine("Ürün Numarası " + i + " Kategori : " + store.ShoppingList[i].Category + " Model : " + store.ShoppingList[i].Model + " Fiyat : " + store.ShoppingList[i].Price);
            }
        }
        public static void productList(Store store)
        {

            for (int i = 0; i < store.ProductList.Count; i++)
            {
                Console.WriteLine("Ürün Numarası " + i + " Kategori : " + store.ProductList[i].Category + " Model : " + store.ProductList[i].Model + " Fiyat : " + store.ProductList[i].Price);

            }
        }
        static public int selectedAction()
        {
            int selected = 0;
            Console.WriteLine("Lütfen işlemlerden birini seçiniz: Çıkmak için (0) , yeni ürün eklemek için (1) , sepete eklemek için (2) ,alışverişi bitirmek için (3)");

            selected = int.Parse(Console.ReadLine());
            return selected;
        }
    }
    
   


}
