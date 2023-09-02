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
            string colorCircle, colorRectangle, isDouble1, isDouble2, isDouble3;
            double radius, length, breath;

            Console.WriteLine("Colour of the Circle : ");
            colorCircle = Console.ReadLine();
            if (IsColorName(colorCircle))
            {
                Console.WriteLine("Enter the radius of the circle (cm): ");
                isDouble1 = Console.ReadLine();

                if (double.TryParse(isDouble1, out radius))
                {
                    Circle c1 = new Circle(colorCircle, radius);
                    c1.PrintDetails();
                }
                else
                {
                    InvalidWarning("Radius");
                }
            }
            else
            {
                InvalidWarning("Name of the Circle");
            }

            Console.WriteLine("Colour of the Rectangle : ");
            colorRectangle = Console.ReadLine();
            if (IsColorName(colorRectangle))
            {
                Console.WriteLine("Enter the length of the rectangle (cm): ");
                isDouble2 = Console.ReadLine();
                Console.WriteLine("Enter the breath of the rectangle (cm): ");
                isDouble3 = Console.ReadLine();

                if (double.TryParse(isDouble2, out length))
                {
                    if (double.TryParse(isDouble3, out breath))
                    {
                        Rectangle r1 = new Rectangle(colorRectangle, length, breath);
                        r1.PrintDetails();
                    }
                    else
                    {
                        InvalidWarning("Breath");
                    }
                }
                else
                {
                    InvalidWarning("Length");
                }
            }
            else
            {
                InvalidWarning("Name of the Rectangle");
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because colour doesn't contains any number
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsColorName(string s)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the warning message of the invalid input
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void InvalidWarning(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
