namespace Shape_Hierarchy
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main Method takes the colour, radius for the circle and colour, length, breath for the rectangle shapes
        /// It prints the details of each shape
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            string colorOfCircle, colorOfRectangle, isDoubleOfRadius, isDoubleOfRectangle, isDoubleOfBreath;
            double radiusOfCircle, lengthOfRectangle, breathOfRectangle;

            Console.WriteLine("Colour of the Circle : ");
            colorOfCircle = Console.ReadLine();
            if (IsColorName(colorOfCircle))
            {
                Console.WriteLine("Enter the radius of the circle (cm): ");
                isDoubleOfRadius = Console.ReadLine();

                if (double.TryParse(isDoubleOfRadius, out radiusOfCircle))
                {
                    Circle c1 = new Circle(colorOfCircle, radiusOfCircle);
                    c1.PrintDetails();
                }
                else
                {
                    InvalidWarning("Radius of the Circle");
                }
            }
            else
            {
                InvalidWarning("Color of the Circle");
            }

            Console.WriteLine("Colour of the Rectangle : ");
            colorOfRectangle = Console.ReadLine();
            if (IsColorName(colorOfRectangle))
            {
                Console.WriteLine("Enter the length of the rectangle (cm): ");
                isDoubleOfRectangle = Console.ReadLine();
                Console.WriteLine("Enter the breath of the rectangle (cm): ");
                isDoubleOfBreath = Console.ReadLine();

                if (double.TryParse(isDoubleOfRectangle, out lengthOfRectangle))
                {
                    if (double.TryParse(isDoubleOfBreath, out breathOfRectangle))
                    {
                        Rectangle r1 = new Rectangle(colorOfRectangle, lengthOfRectangle, breathOfRectangle);
                        r1.PrintDetails();
                    }
                    else
                    {
                        InvalidWarning("Breath of the Rectangle");
                    }
                }
                else
                {
                    InvalidWarning("Length of the Rectangle");
                }
            }
            else
            {
                InvalidWarning("Color of the Rectangle");
            }
        }

        /// <summary>
        /// Method checks for the string is contains only alphabets
        /// </summary>
        /// <param name="s">It takes the name of colour of the shape as input</param>
        /// <returns>It returns bool about the match the pattern</returns>
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
        /// It shows the colourful warning message of the invalid input
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
