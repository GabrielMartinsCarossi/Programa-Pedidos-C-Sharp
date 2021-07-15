using System;
using System.Collections.Generic;
using System.Text;
using Ex_Pedidos.Entities.Enum;
using System.Globalization;

namespace Ex_Pedidos.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
        public Client Client { get; set; }

        public Order()
        {
        }

        public Order(DateTime moment, OrderStatus status, Client client)
        {
            Moment = moment;
            Status = status;
            Client = client;
        }

        public void AddItem(OrderItem item)
        {
            Items.Add(item);    
        }

        public void RemoveItem(OrderItem item)
        {
            Items.Remove(item);
        }

        public double TotalPrice()
        {
            double totalPrice = 0.0;
            foreach (OrderItem item in Items)
            {
                totalPrice += item.SubTotal();
            }
            return totalPrice;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Order moment: ");
            sb.AppendLine(Moment.ToString());
            sb.Append("Order Status: ");
            sb.AppendLine(Status.ToString());
            sb.AppendLine(Client.ToString());
            sb.AppendLine("Ordered items:");
            foreach (OrderItem item in Items)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("");
            sb.AppendLine("Total Price: $"+ TotalPrice().ToString("F2", CultureInfo.InvariantCulture));
            return sb.ToString();
        }
    }
}