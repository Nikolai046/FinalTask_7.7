using System.Collections.Generic;
using System;
using FinalTask_7_77;

namespace FinalTask_7_7
{
    class Program
    {
        static void Main(string[] args)

        {
        //    Delivery delivery = new ShopDelivery();
        //    Console.WriteLine(delivery.GetDeliveryInfo());
        //    Console.ReadLine();
        //}

            
            // Создание объекта доставки
            Console.WriteLine("Выберите тип доставки (home/pickpoint/shop):");
            string deliveryType = Console.ReadLine();

            try
            {
                Delivery delivery = DeliveryFactory.CreateDelivery(deliveryType);

                // Получение всех деталей доставки
                Console.WriteLine("\nДетали доставки:");
                Console.WriteLine(delivery.GetDeliveryDetails());

                // Получение конкретной детали
                Console.WriteLine("\nВведите ключ для получения конкретной детали (например, 'Address'):");
                string key = Console.ReadLine();
                string detail = delivery.GetDetail(key);
                Console.WriteLine($"{key}: {detail}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
            }
        }
            



            //PersonDataCollect personData = new PersonDataCollect();
            //    Console.WriteLine();
            //    Console.WriteLine($"Имя: {personData.PersonData[0]}");
            //    Console.WriteLine($"Фамилия: {personData.PersonData[1]}");
            //    Console.WriteLine($"Телефон: {personData.PersonData[2]}");
            //    Console.ReadLine();

            //    var selector1 = new DeliveryAddressSelector("PickPoint");
            //    // Console.WriteLine($"\n Результат: \n{selector1.result[0]}\n{selector1.result[1]}\n{selector1.result[2]}");
            //    //  Console.ReadLine();
            //    var selector2 = new DeliveryAddressSelector("Shop");
            //    var selector3 = new HomeAddressSelector();





    }
}