using System;
using System.Collections.Generic;
using System.Reflection;

namespace FinalTask_7_7
{
    public class OrderProcessor
    {
        public static List<string[][]> ordersDatabase = new List<string[][]>();
        private string mode;

        public OrderProcessor(string mode)
        {
            this.mode = mode;

            switch (mode)
            {
                case "new":
                    CreateOrder();
                    break;
                case "print":
                    PrintLastOrder();
                    break;
                case "printall":
                    PrintAllOrders();
                    break;
            }
        }

        private void CreateOrder()
        {
            int customerIndex = int.Parse(new PersonDatabase().SelectedUserData[0][1]);
            PersonDatabase customer = new PersonDatabase(customerIndex);
            Console.Clear();
            Console.WriteLine($"Пользователь:\n\nID: {customer.SelectedUserData[0][1]}\n{customer.SelectedUserData[1][1]} {customer.SelectedUserData[2][1]}\nтелефон: {customer.SelectedUserData[3][1]}");
            Console.ReadLine();
            List<Product> cart = CartCollector.CollectCart();
            Delivery delivery = DeliveryFactory.CreateDelivery();

            var order = new Order<PersonDatabase, List<Product>, Delivery>(customer, cart, delivery);
            var allData = order.CollectAllData();

            string orderNumber = (ordersDatabase.Count + 1).ToString();
            string orderDate = DateTime.Now.ToString();

            List<string[]> orderWithMetadata = new List<string[]>
        {
            new string[] { "OrderNumber", orderNumber },
            new string[] { "OrderDate", orderDate }
        };
            orderWithMetadata.AddRange(allData);

            ordersDatabase.Add(orderWithMetadata.ToArray());
        }

        private void PrintLastOrder()
        {
            if (ordersDatabase.Count == 0)
            {
                Console.WriteLine("Нет доступных заказов.");
                return;
            }

            var lastOrder = ordersDatabase[ordersDatabase.Count - 1];
            PrintOrder(lastOrder);
        }

        private void PrintAllOrders()
        {
            if (ordersDatabase.Count == 0)
            {
                Console.WriteLine("Нет доступных заказов.");
                return;
            }

            for (int i = 0; i < ordersDatabase.Count; i++)
            {
                Console.WriteLine($"Заказ №{i + 1}");
                PrintOrder(ordersDatabase[i]);
                Console.WriteLine();
            }
        }

        private void PrintOrder(string[][] order)
        {
            foreach (var row in order)
            {
                Console.WriteLine(string.Join("\t", row));
            }
        }
    }
}
