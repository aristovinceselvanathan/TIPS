namespace ShapeHierarchy
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
    }
}
