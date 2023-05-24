using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioFixacaoEnumComp.Entities.enums;
using System.Globalization;

namespace ExercicioFixacaoEnumComp.Entities
{
    class Order
    {
        public DateTime Moment { get; set; }
        public OrderStatus Status { get; set; }
        public Client Client { get; set; }

        List<OrderItem> Orderitem = new List<OrderItem>();

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
            Orderitem.Add(item);
        }

        public void RemoveItem(OrderItem item)
        {
            Orderitem.Remove(item);
        }

        public double Total()
        {
            double sum = 0;
            foreach (OrderItem item in Orderitem)
            {
                sum += item.SubTotal();
            }
            
            return sum;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Order moment " + Moment.ToString("dd/MM/yyyy HH:mm:ss"));
            sb.AppendLine("Order Status " + Status);
            sb.AppendLine("Client: " + Client);
            sb.AppendLine("Order items: ");
            foreach (OrderItem item in Orderitem)
            {
                sb.AppendLine(item.ToString());
            }
            sb.AppendLine("Total price: $" + Total().ToString("F2", CultureInfo.InvariantCulture));
            
            return sb.ToString();
        }
    }
}
