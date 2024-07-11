using System;

namespace FinalTask_7_7
{
    class Program
    {
        static void Main(string[] args)

        {

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Создать новый заказ");
                Console.WriteLine("2. Посмотреть последний заказ");
                Console.WriteLine("3. Просмотреть все заказы");
                Console.WriteLine("0. Выйти");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new OrderProcessor("new");
                        break;
                    case "2":
                        new OrderProcessor("print");
                        break;
                    case "3":
                        new OrderProcessor("printall");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Неверный выбор. Попробуйте снова.");
                        break;
                }

                Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
                Console.ReadKey();
            }
        }


    }

}
