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
            string? colorc, colorr, m1, m2, m3;
            double radius, length, breath;
            Console.WriteLine("Colour of the Circle : ");
            colorc = NullException(Console.ReadLine());
            Console.WriteLine("Enter the radius of the circle (cm): ");
            m1 = NullException(Console.ReadLine());
            Console.WriteLine("Colour of the Rectangle : ");
            colorr = NullException(Console.ReadLine());
            Console.WriteLine("Enter the length of the rectangle (cm): ");
            m2 = NullException(Console.ReadLine());
            Console.WriteLine("Enter the breath of the rectangle (cm): ");
            m3 = NullException(Console.ReadLine());
            if (IsDecimal(m1) && IsColor(colorc))
            {
                radius = Convert.ToDouble(m1);
                Circle c1 = new Circle(colorc, radius);
                c1.PrintDetails();
            }
            else
            {
                Console.WriteLine("Invalid Input");
            }

            if (IsDecimal(m2) && IsColor(colorr))
            {
                length = Convert.ToDouble(m2);
                breath = Convert.ToDouble(m3);
                Rectangle r1 = new Rectangle(colorr, length, breath);
                r1.PrintDetails();
            }
            else
            {
                Console.WriteLine("Invalid Details");
            }
        }

        /// <summary>
        /// Method checks for string is null or not
        /// </summary>
        /// <param name="s">It takes the string as the input</param>
        /// <returns>It returns string</returns>
        public static string NullException(string? s)
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
        /// Method checks for the input is valid decimal
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns boolean</returns>
        public static bool IsDecimal(string s)
        {
            Regex r = new Regex("^\\d+\\.?\\d*$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
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
