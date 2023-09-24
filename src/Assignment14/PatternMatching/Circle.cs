namespace PatternMatching
{
    /// <summary>
    /// Circle Class
    /// </summary>
    public class Circle : Shape
    {
        /// <summary>
        /// It returns the area of circle by the formula of 𝞹*(r^2)
        /// </summary>
        /// <returns>It returns the double type of the answer from the above formula</returns>
        public override double CalculateArea()
        {
            return Math.Round(Math.PI * Math.Pow(this.Input1, 2), 2);
        }
    }
}
