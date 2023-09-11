namespace Shape_Hierarchy
{
    /// <summary>
    /// Circle Class
    /// </summary>
    internal class Circle : Shape
    {
        /// <summary>
        /// It returns the area of circle by the formula of 𝞹*(r^2)
        /// </summary>
        /// <returns>It returns the double type of the answer from the above formula</returns>
        public override double CalculateArea()
        {
            return Math.PI * Math.Pow(this.Input1, 2);
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
