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
            Console.WriteLine("Enter name of dairy product:");
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Dairy";
            ProductInfo[1, 0] = "Name";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Enter quantity of dairy product:");
            ProductInfo[4, 0] = "Quantity";
            ProductInfo[4, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "Price";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00} руб.";
        }
    }
    

    public class Grocery : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора бакалейного товара
            ProductInfo = new string[4, 2];
            Console.WriteLine("Введите название товара:");
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Grocery";
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
            Console.WriteLine("Введите название овоща:");
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Vegetable";
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
            Console.WriteLine("Введите название фрукта:");
            ProductInfo[0, 0] = "Type";
            ProductInfo[0, 1] = "Fruit";
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
    }
}
