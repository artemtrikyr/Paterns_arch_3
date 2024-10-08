using System;
using System.Collections.Generic;

namespace Paterns_arch_3
{
    public class Memento
    {
        public List<Product> Products { get; }

        public Memento(List<Product> product)
        {
            Products = new List<Product>(product);
        }
    }
}

