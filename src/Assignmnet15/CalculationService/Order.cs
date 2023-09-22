namespace CalculationService
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class describes the order characteristics in order manager
    /// </summary>
    public class Order
    {
        private static int uniqueId = 0;

        private int? _id = 0;

        private string _name;

        private int _quantity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Order"/> class.
        /// </summary>
        /// <param name="name">Name of the Order</param>
        /// <param name="quantity">Quantity of the Order</param>
        /// <param name="id">ID of the Order</param>
        public Order(string name, int quantity, int? id = null)
        {
            this._name = name;
            this._quantity = quantity;
            uniqueId++;
            if (id == null)
            {
                this._id = uniqueId;
            }
            else
            {
                this._id = id;
            }
        }

        /// <summary>
        /// Method will print the details of the order
        /// </summary>
        /// <returns>It return the string of the details of the order</returns>
        public override string ToString()
        {
            return $"Id: {this._id}\nName: {this._name}\nQuantity: {this._quantity}";
        }

        /// <summary>
        /// It take the quantity and set it.
        /// </summary>
        /// <param name="quantity">Quantity of the Product</param>
        public void SetQuantityValue(int quantity)
        {
            this._quantity = quantity;
        }

        /// <summary>
        /// Method is to set the name of the order
        /// </summary>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit)</returns>
        public bool SetName()
        {
            Console.Write("Enter the Name : ");
            string name = Console.ReadLine();
            Regex pattern = new Regex("^[a-zA-Z\\s]+$");
            if (pattern.IsMatch(name))
            {
                this._name = name;
                return false;
            }
            else if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press Escape Key to Exit and Any Other Key to Continue");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return true;
                }

                return this.SetName();
            }
            else
            {
                Console.WriteLine("Invalid Name");
                return this.SetName();
            }
        }

        /// <summary>
        /// Method get the name of the order
        /// </summary>
        /// <returns>It returns string of name</returns>
        public string GetName()
        {
            return this._name;
        }

        /// <summary>
        /// Method returns the ID of the Order
        /// </summary>
        /// <returns>It returns int of the ID</returns>
        public int? GetID()
        {
            return this._id;
        }

        /// <summary>
        /// Method returns the Quantity of the order
        /// </summary>
        /// <returns>It returns int of the Quantity</returns>
        public int GetQuantity()
        {
            return this._quantity;
        }

        /// <summary>
        /// Method is to set the quantity of the order
        /// </summary>
        /// <returns>It return bool type to terminate the execution in between the process (When user wants to exit)</returns>
        public bool SetQuantity()
        {
            Console.Write("Enter the Quantity : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out int quantity))
            {
                this._quantity = quantity;
                return false;
            }
            else if (string.IsNullOrEmpty(userInput))
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Press Escape Key to Exit and Any Other Key to Continue");
                if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    return true;
                }

                return true;
            }
            else
            {
                Console.WriteLine("Invalid Name");
                return this.SetName();
            }
        }

        /// <summary>
        /// Method overrides the equals method in object class
        /// </summary>
        /// <param name="obj"> It uses the instance of the object class</param>
        /// <returns>It returns bool</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Order other = obj as Order;
            if (other == null)
            {
                return false;
            }

            return this._id == other._id;
        }

        /// <summary>
        /// It overrides the GetHashCode when Equals Method overridden in the order class
        /// </summary>
        /// <returns>It returns the Integer</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
