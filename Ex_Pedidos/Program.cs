using System;
using Ex_Pedidos.Entities;
using Ex_Pedidos.Entities.Enum;
using System.Globalization;

namespace Ex_Pedidos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter client data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("E-mail: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime dt = DateTime.Parse(Console.ReadLine());

            Client client = new Client(name, email, dt);

            Console.WriteLine("Enter Order Data: ");
            Console.Write("Status: ");
            OrderStatus status = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items will you order? ");
            int itemsNum = int.Parse(Console.ReadLine());

            Order order = new Order(DateTime.Now, status, client);

            for (int i=0; i<itemsNum; i++)
            {
                Console.WriteLine($"Enter #{i+1} item data: ");
                Console.Write("Product's Name: ");
                string productName = Console.ReadLine();
                Console.Write("Product's price($): ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Product's quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);

                OrderItem orderItem = new OrderItem(product, productQuantity);

                order.AddItem(orderItem);        
            }

            //SUMMARY
            Console.WriteLine();
            Console.WriteLine("SUMMARY");
            Console.WriteLine(order.ToString());
        }
    }
}
