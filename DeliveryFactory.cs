using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask_7_7
{
    public static class DeliveryFactory
    {
        private static readonly string[] deliveryTypes = { "Доставка на дом", "PickPoint", "Доставка в магазин" };

        public static Delivery CreateDelivery()
        {
            int selectedIndex = 0;
            ConsoleKeyInfo keyInfo;

            do
            {
                Console.Clear();
                Console.WriteLine("Выберите тип доставки:");

                for (int i = 0; i < deliveryTypes.Length; i++)
                {
                    if (i == selectedIndex)
                    {
                        Console.Write("> ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }
                    Console.WriteLine(deliveryTypes[i]);
                }

                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedIndex > 0)
                {
                    selectedIndex--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedIndex < deliveryTypes.Length - 1)
                {
                    selectedIndex++;
                }

            } while (keyInfo.Key != ConsoleKey.Enter);


            switch (selectedIndex)
            {
                case 0:
                    return new HomeDelivery();
                case 1:
                    return new PickPointDelivery();
                case 2:
                    return new ShopDelivery();
                default:
                    throw new ArgumentException("Unknown delivery type");
            }

        }
    }
}
