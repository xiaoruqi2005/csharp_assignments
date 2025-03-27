namespace assignment5
{
    internal class Program
    {
        static OrderService orderService = new OrderService();

        static void Main(string[] args)
        {
            InitializeSampleData();

            while (true)
            {
                Console.WriteLine("\n=== Order Management System ===");
                Console.WriteLine("1. Add Order");
                Console.WriteLine("2. Remove Order");
                Console.WriteLine("3. Modify Order");
                Console.WriteLine("4. Query Orders");
                Console.WriteLine("5. List All Orders");
                Console.WriteLine("6. Sort Orders");
                Console.WriteLine("7. Export Orders");
                Console.WriteLine("8. Import Orders");
                Console.WriteLine("0. Exit");
                Console.Write("Please select an option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                    continue;
                }

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddOrder();
                            break;
                        case 2:
                            RemoveOrder();
                            break;
                        case 3:
                            ModifyOrder();
                            break;
                        case 4:
                            QueryOrders();
                            break;
                        case 5:
                            ListAllOrders();
                            break;
                        case 6:
                            SortOrders();
                            break;
                        case 7:
                            ExportOrders();
                            break;
                        case 8:
                            ImportOrders();
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            return;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }

        static void InitializeSampleData()
        {
            try
            {
                // Sample products
                Product p1 = new Product("P001", "Laptop", 999.99m);
                Product p2 = new Product("P002", "Mouse", 19.99m);
                Product p3 = new Product("P003", "Keyboard", 49.99m);
                Product p4 = new Product("P004", "Monitor", 199.99m);

                // Sample customers
                Customer c1 = new Customer("C001", "John Doe", "john@example.com");
                Customer c2 = new Customer("C002", "Jane Smith", "jane@example.com");

                // Sample orders
                Order o1 = new Order("O001", c1, DateTime.Now);
                o1.AddOrderDetail(new OrderDetail(p1, 1));
                o1.AddOrderDetail(new OrderDetail(p2, 2));

                Order o2 = new Order("O002", c2, DateTime.Now.AddDays(-1));
                o2.AddOrderDetail(new OrderDetail(p3, 1));
                o2.AddOrderDetail(new OrderDetail(p4, 2));

                orderService.AddOrder(o1);
                orderService.AddOrder(o2);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing sample data: {ex.Message}");
            }
        }

        static void AddOrder()
        {
            Console.WriteLine("\n--- Add New Order ---");

            Console.Write("Enter Order ID: ");
            string orderId = Console.ReadLine();

            Console.Write("Enter Customer ID: ");
            string customerId = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Customer Contact: ");
            string contactInfo = Console.ReadLine();

            Customer customer = new Customer(customerId, customerName, contactInfo);
            Order newOrder = new Order(orderId, customer, DateTime.Now);

            while (true)
            {
                Console.Write("Add product to order? (y/n): ");
                if (Console.ReadLine().ToLower() != "y") break;

                Console.Write("Enter Product ID: ");
                string productId = Console.ReadLine();

                Console.Write("Enter Product Name: ");
                string productName = Console.ReadLine();

                Console.Write("Enter Product Price: ");
                decimal price = decimal.Parse(Console.ReadLine());

                Console.Write("Enter Quantity: ");
                int quantity = int.Parse(Console.ReadLine());

                Product product = new Product(productId, productName, price);
                OrderDetail detail = new OrderDetail(product, quantity);

                try
                {
                    newOrder.AddOrderDetail(detail);
                    Console.WriteLine("Product added to order.");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }

            try
            {
                orderService.AddOrder(newOrder);
                Console.WriteLine("Order added successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void RemoveOrder()
        {
            Console.WriteLine("\n--- Remove Order ---");
            Console.Write("Enter Order ID to remove: ");
            string orderId = Console.ReadLine();

            try
            {
                orderService.RemoveOrder(orderId);
                Console.WriteLine("Order removed successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void ModifyOrder()
        {
            Console.WriteLine("\n--- Modify Order ---");
            Console.Write("Enter Order ID to modify: ");
            string orderId = Console.ReadLine();

            var orders = orderService.QueryByOrderId(orderId);
            if (orders.Count == 0)
            {
                Console.WriteLine("Order not found.");
                return;
            }

            Order existingOrder = orders[0];
            Console.WriteLine("Existing Order:");
            Console.WriteLine(existingOrder);

            Console.Write("Enter new Customer Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName))
            {
                existingOrder.Customer.Name = newName;
            }

            Console.Write("Enter new Customer Contact (leave blank to keep current): ");
            string newContact = Console.ReadLine();
            if (!string.IsNullOrEmpty(newContact))
            {
                existingOrder.Customer.ContactInfo = newContact;
            }

            while (true)
            {
                Console.Write("Modify products? (y/n): ");
                if (Console.ReadLine().ToLower() != "y") break;

                Console.Write("Add (a) or Remove (r) product: ");
                string action = Console.ReadLine().ToLower();

                if (action == "a")
                {
                    Console.Write("Enter Product ID: ");
                    string productId = Console.ReadLine();

                    Console.Write("Enter Product Name: ");
                    string productName = Console.ReadLine();

                    Console.Write("Enter Product Price: ");
                    decimal price = decimal.Parse(Console.ReadLine());

                    Console.Write("Enter Quantity: ");
                    int quantity = int.Parse(Console.ReadLine());

                    Product product = new Product(productId, productName, price);
                    OrderDetail detail = new OrderDetail(product, quantity);

                    try
                    {
                        existingOrder.AddOrderDetail(detail);
                        Console.WriteLine("Product added to order.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
                else if (action == "r")
                {
                    Console.Write("Enter Product ID to remove: ");
                    string productId = Console.ReadLine();

                    try
                    {
                        Product product = new Product(productId, "", 0);
                        existingOrder.RemoveOrderDetail(product);
                        Console.WriteLine("Product removed from order.");
                    }
                    catch (ArgumentException ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            try
            {
                orderService.ModifyOrder(existingOrder);
                Console.WriteLine("Order modified successfully.");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void QueryOrders()
        {
            Console.WriteLine("\n--- Query Orders ---");
            Console.WriteLine("1. By Order ID");
            Console.WriteLine("2. By Product Name");
            Console.WriteLine("3. By Customer Name");
            Console.WriteLine("4. By Amount Range");
            Console.Write("Select query type: ");

            if (!int.TryParse(Console.ReadLine(), out int queryType))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            List<Order> results = new List<Order>();

            switch (queryType)
            {
                case 1:
                    Console.Write("Enter Order ID (or part of it): ");
                    string orderId = Console.ReadLine();
                    results = orderService.QueryByOrderId(orderId);
                    break;
                case 2:
                    Console.Write("Enter Product Name (or part of it): ");
                    string productName = Console.ReadLine();
                    results = orderService.QueryByProductName(productName);
                    break;
                case 3:
                    Console.Write("Enter Customer Name (or part of it): ");
                    string customerName = Console.ReadLine();
                    results = orderService.QueryByCustomer(customerName);
                    break;
                case 4:
                    Console.Write("Enter Minimum Amount: ");
                    decimal minAmount = decimal.Parse(Console.ReadLine());
                    Console.Write("Enter Maximum Amount: ");
                    decimal maxAmount = decimal.Parse(Console.ReadLine());
                    results = orderService.QueryByAmountRange(minAmount, maxAmount);
                    break;
                default:
                    Console.WriteLine("Invalid query type.");
                    return;
            }

            Console.WriteLine($"\nFound {results.Count} orders:");
            foreach (var order in results)
            {
                Console.WriteLine(order);
                Console.WriteLine("---------------------");
            }
        }

        static void ListAllOrders()
        {
            var orders = orderService.GetAllOrders();
            Console.WriteLine("\n--- All Orders ---");
            foreach (var order in orders)
            {
                Console.WriteLine(order);
                Console.WriteLine("---------------------");
            }
        }

        static void SortOrders()
        {
            Console.WriteLine("\n--- Sort Orders ---");
            Console.WriteLine("1. By Order ID (default)");
            Console.WriteLine("2. By Total Amount");
            Console.WriteLine("3. By Order Date");
            Console.Write("Select sort option: ");

            if (!int.TryParse(Console.ReadLine(), out int sortOption))
            {
                Console.WriteLine("Invalid input.");
                return;
            }

            switch (sortOption)
            {
                case 1:
                    orderService.SortOrders();
                    Console.WriteLine("Orders sorted by Order ID.");
                    break;
                case 2:
                    orderService.SortOrders((o1, o2) => o1.TotalAmount.CompareTo(o2.TotalAmount));
                    Console.WriteLine("Orders sorted by Total Amount.");
                    break;
                case 3:
                    orderService.SortOrders((o1, o2) => o1.OrderDate.CompareTo(o2.OrderDate));
                    Console.WriteLine("Orders sorted by Order Date.");
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void ExportOrders()
        {
            Console.Write("\nEnter file path to export orders: ");
            string filePath = Console.ReadLine();

            try
            {
                orderService.ExportToFile(filePath);
                Console.WriteLine("Orders exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting orders: {ex.Message}");
            }
        }

        static void ImportOrders()
        {
            Console.Write("\nEnter file path to import orders: ");
            string filePath = Console.ReadLine();

            try
            {
                orderService.ImportFromFile(filePath);
                Console.WriteLine("Orders imported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error importing orders: {ex.Message}");
            }
        }
    }
}
