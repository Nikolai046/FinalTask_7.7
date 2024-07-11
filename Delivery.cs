using System;
using System.Linq;

namespace FinalTask_7_7
{
    public abstract class Delivery
    {
        protected decimal CalculateCost { get; set; }
        protected string[] CollectData { get; set; }

        public abstract DeliveryInfo GetDeliveryInfo();

        public string GetDeliveryDetails()
        {
            var info = GetDeliveryInfo();
            return string.Join("\n", info.Details.Select(d => $"{d[0]}: {d[1]}"));
        }

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
        private GetFreeCourier courier = new GetFreeCourier();

        private DateTime DeliveryTime = new GetDeliveryTime().Result;

        private string homeAdress = new HomeAddressSelector().Result;
        public override DeliveryInfo GetDeliveryInfo()
        {
            var info = new DeliveryInfo(5);
            info.Details[0] = new string[] { "TypeOfDelivery", "Home Delivery" };
            info.Details[1] = new string[] { "CourierName", courier.CourierName };
            info.Details[2] = new string[] { "Adress", homeAdress };
            info.Details[3] = new string[] { "DeliveryTime", DeliveryTime.ToString() };
            info.Details[4] = new string[] { "CostOfDelivery", courier.CostOfDelivery };
            return info;
        }
    }

    public class PickPointDelivery : Delivery
    {
        private string PickPointName { get; set; }
        private string PickPointAdress { get; set; }

        private string[] CollectData = new DeliveryAddressSelector("PickPoint").Result;
        public override DeliveryInfo GetDeliveryInfo()
        {
            var info = new DeliveryInfo(4);
            info.Details[0] = new string[] { "TypeOfDelivery", "PickPoint Delivery" };
            info.Details[1] = new string[] { "PickPointName", CollectData[0] };
            info.Details[2] = new string[] { "Adress", CollectData[1] };
            info.Details[3] = new string[] { "CostOfDelivery", CollectData[2] };
            return info;
        }
    }

    public class ShopDelivery : Delivery
    {
        private string[] CollectData = new DeliveryAddressSelector("Shop").Result;
        public override DeliveryInfo GetDeliveryInfo()
        {
            var info = new DeliveryInfo(4);
            info.Details[0] = new string[] { "TypeOfDelivery", "Shop Delivery" };
            info.Details[1] = new string[] { "ShopName", CollectData[0] };
            info.Details[2] = new string[] { "Adress", CollectData[1] };
            info.Details[3] = new string[] { "CostOfDelivery", CollectData[2] };
            return info;
        }
    }

   

    }







