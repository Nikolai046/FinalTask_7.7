using FinalTask_7;
using System;


namespace FinalTask_7_7
{
    abstract class Delivery
    {
        public string Address { get; set; }

    }

    class HomeDelivery : Delivery
    {
       
    }

    class PickPointDelivery : Delivery
    {
        private readonly string[,] PickPoints = new string[,]
        {
        { "Пятёрочка", "Академика Павлова ул., 50" },
        { "Магнит", "Рублёвское ш., 30, корп. 1"},
        {"Перекресток", "Боровая ул., 16"},
        {"Ашан", "Перовская ул., 4, корп. 1"},
        { "Карусель", "Бауманская ул., 58А"}
         };

    }

    class ShopDelivery : Delivery
    {
        private readonly string[,] PickPoints = new string[,]
         {
        { "Постамат: Халва", "Маршала Неделина ул., д. 40" },
        { "Постамат: Халва", "Госпитальный Вал ул., д. 8/1" },
        { "Постамат: Халва", "Винокурова ул., д. 22" },
        { "Постамат: Халва", "3-я Рыбинская ул., д. 1" }, 
        { "Постамат: Халва", "Пырьева ул., д. 4, к. 1" }
          };
    }
    class GetAdress 
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
    class Order<TDelivery, TStruct> where TDelivery : Delivery
    {
        public TDelivery Delivery;

        public int Number;

        public string Description;

        public void DisplayAddress()
        {
            Console.WriteLine(Delivery.Address);
        }

        // ... Другие поля
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            
            HomeDelivery delivery = new HomeDelivery();
            delivery.GetAdress();

        }
    }
}
