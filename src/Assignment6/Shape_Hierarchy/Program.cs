namespace Shape_Hierarchy
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method takes the colour, radius for circle and colour, length, breath for Rectangle
        /// It prints the details of each shape
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            string colorc, colorr, m1, m2, m3;
            double radius, length, breath;

            Console.WriteLine("Colour of the Circle : ");
            colorc = ChecksStringIsNull(Console.ReadLine());
            Console.WriteLine("Enter the radius of the circle (cm): ");
            m1 = ChecksStringIsNull(Console.ReadLine());

            if (double.TryParse(m1, out radius) && IsColor(colorc))
            {
                Circle c1 = new Circle(colorc, radius);
                c1.PrintDetails();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            Console.WriteLine("Colour of the Rectangle : ");
            colorr = ChecksStringIsNull(Console.ReadLine());
            Console.WriteLine("Enter the length of the rectangle (cm): ");
            m2 = ChecksStringIsNull(Console.ReadLine());
            Console.WriteLine("Enter the breath of the rectangle (cm): ");
            m3 = ChecksStringIsNull(Console.ReadLine());

            if (double.TryParse(m2, out length) && double.TryParse(m3, out breath) && IsColor(colorr))
            {
                Rectangle r1 = new Rectangle(colorr, length, breath);
                r1.PrintDetails();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }
        }

        /// <summary>
        /// Method checks for string is null or not
        /// </summary>
        /// <param name="s">It takes the string as the input</param>
        /// <returns>It returns string</returns>
        public static string ChecksStringIsNull(string? s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return " ";
            }
            else
            {
                return s;
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because colour doesn't contains any number
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsColor(string s)
        {
            Regex r = new Regex("^[a-zA-Z'-]+$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
