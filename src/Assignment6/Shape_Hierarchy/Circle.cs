namespace Shape_Hierarchy
{
    /// <summary>
    /// Circle Class that inherits the Shape class
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Circle"/> class.
        /// It calls the base class constructor and pass the parameter
        /// It just prints the It is a Circle Class
        /// </summary>
        /// <param name="colour">It takes the colour as the string</param>
        /// <param name="radius">It takes the radius as the double</param>
        public Circle(string colour, double radius)
            : base(colour, radius)
        {
            Console.WriteLine("It is a Circle Class");
        }

        /// <summary>
        /// It returns the area of circle by the formula of 𝞹*(r^2)
        /// </summary>
        /// <returns>It returns the double</returns>
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Input1, 2);
        }

        /// <summary>
        /// It prints the colour, area, name of the shape
        /// </summary>
        public override void PrintDetails()
        {
            var temp = this.GetType().Name;
            double area = this.CalculateArea();
            Console.WriteLine($"Colour is {this.Colour}");
            Console.WriteLine($"Area is {area} cm²");
            Console.WriteLine($"Shape is {temp}");
        }
    }
}
