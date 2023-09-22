namespace CalculationService
{
    using ConsoleTables;

    /// <summary>
    /// OrderService Class
    /// </summary>
    internal class OrderService
    {
        private enum Options
        {
            Order = 1,
            Cancel = 2,
            Update = 3,
            Display = 4,
            Exit = 5,
        }

        private enum Choices
        {
            Name = 1,
            Quantity = 2,
            Exit = 3,
        }

        /// <summary>
        /// Order the product from the Stock present in the Grocery Store
        /// </summary>
        /// <param name="orderStockList">It takes the reference of the list of stock that are available</param>
        /// <param name="userOrderList">It takes the reference of the list that contains user ordered products</param>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit) </returns>
        public static bool Order(List<Order> orderStockList, List<Order> userOrderList)
        {
            Display(orderStockList);
            Console.Write("Enter the order Id to order : ");
            if (int.TryParse(Console.ReadLine(), out int userSelectedId) && userSelectedId > 0 && userSelectedId <= orderStockList.Count)
            {
                Console.Write("Enter the Quantity to Purchase : ");
                if (int.TryParse(Console.ReadLine(), out int quantity))
                {
                    Order selectedOrder = orderStockList.ElementAt(userSelectedId - 1);
                    if (selectedOrder.GetQuantity() - quantity < 0)
                    {
                        if (selectedOrder.GetQuantity() != 0)
                        {
                            Console.WriteLine("Out Of Quantity");
                            Console.Write("Buy all the quantity that are available : y or n ");
                            string userChoice = Console.ReadLine();
                            if (string.Equals(userChoice, "y", StringComparison.InvariantCultureIgnoreCase))
                            {
                                userOrderList.Add(new Order(selectedOrder.GetName(), selectedOrder.GetQuantity(), userSelectedId));
                                selectedOrder.SetQuantityValue(0);
                                Console.WriteLine("Order Placed Successfully");
                            }
                            else
                            {
                                Console.WriteLine("Discarding the Operation");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Out Of Stock");
                        }
                    }
                    else
                    {
                        selectedOrder.SetQuantityValue(selectedOrder.GetQuantity() - quantity);
                        userOrderList.Add(new Order(selectedOrder.GetName(), quantity, userSelectedId));
                        Console.WriteLine("Order Placed Successfully");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            return false;
        }

        /// <summary>
        /// Cancel the order that the user ordered by the user id
        /// </summary>
        /// <param name="userOrderList">It takes the reference of the list of user ordered products</param>
        /// <param name="orderStockList">It takes the reference of the list of stock that are available</param>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit)e</returns>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit)</returns>
        public static bool Cancel(List<Order> userOrderList, List<Order> orderStockList)
        {
            Display(userOrderList);
            Console.Write("Enter the id of the order to be canceled : ");
            if (int.TryParse(Console.ReadLine(), out int id) && id > 0 && id <= userOrderList.Count)
            {
                orderStockList.ElementAt(id - 1).SetQuantityValue(orderStockList.ElementAt(id - 1).GetQuantity() + userOrderList.ElementAt(id - 1).GetQuantity());
                userOrderList.ElementAt(id - 1).SetQuantityValue(0);
                Console.WriteLine("Order Cancelled Successfully");
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            return false;
        }

        /// <summary>
        /// Update the products details that are present in the stock of the grocery
        /// </summary>
        /// <param name="orderStockList">It takes the reference of the list of stock that are available</param>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit)</returns>
        public static bool Update(List<Order> orderStockList)
        {
            Display(orderStockList);
            Console.Write("Enter the id of the order to be canceled : ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Whether you want update the 1 - Name, 2 - Quantity 3 - Exit: ");
                if (int.TryParse(Console.ReadLine(), out int userInputChoice))
                {
                    Choices choices = (Choices)userInputChoice;
                    switch (choices)
                    {
                        case Choices.Name:
                            orderStockList.ElementAt(id - 1).SetName();
                            Console.WriteLine("Order Details are Updated");
                            break;
                        case Choices.Quantity:
                            orderStockList.ElementAt(id - 1).SetQuantity();
                            Console.WriteLine("Order Details are Updated");
                            break;
                        case Choices.Exit:
                            return true;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            return false;
        }

        /// <summary>
        /// Display all the stocks that are present in the grocery
        /// </summary>
        /// <param name="listOfOrderDisplay">It takes the reference of the list to be displayed</param>
        public static void Display(List<Order> listOfOrderDisplay)
        {
            ConsoleTable table = new ConsoleTable("ID", "Order Name", "Quantity");
            foreach (var order in listOfOrderDisplay)
            {
                table.AddRow(order.GetID(), order.GetName(), order.GetQuantity());
            }

            table.Write(Format.MarkDown);
        }

        /// <summary>
        /// Order Service that provide the all user actions to perform add, cancel, update, display all.
        /// </summary>
        public void UserInterfaceOfOrderService()
        {
            List<Order> orderList = new List<Order>();
            List<Order> userOrderList = new List<Order>();
            orderList.Add(new Order("Bread", 4));
            orderList.Add(new Order("Milk", 10));
            orderList.Add(new Order("NewsPaper", 8));
            orderList.Add(new Order("Biscuits", 5));
            orderList.Add(new Order("Juice", 7));
            bool flag = true;

            while (flag)
            {
                Console.WriteLine("Welcome to the Order management");
                Console.WriteLine("Enter the Choice 1.Order 2.Cancel the Order 3.Update the order 4.Display all the order 5.Exit");
                if (int.TryParse(Console.ReadLine(), out int userInputOption))
                {
                    Options options = (Options)userInputOption;
                    switch (options)
                    {
                        case Options.Order:
                            if (Order(orderList, userOrderList))
                            {
                                flag = false;
                            }

                            break;
                        case Options.Cancel:
                            if (Cancel(userOrderList, orderList))
                            {
                                flag = false;
                            }

                            break;
                        case Options.Update:
                            if (Update(orderList))
                            {
                                flag = false;
                            }

                            break;
                        case Options.Display:
                            Display(orderList);
                            break;
                        case Options.Exit:
                            flag = false;
                            break;
                    }
                }

                if (flag)
                {
                    Console.WriteLine("Press Escape to Exit or Press Any other Key to Continue : ");
                    if (Console.ReadKey().Key == ConsoleKey.Escape)
                    {
                        flag = false;
                    }
                }

                Console.WriteLine();
                Console.Clear();
            }
        }
    }
}
