namespace ShapeHierarchy
{
    /// <summary>
    /// Rectangle class
    /// </summary>
    internal class Rectangle : Shape
    {
        /// <summary>
        /// It returns the area of rectangle by formula length * breath
        /// </summary>
        /// <returns>It returns the double type of the answer from the formula</returns>
        public override double CalculateArea()
        {
            return this.Input1 * this.Input2;
        }

        /// <summary>
        /// It prints the colour, area, name of the shape
        /// </summary>
        public override void PrintDetails()
        {
            Console.WriteLine($"Shape is {this.GetType().Name}");
            Console.WriteLine($"Color is {this.Color}");
            Console.WriteLine($"Area is {this.CalculateArea()} cm²");
        }
    }
}
