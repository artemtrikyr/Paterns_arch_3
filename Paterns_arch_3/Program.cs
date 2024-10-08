using System;
using System.Collections.Generic;

namespace Paterns_arch_3
{
    class Program
    {
        static void Main()
        {
            ShoppingCart cart = new ShoppingCart();
            bool running = true;

            while (running)
            {
                Console.WriteLine("------------------------------");
                Console.WriteLine("\nМеню:");
                Console.WriteLine("1. Додати товар");
                Console.WriteLine("2. Видалити товар");
                Console.WriteLine("3. Показати товари в кошику");
                Console.WriteLine("4. Відмінити останню дію");
                Console.WriteLine("5. Вийти");

                Console.Write("\nВиберіть дію: ");
                var choise = Console.ReadLine();
                Console.WriteLine("------------------------------");

                switch (choise)
                {
                    case "1":
                        AddProductToCart(cart);
                        break;
                    case "2":
                        RemoveProductFromCart(cart);
                        break;
                    case "3":
                        cart.ShowProduct();
                        break;
                    case "4":
                        cart.Undo();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                        break;
                }


            }
        }

        static void AddProductToCart(ShoppingCart cart)
        {
            Console.WriteLine("Введіть назву товару: ");
            var name = Console.ReadLine();
            Console.WriteLine("Введіть виробника: ");
            var manufacturer = Console.ReadLine();
            Console.WriteLine("Введіть ціну: ");
            decimal price;

            while (!decimal.TryParse(Console.ReadLine(), out price) || price < 0)
            {
                Console.Write("Некоректна ціна. Спробуйте ще раз: ");
            }

            var product = new Product(name, manufacturer, price);
            cart.AddProduct(product);
            Console.WriteLine($"Товар '{name}' додано в кошик");
        }

        static void RemoveProductFromCart(ShoppingCart cart)
        {
            Console.WriteLine("Введіть назву товару для видалення: ");
            var name = Console.ReadLine().ToLower();

            //Шукаємо товар для видалення
            var productToRemove = cart.Products.Find(product =>
            product.Name.ToLower() == name);

            if (productToRemove != null)
            {
                cart.RemoveProduct(productToRemove);
                Console.WriteLine($"Товар '{productToRemove.Name}' видалено з кошика.");
            }
            else
            {
                Console.WriteLine($"Товар '{name}' не знайдено в кошику.");
            }

        }

    }
}