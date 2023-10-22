namespace Assignment21
{
    /// <summary>
    /// Example Assembly
    /// </summary>
    internal class ExampleAssembly
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExampleAssembly"/> class.
        /// </summary>
        public ExampleAssembly()
        {
            this.Name = "Tom Cruse";
            this.Description = "Greatest Movie Actor";
            this.Designation = "Actor";
        }

        /// <summary>
        /// Sample Event
        /// </summary>
        public event EventHandler SampleEvent;

        /// <summary>
        /// Gets or sets Name
        /// </summary>
        /// <value>String</value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Description
        /// </summary>
        /// <value>String</value>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets Designation
        /// </summary>
        /// <value>String</value>
        public string Designation { get; set; }

        /// <summary>
        /// Display the Welcome Message
        /// </summary>
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("Welcome to C# Community");
        }

        /// <summary>
        /// Add the two operands
        /// </summary>
        /// <param name="number1">Operand 1</param>
        /// <param name="number2">Operand 2</param>
        /// <returns>Sum of the Both Operands</returns>
        public static int AddTwoNumbers(int number1, int number2)
        {
            return number1 + number2;
        }

        /// <summary>
        /// Invoke the Event
        /// </summary>
        public void InvokeTheEvent()
        {
            this.SampleEvent.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Display Details of the Property
        /// </summary>
        public void DisplayProperties()
        {
            Console.WriteLine($"Name : {this.Name}");
            Console.WriteLine($"Description : {this.Description}");
            Console.WriteLine($"Designation : {this.Designation}");
        }
    }
}
