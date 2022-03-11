using System;
using System.Collections.Generic;

namespace Apple_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a new store
            Store store = new Store();
            // Create a new customerlist
            List<Customer> customers = new List<Customer>() { new Customer("11111111111", "Ogün", "Çimen", "55555555") };

            Console.WriteLine("Apple stora hoşgeldiniz!");
            Console.WriteLine("----------------------------------------------------");

        tcValidation:
            Console.Write("Lütfen TC Kimlik Numaranızı giriniz : ");
            string tc = Console.ReadLine();
            //if tc is smaller than 11 digits or bigger than 11 digits then go to tcValidation again  
            if (tc.Length != 11)
            {
                Console.WriteLine("TC Kimlik Numaranız 11 haneli olmalıdır.");
                goto tcValidation;
            }
            // Check if the customer is in the store
            var customer = customers.Find(x => x.Id == tc);
            if (customer != null)
            {
                // If the customer is in the store, show the customer's information 
                Console.WriteLine("İlgili müşteri bilgileri : " + "Tc : " + customer.Id + " Ad : " + customer.Name + " Soyad : " + customer.Surname + " Telefon : " + customer.Phone);
            }
            // If the customer is not in the store, add him to the customer list
            else
            {
                Console.WriteLine("İlgili müşteri bulunamadı. Lütfen yeni bir müşteri oluşturunuz.");
                Console.Write("Ad : ");
                string ad = Console.ReadLine();
                Console.Write("Soyad : ");
                string soyad = Console.ReadLine();
                Console.Write("Telefon : ");
                string telefon = Console.ReadLine();
                Customer newCustomer = new Customer(tc, ad, soyad, telefon);
                customers.Add(newCustomer);
            }

        selectedAction:
            int action = selectedAction();
            while (action != 0)
            {
                switch (action)
                {
                    case 1:
                        //Get the product information from the user
                        Console.WriteLine("Yeni ürün eklemeyi seçtiniz.");
                        Console.WriteLine("------------------------------------------------------------------------");

                        string category = "";
                        string model = "";
                        string price = "";

                        Console.WriteLine("Lütfen bir kategori yazınız. Mac, Iphone, Airpods vb.");
                        Console.WriteLine("----------------------------------------------------");

                        category = Console.ReadLine();

                        Console.WriteLine("Lütfen bir model yazınız. Air, Pro vb.");
                        Console.WriteLine("----------------------------------------------------");
                        model = Console.ReadLine();

                        Console.WriteLine("Lütfen fiyatını yazınız.");
                        Console.WriteLine("----------------------------------------------------");

                    priceValidation:
                        price = Console.ReadLine();
                        //if price is not a number then go to priceValidation again
                        if (!decimal.TryParse(price, out decimal priceDecimal))
                        {
                            Console.WriteLine("Lütfen bir sayı giriniz.");
                            goto priceValidation;
                        }
                        // Create a new product
                        Product newProduct = new Product(category, model, Convert.ToDecimal(price));
                        // Add the product to the store's product list
                        store.ProductList.Add(newProduct);
                        // Show the product list
                        productList(store);
                        break;
                    case 2:
                        //if ProductList is empty, go to selectedAction again
                        if (store.ProductList.Count == 0)
                        {
                            Console.WriteLine("Sepete ürün eklemeden önce ürün girişi yapmalısınız.");
                            goto selectedAction;
                        }
                        Console.WriteLine("Sepete eklemek için bir ürün seçiniz.");
                        // Show the product list
                        productList(store);
                        Console.WriteLine("Hangi ürünü almak istersiniz?");
                        Console.WriteLine("----------------------------------------------------");
                        // Get the product number
                        int selectedProduct = int.Parse(Console.ReadLine());
                        //Add the product to the shopping list
                        store.ShoppingList.Add(store.ProductList[selectedProduct]);

                        break;
                    case 3:
                        shoppingCart(store);
                        //Show the total price of the shopping list
                        Console.WriteLine("Toplam tutar: " + store.Checkout());
                        break;
                    case 4:
                        //show the shopping list
                        shoppingCart(store);
                        break;

                    default:
                        //if the user entered a wrong number, go to selectedAction again
                        Console.WriteLine("Lütfen belirlenmiş değerlerden bir seçim yapınız.");
                        goto selectedAction;
                        break;
                }
                action = selectedAction();

            }
        }

        static public void shoppingCart(Store store)
        {
            //show the shopping list
            Console.WriteLine("Sepetiniz");
            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < store.ShoppingList.Count; i++)
            {
                Console.WriteLine("Ürün Numarası " + i + " Kategori : " + store.ShoppingList[i].Category + " Model : " + store.ShoppingList[i].Model + " Fiyat : " + store.ShoppingList[i].Price);
            }
            Console.WriteLine("----------------------------------------------------");

        }
        public static void productList(Store store)
        {
            //show the product list
            Console.WriteLine("Ürün Listesi");
            Console.WriteLine("----------------------------------------------------");
            for (int i = 0; i < store.ProductList.Count; i++)
            {
                Console.WriteLine("Ürün Numarası " + i + " Kategori : " + store.ProductList[i].Category + " Model : " + store.ProductList[i].Model + " Fiyat : " + store.ProductList[i].Price);
            }
            Console.WriteLine("----------------------------------------------------");

        }

        static public int selectedAction()
        {
        actionValidation:
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine("Lütfen aşağıdaki işlemlerden birini seçiniz;");
            Console.WriteLine("Çıkmak için              (0)");
            Console.WriteLine("Yeni ürün eklemek için   (1)");
            Console.WriteLine("Sepete ürün eklemek için (2)");
            Console.WriteLine("Alışverişi bitirmek için (3)");
            Console.WriteLine("Sepeti görmek için       (4)");
            Console.WriteLine("----------------------------------------------------");


            string action = Console.ReadLine();
            //check if the input is a an integer
            if (!isInteger(action))
            {
                //if not, go to actionValidation again
                Console.WriteLine("Lütfen bir sayı giriniz.");
                goto actionValidation;
            }
            return int.Parse(action);

        }
        //check if the input is an integer
        static public bool isInteger(string input)
        {
            int number;
            bool isNumber = int.TryParse(input, out number);
            return isNumber;
        }


    }
}
