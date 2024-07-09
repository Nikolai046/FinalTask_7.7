//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace FinalTask_7_7
//{
//    // Класс для представления продукта
//    public class Product
//    {
//        public string Name { get; set; }
//        public decimal Price { get; set; }
//        public string Description { get; set; }
//    }

//    // Класс для представления контактной информации
//    public class ContactInfo
//    {
//        public string PhoneNumber { get; set; }
//        public string Email { get; set; }
//    }

   
//    }

//    // Класс для управления коллекцией заказов
//    public class OrderCollection<TDelivery> where TDelivery : Delivery
//    {
//        private List<Order<TDelivery>> orders;

//        public Order<TDelivery> this[int index]
//        {
//            get => orders[index];
//            set => orders[index] = value;
//        }

//        public void AddOrder(Order<TDelivery> order) { }
//        public void RemoveOrder(int orderNumber) { }
//    }

//    // Статический класс для работы с заказами
//    public static class OrderProcessor
//    {
//        public static void ProcessOrder<TDelivery>(Order<TDelivery> order) where TDelivery : Delivery { }
//    }

//    // Класс для работы с адресами
//    public static class AddressHelper
//    {
//        public static string FormatAddress(string address) { return address; }
//    }

//    // Расширение для класса Order
//    public static class OrderExtensions
//    {
//        public static void PrintOrderDetails<TDelivery>(this Order<TDelivery> order) where TDelivery : Delivery { }
//    }

//    // Абстрактный класс для представления компании доставки
//    public abstract class DeliveryCompany<TDelivery> where TDelivery : Delivery
//    {
//        public string CompanyName { get; set; }
//        public abstract void AssignDelivery(Order<TDelivery> order);
//    }

//    // Класс для представления курьерской компании
//    public class CourierCompany : DeliveryCompany<HomeDelivery>
//    {
//        public List<string> AvailableCouriers { get; set; }
//    }
//}
