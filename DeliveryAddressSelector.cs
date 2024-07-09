using System;


namespace FinalTask_7_7
{
    public class DeliveryAddressSelector
    {
        private string[,] dataBase;
        private string type;
        public string[] Result { get; private set; }


        public DeliveryAddressSelector(string type)
        {
            this.type = type;
            switch (type)
            {
                case "PickPoint":
                    dataBase = PickPointsAddress;
                    SelectAddress();
                    break;
                case "Shop":
                    dataBase = ShopAddress;
                    SelectAddress();
                    break;
                default:
                    Console.WriteLine($"Неизвестный тип: {type}");
                    break;
            }
        }

        private void SelectAddress()
        {
            int selectedIndex = 0;
            ConsoleKey key;

            do
            {
                Console.Clear();
                Console.WriteLine($"Выберите: {GetTypeDescription()}:");

                for (int i = 0; i < dataBase.GetLength(0); i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine($"{dataBase[i, 0]} - {dataBase[i, 1]} - стоимость доставки: {dataBase[i, 2]} руб.");
                }

                key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (key == ConsoleKey.DownArrow && selectedIndex < dataBase.GetLength(0) - 1)
                {
                    selectedIndex++;
                }

            } while (key != ConsoleKey.Enter);

            Console.Clear();
            Console.WriteLine("Выбранная точка доступа добавлена:");
            Console.WriteLine($"{GetTypeDescription()}: {dataBase[selectedIndex, 0]}");
            Console.WriteLine($"адрес :  {dataBase[selectedIndex, 1]}");
            Console.WriteLine($"стоимость доставки: {dataBase[selectedIndex, 2]} руб.");
            Console.ReadLine();
            Result = new string[] { dataBase[selectedIndex, 0], dataBase[selectedIndex, 1], dataBase[selectedIndex, 2] };
        }

        private string GetTypeDescription()
        {
            if (type == "PickPoint")
                return "пункт выдачи";
            else if (type == "Shop")
                return "магазин";
            else
                return type;
        }

        private readonly string[,] ShopAddress = new string[,]
        {
        { "Пятёрочка", "Академика Павлова ул., 50", "0.00"},
        { "Магнит", "Рублёвское ш., 30, корп. 1", "0.00" },
        {"Перекресток", "Боровая ул., 16", "0.00"},
        {"Ашан", "Перовская ул., 4, корп. 1","0.00"},
        { "Карусель", "Бауманская ул., 58А", "0.00"}
        };

        private readonly string[,] PickPointsAddress = new string[,]
        {
        { "Постамат: 9953", "Маршала Неделина ул., д. 40", "100.00"},
        { "Постамат: 3856", "Госпитальный Вал ул., д. 8/1", "250.00" },
        { "Постамат: 1422", "Винокурова ул., д. 22" , "150.00"},
        { "Постамат: 5656", "3-я Рыбинская ул., д. 1" , "250.00"},
        { "Постамат: 9544", "Пырьева ул., д. 4, к. 1" , "370.00"}
        };
    }
}
