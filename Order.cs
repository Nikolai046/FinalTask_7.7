using System;
using System.Collections.Generic;

namespace FinalTask_7_7
{
    public class Order<TPersonDatabase, TProductList, TDelivery>
    {
        private TPersonDatabase customer;
        private TProductList cart;
        private TDelivery delivery;

        public Order(TPersonDatabase customer, TProductList cart, TDelivery delivery)
        {
            this.customer = customer;
            this.cart = cart;
            this.delivery = delivery;
        }

        public string[][] CollectAllData()
        {
            var customerData = GetCustomerData();
            var cartData = GetCartData();
            var deliveryData = GetDeliveryData();

            int totalRows = customerData.Length + cartData.Length + deliveryData.Length;
            string[][] allData = new string[totalRows][];

            int currentRow = 0;

            foreach (var row in customerData)
            {
                allData[currentRow++] = row;
            }

            foreach (var row in cartData)
            {
                allData[currentRow++] = row;
            }

            foreach (var row in deliveryData)
            {
                allData[currentRow++] = row;
            }

            return allData;
        }

        private string[][] GetCustomerData()
        {
            PersonDatabase db = customer as PersonDatabase;
            if (db == null)
            {
                throw new InvalidCastException("Недопустимый тип клиента");
            }

            return db.SelectedUserData;
        }

        private string[][] GetCartData()
        {
            List<Product> products = cart as List<Product>;
            if (products == null)
            {
                throw new InvalidCastException("Недопустимый тип заказа");
            }

            List<string[]> cartData = new List<string[]>();

            foreach (var product in products)
            {
                for (int i = 0; i < product.ProductInfo.GetLength(0); i++)
                {
                    string[] row = new string[product.ProductInfo.GetLength(1)];
                    for (int j = 0; j < product.ProductInfo.GetLength(1); j++)
                    {
                        row[j] = product.ProductInfo[i, j];
                    }
                    cartData.Add(row);
                }
            }

            return cartData.ToArray();
        }

        private string[][] GetDeliveryData()
        {
            Delivery deliveryObj = delivery as Delivery;
            if (deliveryObj == null)
            {
                throw new InvalidCastException("Недопустимый тип доставки");
            }

            var deliveryInfo = deliveryObj.GetDeliveryInfo();
            return deliveryInfo.Details;
        }
    }

}
