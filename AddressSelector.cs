using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7
{
    public class AddressSelector
    {
        private readonly string[,] result;
        private readonly string type;

        public AddressSelector(string type)
        {
            this.type = type;
            switch (type)
            {
                case "PickPoint":
                    result = PickPointsAddress;
                    break;
                case "Shop":
                    result = ShopAddress;
                    break;
                default:
                    Console.WriteLine($"Неизвестный тип: {type}");
                    result = new string[0, 0];
                    break;
            }
        }

        public string[] SelectAddress()
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Выберите: {GetTypeDescription()}:");

                for (int i = 0; i < result.GetLength(0); i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine($"{result[i, 0]} - {result[i, 1]} - стоимость доставки: {result[i, 2]} руб.");
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key == ConsoleKey.DownArrow && selectedIndex < result.GetLength(0) - 1)
                {
                    selectedIndex++;
                }

            } while (key != ConsoleKey.Enter);

            return new string[] { result[selectedIndex, 0], result[selectedIndex, 1], result[selectedIndex, 2] };
        }

        private string GetTypeDescription()
        {
            if (type == "PickPoint")
                return "пункт выдачи и адрес";
            else if (type == "Shop")
                return "магазин";
            // Добавьте здесь описания для будущих типов
            else
                return type;
        }

        private static readonly string[,] ShopAddress = new string[,]
        {
        { "Пятёрочка", "Академика Павлова ул., 50", "0.00"},
        { "Магнит", "Рублёвское ш., 30, корп. 1", "0.00" },
        {"Перекресток", "Боровая ул., 16", "0.00"},
        {"Ашан", "Перовская ул., 4, корп. 1","0.00"},
        { "Карусель", "Бауманская ул., 58А", "0.00"}
        };

        private static readonly string[,] PickPointsAddress = new string[,]
        {
        { "Постамат: 9953", "Маршала Неделина ул., д. 40", "100.00"},
        { "Постамат: 3856", "Госпитальный Вал ул., д. 8/1", "250.00" },
        { "Постамат: 1422", "Винокурова ул., д. 22" , "150.00"},
        { "Постамат: 5656", "3-я Рыбинская ул., д. 1" , "250.00"},
        { "Постамат: 9544", "Пырьева ул., д. 4, к. 1" , "370.00"}
        };
    }


    class GetHomeAdress
    {
        public void GAdress()
        {
            string errorMessage = "";
            while (errorMessage != null)
            {
                string validatedWord = Console.ReadLine().WordValidate(out errorMessage);
                if (validatedWord != null) Console.WriteLine("Слово валидно: " + validatedWord);
                else Console.WriteLine(errorMessage);
            }
        }

    }

}