namespace Shape_Hierarchy
{
    /// <summary>
    /// Rectangle class that inherits the shape class
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// It calls the base calls and pass the parameter.
        /// It prints It is a Rectangle Class
        /// </summary>
        /// <param name="colour">It takes the colour as a string</param>
        /// <param name="length"> It takes the length as a double</param>
        /// <param name="breath">It takes the breath as a double</param>
        public Rectangle(string colour, double length, double breath)
            : base(colour, length, breath)
        {
            Console.WriteLine("It is a Rectangle Class");
        }

        /// <summary>
        /// It returns the area of rectangle by formula length * breath
        /// </summary>
        /// <returns>It returns the double</returns>
        public override double CalculateArea()
        {
            return this.Input1 * this.Input2;
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
