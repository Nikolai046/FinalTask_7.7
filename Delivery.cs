using System;
using System.Linq;

namespace FinalTask_7_7
{
    /*
    public abstract class Delivery
    {
       // protected string[] CollectData { get; set; }

       public abstract DeliveryInfo GetDeliveryInfo();
    }
    */

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

        public string GetDetail(string key)
        {
            var info = GetDeliveryInfo();
            var detail = info.Details.FirstOrDefault(d => d[0] == key);
            return detail != null ? detail[1] : null;
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
        private string[] courier = new GetFreeCourier().Result;

        private DateTime DeliveryTime = new GetDeliveryTime().Result;

        private string homeAdress = new HomeAddressSelector().Result;
        public override DeliveryInfo GetDeliveryInfo()
        {
            var info = new DeliveryInfo(5);
            info.Details[0] = new string[] { "Type", "Home Delivery" };
            info.Details[1] = new string[] { "CourierName", courier[0] };
            info.Details[2] = new string[] { "Adress", homeAdress };
            info.Details[3] = new string[] { "DeliveryTime", DeliveryTime.ToString() };
            info.Details[4] = new string[] { "CostOfDelivery", courier[1] };
            return info;
        }
    }

    public class PickPointDelivery : Delivery
    {
        private string PickPointName { get; set; }
        private string PickPointAdress { get; set; }

        private string[] CollectData = new DeliveryAddressSelector("Shop").Result;
        public override DeliveryInfo GetDeliveryInfo()
        {
            var info = new DeliveryInfo(4);
            info.Details[0] = new string[] { "Type", "Pick Point Delivery" };
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
            info.Details[0] = new string[] { "Type", "Shop Delivery" };
            info.Details[1] = new string[] { "ShopName", CollectData[0] };
            info.Details[2] = new string[] { "Adress", CollectData[1] };
            info.Details[3] = new string[] { "CostOfDelivery", CollectData[2] };
            return info;
        }
    }

    public static class DeliveryFactory
    {
        public static Delivery CreateDelivery(string type)
        {
            switch (type.ToLower())
            {
                case "home":
                    return new HomeDelivery();
                case "pickpoint":
                    return new PickPointDelivery();
                case "shop":
                    return new ShopDelivery();
                default:
                    throw new ArgumentException("Unknown delivery type");
            }
        }
    }


}
