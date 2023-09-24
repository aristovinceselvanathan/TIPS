namespace PatternMatching
{
    /// <summary>
    /// Rectangle class
    /// </summary>
    public class Rectangle : Shape
    {
        /// <summary>
        /// It returns the area of rectangle by formula length * breath
        /// </summary>
        /// <returns>It returns the double type of the answer from the formula</returns>
        public override double CalculateArea()
        {
            return Math.Round(this.Input1 * this.Input2, 2);
        }
    }
}
