using System;

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
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "TypeOfProduct";
            ProductInfo[0, 1] = "Dairy";
            Console.WriteLine("Введите название товара:");
            ProductInfo[1, 0] = "NameOfProduct";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите количество:");
            ProductInfo[2, 0] = "QuantityOfProduct";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "PriceOfProduct";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00}";
        }
    }


    public class Grocery : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора бакалейного товара
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "TypeOfProduct";
            ProductInfo[0, 1] = "Grocery";
            Console.WriteLine("Введите название товара:");
            ProductInfo[1, 0] = "NameOfProduct";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "WeightOfProduct";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "PriceOfProduct";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00}";
        }
    }

    public class Vegetable : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора овоща
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "TypeOfProduct";
            ProductInfo[0, 1] = "Vegetable";
            Console.WriteLine("Введите название овоща:");
            ProductInfo[1, 0] = "NameOfProduct";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "WeightOfProduct";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "PriceOfProduct";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00}";
        }
    }

    public class Fruit : Product
    {
        public override void SelectProduct()
        {
            // Пример выбора фруктов
            ProductInfo = new string[4, 2];
            ProductInfo[0, 0] = "TypeOfProduct";
            ProductInfo[0, 1] = "Fruit";
            Console.WriteLine("Введите название фрукта:");
            ProductInfo[1, 0] = "NameOfProduct";
            ProductInfo[1, 1] = Console.ReadLine();
            Console.WriteLine("Введите вес:");
            ProductInfo[2, 0] = "WeightOfProduct";
            ProductInfo[2, 1] = Console.ReadLine();
            ProductInfo[3, 0] = "PriceOfProduct";
            ProductInfo[3, 1] = $"{new Random().Next(50, 101) * 10:000.00}";

        }
    }


}


