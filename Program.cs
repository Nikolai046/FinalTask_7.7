using System.Collections.Generic;
using System;
using FinalTask_7;

public abstract class Delivery
{
    protected decimal CalculateCost { get; set; }
    protected string[] collectData = new AddressSelector("PickPoint").SelectAddress();

    public abstract DeliveryInfo GetDeliveryInfo();
}

public class DeliveryInfo
{
    public string[][] Details { get; set; }

    public DeliveryInfo(int capacity)
    {
        Details = new string[capacity][];
    }
}


public class HomeDelivery : Delivery
{
    public string CourierName { get; set; }
    public  string HomeAdress { get; set; }
    public DateTime DeliveryTime { get; set; }

    //private string[] collectData = new AddressSelector("PickPoint").SelectAddress();
    public override DeliveryInfo GetDeliveryInfo()
    {
        var info = new DeliveryInfo(4);
        info.Details[0] = new string[] { "Type", "Home Delivery"};
        info.Details[1] = new string[] { "CourierName", CourierName};
        info.Details[2] = new string[] { "Adress", HomeAdress};
        info.Details[3] = new string[] { "DeliveryTime", DeliveryTime.ToString()};
        info.Details[4] = new string[] { "CostOfDelivery",  CalculateCost.ToString()};
        return info;       
    }
}

public class PickPointDelivery : Delivery
{
    private string PickPointName { get; set; }
    private string PickPointAdress { get; set; }

    public override DeliveryInfo GetDeliveryInfo()
    {
        var info = new DeliveryInfo(3);
        info.Details[0] = new string[] { "Type", "Pick Point Delivery" };
        info.Details[1] = new string[] { "PickPointName", collectData[0] };
        info.Details[2] = new string[] { "Adress", collectData[1] };
        info.Details[3] = new string[] { "CostOfDelivery", collectData[2] };
        return info;
    }
}

public class ShopDelivery : Delivery
{
    public string ShopName { get; set; }
    public string ShopAdress { get; set; }

    public override DeliveryInfo GetDeliveryInfo()
    {
        var info = new DeliveryInfo(3);
        info.Details[0] = new string[] { "Type", "Shop Delivery" };
        info.Details[1] = new string[] { "ShopName", collectData[0] };
        info.Details[2] = new string[] { "Adress", collectData[1] };
        info.Details[4] = new string[] { "CostOfDelivery", collectData[2] };
        return info;
    }
}



// Класс для представления продукта
public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Description { get; set; }
}

// Класс для представления контактной информации
public class ContactInfo
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
}

// Обобщенный класс заказа
public class Order<TDelivery> where TDelivery : Delivery
{
    public int Number { get; set; }
    public string Description { get; set; }
    public TDelivery Delivery { get; set; }
    public List<Product> Products { get; set; }
    public ContactInfo CustomerContact { get; set; }
    public decimal TotalCost { get; private set; }
}

// Класс для управления коллекцией заказов
public class OrderCollection<TDelivery> where TDelivery : Delivery
{
    private List<Order<TDelivery>> orders;

    public Order<TDelivery> this[int index]
    {
        get => orders[index];
        set => orders[index] = value;
    }

    public void AddOrder(Order<TDelivery> order) { }
    public void RemoveOrder(int orderNumber) { }
}

// Статический класс для работы с заказами
public static class OrderProcessor
{
    public static void ProcessOrder<TDelivery>(Order<TDelivery> order) where TDelivery : Delivery { }
}

// Класс для работы с адресами
public static class AddressHelper
{
    public static string FormatAddress(string address) { return address; }
}

// Расширение для класса Order
public static class OrderExtensions
{
    public static void PrintOrderDetails<TDelivery>(this Order<TDelivery> order) where TDelivery : Delivery { }
}

// Абстрактный класс для представления компании доставки
public abstract class DeliveryCompany<TDelivery> where TDelivery : Delivery
{
    public string CompanyName { get; set; }
    public abstract void AssignDelivery(Order<TDelivery> order);
}

// Класс для представления курьерской компании
public class CourierCompany : DeliveryCompany<HomeDelivery>
{
    public List<string> AvailableCouriers { get; set; }
}