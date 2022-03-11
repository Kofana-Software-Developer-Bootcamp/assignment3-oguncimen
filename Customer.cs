using System;
using System.Collections.Generic;
using System.Text;

namespace Apple_Store
{

    public class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        // Constructor for creating a new customer
        public Customer(string id, string name, string surname, string phone)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Phone = phone;
        }
    }
}
