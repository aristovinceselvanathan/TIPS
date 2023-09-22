namespace ShapeHierarchy
{
    /// <summary>
    /// Circle Class
    /// </summary>
    internal class Triangle : Shape
    {
        /// <summary>
        /// It returns the area of circle by the formula of 0.5*breath*height
        /// </summary>
        /// <returns>It returns the double type of the answer from the above formula</returns>
        public override double CalculateArea()
        {
            return 0.5 * (this.Input1 * this.Input2);
        }
    }
}
