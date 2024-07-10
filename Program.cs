using System.Collections.Generic;
using System;
using FinalTask_7_77;

namespace FinalTask_7_7
{
    class Program
    {
        static void Main(string[] args)

        {

            // Использование конструктора без параметров
            PersonDatabase database1 = new PersonDatabase();
            int selectedUserIndex = database1.ManageUsers();
            Console.WriteLine($"Выбран пользователь с индексом: {selectedUserIndex}");

            // Использование конструктора с параметром
            Console.WriteLine("Введите индекс пользователя для прямого выбора:");
            if (int.TryParse(Console.ReadLine(), out int directIndex))
            {
                PersonDatabase database2 = new PersonDatabase(directIndex);
                if (database2.SelectedUserData != null)
                {
                    Console.WriteLine($"Выбран пользователь: {database2.SelectedUserData[0]} {database2.SelectedUserData[1]}");
                }
            }



            PersonDataCollect personData = new PersonDataCollect();
            Console.WriteLine();
            Console.WriteLine($"Имя: {personData.PersonData[0]}");
            Console.WriteLine($"Фамилия: {personData.PersonData[1]}");
            Console.WriteLine($"Телефон: {personData.PersonData[2]}");
            Console.ReadLine();


            List<Product> cart = CartCollector.CollectCart();

            Console.WriteLine("\nКорзина заказа:");
            foreach (var product in cart)
            {
                for (int i = 0; i < product.ProductInfo.GetLength(0); i++)
                {
                    if (product.ProductInfo[i, 0] != null) { Console.WriteLine($"{product.ProductInfo[i, 0]}: {product.ProductInfo[i, 1]}"); }
                }
                Console.WriteLine();
            }



            Delivery delivery = DeliveryFactory.CreateDelivery();
            Console.WriteLine("\nДетали заказа:");
            var deliveryDetails = delivery.GetDeliveryInfo().Details;

            for (int i = 0; i < deliveryDetails.Length; i++)
            {
                if (deliveryDetails[i] != null && deliveryDetails[i].Length >= 2)
                {
                    Console.WriteLine($"{deliveryDetails[i][0]}: {deliveryDetails[i][1]}");
                }
            }
            Console.WriteLine();


       

            //var selector1 = new DeliveryAddressSelector("PickPoint");
            //// Console.WriteLine($"\n Результат: \n{selector1.result[0]}\n{selector1.result[1]}\n{selector1.result[2]}");
            ////  Console.ReadLine();
            //var selector2 = new DeliveryAddressSelector("Shop");
            //var selector3 = new HomeAddressSelector();





            //    Delivery delivery = new ShopDelivery();
            //    Console.WriteLine(delivery.GetDeliveryInfo());
            //    Console.ReadLine();
            //}


            // Создание объекта доставки
            // Console.WriteLine("Выберите тип доставки (home/pickpoint/shop):");
            //string deliveryType = Console.ReadLine();

            //try
            //{
            //    Delivery delivery = DeliveryFactory.CreateDelivery();

            //    // Получение всех деталей доставки
            //    Console.WriteLine("\nДетали доставки:");
            //    Console.WriteLine(delivery.GetDeliveryDetails());

            //    //// Получение конкретной детали
            //    //Console.WriteLine("\nВведите ключ для получения конкретной детали (например, 'Address'):");
            //    //string key = Console.ReadLine();
            //    //string detail = delivery.GetDetail(key);
            //    //Console.WriteLine($"{key}: {detail}");
            //}
            //catch (ArgumentException e)
            //{
            //    Console.WriteLine($"Ошибка: {e.Message}");
            //}
        }




      





    }
}