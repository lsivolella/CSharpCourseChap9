using Cap09.Exercise03.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Cap09.Exercise03.Entities
{
    class Order
    {
        public DateTime Date { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order() { }

        public Order(DateTime date, OrderStatus status, Client client)
        {
            Date = date;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem orderItem)
        {
            Items.Add(orderItem);
        }

        public void RemoveItem(OrderItem orderItem)
        {
            Items.Remove(orderItem);
        }
        
        public double Total()
        {
            double total = 0;

            foreach (OrderItem orderItem in Items)
            {
                total += orderItem.SubTotal();
            }

            return total;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine("Order Summary: ");
            stringBuilder.Append("Order Date: ");
            stringBuilder.AppendLine(Date.ToString("dd/MM/yyyy HH:mm:ss"));
            stringBuilder.Append("Order Status: ");
            stringBuilder.AppendLine(Status.ToString());
            stringBuilder.Append("Client: ");
            stringBuilder.AppendLine(Client.ToString());
            stringBuilder.AppendLine("Order Items: ");

            foreach (OrderItem orderItem in Items)
            {
                stringBuilder.AppendLine(orderItem.ToString());
            }

            stringBuilder.Append("Total Price: $");
            stringBuilder.AppendLine(Total().ToString("f2", CultureInfo.InvariantCulture));

            return stringBuilder.ToString();
        }
    }
}
