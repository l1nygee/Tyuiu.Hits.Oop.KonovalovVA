using System;
using System.Collections.Generic;

namespace StoreExample
{
    public class Product
    {
        private string Name { get; set; }
        private decimal Price { get; set; }
        private int Quantity { get; set; }
        protected string Category { get; set; }
        internal string Description { get; set; }

        public Product(string name, decimal price, int quantity, string category, string description)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
            Category = category;
            Description = description;
        }

        public decimal GetTotalPrice()
        {
            return Price * Quantity;
        }

        public void UpdateQuantity(int amount)
        {
            Quantity += amount;
        }

        public string GetProductInfo()
        {
            return Description;
        }

        public string GetInfo()
        {
            return $"Название: {Name}, Цена: {Price}, Количество: {Quantity}, Категория: {Category}, Описание: {Description}";
        }
        public void Display()
        {
            Console.WriteLine(GetInfo());
        }

    }

    public class Seller
    {
        private string Name { get; set; }
        private string EmployeeId { get; set; }
        protected decimal Salary { get; set; }
        internal string ContactInfo { get; set; }

        public List<Product> Products = new List<Product>();

        public Seller(string name, string employeeId, decimal salary, string contactInfo)
        {
            Name = name;
            EmployeeId = employeeId;
            Salary = salary;
            ContactInfo = contactInfo;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }

        public void SellProduct(Product product, int quantity)
        {
            product.UpdateQuantity(-quantity);
        }

        public void GetSellerInfo()
        {
            Console.WriteLine($"Имя: {Name}, ID продавца: {EmployeeId}, Зарплата: {Salary}, Контакты: {ContactInfo}");
        }
    }

    public class Store
    {
        private string StoreName { get; set; }
        private string Location { get; set; }
        public string StoreHours { get; set; }

        private List<Seller> Sellers = new List<Seller>();

        public Store(string storeName, string location, string storeHours)
        {
            StoreName = storeName;
            Location = location;
            StoreHours = storeHours;
        }

        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        public void ListProducts(List<Product> products)
        {
            foreach (var product in products)
            {
                product.Display();
            }
        }

        public string GetStoreInfo()
        {
            return $"Название магазина: {StoreName}, Местоположение: {Location}, Часы работы: {StoreHours}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Product product = new Product("Мышь", 2500, 4, "Аксессуар", "Беспроводная");
            Seller seller = new Seller("Олег", "ID007", 50000, "oleg@store.ru");
            Store store = new Store("Техника", "Центр", "10-20");

            Console.WriteLine(product.GetTotalPrice());
            product.UpdateQuantity(1);
            Console.WriteLine(product.GetTotalPrice());

            seller.AddProduct(product);
            store.AddSeller(seller);

            Console.WriteLine($"До продажи: {product.GetInfo()}");
            seller.SellProduct(product, 2);
            Console.WriteLine($"После продажи: {product.GetInfo()}");
            Console.WriteLine($"Магазин: {store.GetStoreInfo()}");
        }
    }
}