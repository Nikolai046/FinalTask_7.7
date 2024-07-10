using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7_7
{
    public abstract class Product
    {
        public string[,] ProductInfo { get; set; }

        protected Product()
        {
            ProductInfo = new string[0, 0];
        }

        public abstract void SelectProduct();
    }

    public class DairyProduct : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора молочного продукта
            ProductInfo = new string[5, 2];
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Dairy";
            Console.WriteLine("Введите название товара:");
            ProductInfo[1, 0] = "Name";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите количество:");
            ProductInfo[3, 0] = "Quantity";
            ProductInfo[3, 1] = Console.ReadLine();
            ProductInfo[4, 0] = "Price";
            ProductInfo[4, 1] = $"{new Random().Next(50, 101) * 10:000.00} руб.";
        }
    }
    

    public class Grocery : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора бакалейного товара
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Grocery";
            Console.WriteLine("Введите название товара:");
            ProductInfo[1, 0] = "Name";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "Weight";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "Price";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00} руб.";
        }
    }

    public class Vegetable : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора овоща
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Vegetable";
            Console.WriteLine("Введите название овоща:");
            ProductInfo[1, 0] = "Name";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "Weight";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "Price";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00} руб.";
        }
    }

    public class Fruit : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора фруктов
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Fruit";
            Console.WriteLine("Введите название фрукта:");
            ProductInfo[1, 0] = "Name";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "Weight";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "Price";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00} руб.";

        }
    }

    public class CartCollector
    {
        public static List<Product> CollectCart()
        {
            List<Product> cart = new List<Product>();


            while (true)
            {
                int? choice = null;
                string errorMessage = "";
                while (errorMessage != null)
                {
                    Console.Clear();
                    Console.WriteLine("Выберите категорию продукта:\n1 - Молочный продукт\n2 - Бакалея\n3 - Овощи\n4 - Фрукты\n0 - Выход");
                    choice = Convert.ToInt32(Console.ReadLine().NumValidate(out errorMessage, 0, 4));
                    if (errorMessage != null)
                    {
                        Console.Clear(); Console.WriteLine(errorMessage);
                        while (true) { Console.ReadKey(); break; }

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