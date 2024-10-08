using System;
using System.Collections.Generic;

namespace Paterns_arch_3
{
    public class Product
    {
        public string Name { get; }
        public string Manufacturer { get; }
        public decimal Price { get; }

        public Product(string name, string manufacturer, decimal price)
        {
            Name = name;
            Manufacturer = manufacturer;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name} ({Manufacturer}) - {Price}";
        }
    }
}

