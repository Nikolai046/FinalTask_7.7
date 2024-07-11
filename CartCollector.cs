using System;
using System.Collections.Generic;

namespace FinalTask_7_7
{
    public class CartCollector
    {
        public static List<Product> CollectCart()
        {
            List<Product> cart = new List<Product>();


            while (true)
            {
                int? choice = null;
                string errorMessage = "";
                int exitEn = 1;
                while (errorMessage != null)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите категорию продукта:\n1 - Молочный продукт\n2 - Бакалея\n3 - Овощи\n4 - Фрукты");
                    if (cart.Count != 0) { Console.WriteLine("0 - Выход"); exitEn = 0; }


                    choice = Convert.ToInt32(Console.ReadLine().NumValidate(out errorMessage, exitEn, 4));
                    if (errorMessage != null)
                    {
                        Console.Clear(); Console.WriteLine(errorMessage);
                        while (true)
                        {
                            Console.ReadKey(); break;
                        }

                    }
                }

                if (choice == 0)
                {
                    break;
                }

                Product product = null;

                switch (choice)
                {
                    case 1:
                        product = new DairyProduct();
                        break;
                    case 2:
                        product = new Grocery();
                        break;
                    case 3:
                        product = new Vegetable();
                        break;
                    case 4:
                        product = new Fruit();
                        break;
                    default:
                        Console.WriteLine("Нет такой категории");
                        continue;
                }

                product.SelectProduct();
                cart.Add(product);
            }

            return cart;
        }
    }
}
