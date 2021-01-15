using Cap09.Exercise01.Entities;
using Cap09.Exercise01.Entities.Enums;
using Cap09.Exercise02.Entities;
using Cap09.Exercise03;
using Cap09.Exercise03.Entities;
using Cap09.Exercise03.Entities.Enums;
using System;
using System.Globalization;

namespace Cap09
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise03();
        }

        private static void Exercise01()
        {
            Console.Write("Enter the department's name: ");
            string workerDepartment = Console.ReadLine();
            Console.WriteLine("Enter the employee data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level: (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department department = new Department(workerDepartment);

            Worker newWorker = new Worker(name, level, baseSalary, department);

            Console.Write("Hpw many contracts to this employee? ");
            int numberOfContracts = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfContracts; i++)
            {
                Console.WriteLine($"Enter #{i} contract data: ");
                {
                    Console.Write("Date (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    Console.Write("Value per hour: ");
                    double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Duration (hours): ");
                    int hours = int.Parse(Console.ReadLine());

                    HourContract contract = new HourContract(date, valuePerHour, hours);

                    newWorker.Contracts.Add(contract);
                }
            }

            Console.WriteLine();
            Console.Write("Enter month and year to calculate income(MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine(newWorker.ToString());
            Console.WriteLine("Income for " + monthAndYear +  ": " + newWorker.Income(year, month).ToString("f2", CultureInfo.InvariantCulture));
        }

        private static void Exercise02()
        {
            Post post1 = new Post(
                DateTime.Parse("21/06/2018 13:05:44"),
                "Traveling to New Zealand",
                "I'm going to visit this wonderful country!",
                12);

            Comment comment1 = new Comment("Have a nice trip");
            Comment comment2 = new Comment("Wow that's awasome!");

            post1.AddComment(comment1);
            post1.AddComment(comment2);

            Post post2 = new Post(
    DateTime.Parse("28/07/2018 23:14:19"),
    "Good night guys",
    "See you tomorrow",
    5);

            Comment comment3 = new Comment("Good night");
            Comment comment4 = new Comment("May the Force be with you");

            post2.AddComment(comment3);
            post2.AddComment(comment4);

            Console.WriteLine(post1);
            Console.WriteLine(post2);
        }

        private static void Exercise03()
        {
            Console.WriteLine("Enter Client Data: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Birth Date (DD/MM/YYYY): ");
            DateTime birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Enter Order Data: ");
            Console.Write("Status (PendingPayment, ProcessingPayment, OrderShipped, OrderDelivered): ");
            OrderStatus orderStatus = Enum.Parse<OrderStatus>(Console.ReadLine());
            Console.Write("How many items to this order: ");
            int orderQuantity = int.Parse(Console.ReadLine());

            Client client = new Client(name, email, birthDate);
            Order order = new Order(DateTime.Now, orderStatus, client);

            for (int i = 1; i <= orderQuantity; i++)
            {
                Console.WriteLine($"Enter #{i} item data: ");
                Console.Write("Product name: ");
                string productName = Console.ReadLine();
                Console.Write("Product price: ");
                double productPrice = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Quantity: ");
                int productQuantity = int.Parse(Console.ReadLine());

                Product product = new Product(productName, productPrice);
                OrderItem orderItem = new OrderItem(productQuantity, productPrice, product);

                order.AddItem(orderItem);
            }

            Console.WriteLine();
            Console.WriteLine(order.ToString());

        }

    }
}
