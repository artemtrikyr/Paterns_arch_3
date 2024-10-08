using System;
using System.Collections.Generic;

namespace Paterns_arch_3
{
    public class ShoppingCart
    {
        private List<Product> _products = new List<Product>();
        private CartHistory _history = new CartHistory();

        public void AddProduct(Product product)
        {
            _products.Add(product);
            _history.SaveState(this);
        }

        public void RemoveProduct(Product product)
        {
            _products.Remove(product);
            _history.SaveState(this);
        }

        public void RestoreState(Memento memento)
        {
            _products = memento.Products;
        }

        public Memento CreateMemento()
        {
            return new Memento(_products);
        }

        public void ShowProduct()
        {
            if (_products.Count == 0)
            {
                Console.WriteLine("Кошик порожній(");
            }
            else
            {
                Console.WriteLine("Товари в кошику: ");
                foreach(var product in _products)
                {
                    Console.WriteLine(product);
                }
            }
        }


        public void Undo()
        {
            var memento = _history.Undo();
            if(memento != null)
            {
                RestoreState(memento);
            }
            else
            {
                Console.WriteLine("Немає дій для відміни(");
            }
        }

        public List<Product> Products => _products;
    }
}

