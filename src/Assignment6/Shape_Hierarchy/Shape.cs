namespace Shape_Hierarchy
{
    /// <summary>
    /// Shape abstract class
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// It sets the colour, Input1 and Input2
        /// </summary>
        /// <param name="colour">It takes the colour as a string</param>
        /// <param name="input1">It takes the input1 as a integer</param>
        /// <param name="input2">It takes the input2 as a integer</param>
        public Shape(string colour, double input1, double input2 = 0)
        {
            this.Colour = colour;
            this.Input1 = input1;
            this.Input2 = input2;
        }

        /// <summary>
        /// Gets or sets the Colour
        /// </summary>
        /// <value>string</value>
        protected string Colour { get; set; }

        /// <summary>
        /// Gets or sets the Input1
        /// </summary>
        /// <value>double</value>
        protected double Input1 { get; set; }

        /// <summary>
        /// Gets or sets the Input2
        /// </summary>
        /// <value>double</value>
        protected double Input2 { get; set; }

        /// <summary>
        /// Area is the abstract method contains only declaration.
        /// </summary>
        /// <returns>It returns double datatype of the area of the shape</returns>
        public abstract double CalculateArea();

        /// <summary>
        /// It prints the colour, area of the shape
        /// </summary>
        public virtual void PrintDetails()
        {
            double area = this.CalculateArea();
            Console.WriteLine($"Colour is {this.Colour}");
            Console.WriteLine($"Area is {area} cm²");
        }
    }
}
