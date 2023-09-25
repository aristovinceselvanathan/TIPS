namespace ShapeHierarchy
{
    /// <summary>
    /// Shape abstract class
    /// </summary>
    public abstract class Shape
    {
        /// <summary>
        /// Gets or sets the Colour of the shape
        /// </summary>
        /// <value>string</value>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the Input1 (dimensions of the shape)
        /// </summary>
        /// <value>double</value>
        public double Input1 { get; set; }

        /// <summary>
        /// Gets or sets the Input2 (dimensions of the shape)
        /// </summary>
        /// <value>double</value>
        public double Input2 { get; set; }

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
            Console.WriteLine($"Color is {this.Color}");
            Console.WriteLine($"Area is {area} cm²");
        }
    }
}
