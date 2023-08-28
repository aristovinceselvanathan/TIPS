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
            string colorcircle, colorrectangle, isDouble1, isDouble2, isDouble3;
            double radius, length, breath;

            Console.WriteLine("Colour of the Circle : ");
            colorcircle = Console.ReadLine();
            if (IsColor(colorcircle))
            {
                Console.WriteLine("Enter the radius of the circle (cm): ");
                isDouble1 = Console.ReadLine();

                if (double.TryParse(isDouble1, out radius))
                {
                    Circle c1 = new Circle(colorcircle, radius);
                    c1.PrintDetails();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }

            Console.WriteLine("Colour of the Rectangle : ");
            colorrectangle = Console.ReadLine();
            if (IsColor(colorrectangle))
            {
                Console.WriteLine("Enter the length of the rectangle (cm): ");
                isDouble2 = Console.ReadLine();
                Console.WriteLine("Enter the breath of the rectangle (cm): ");
                isDouble3 = Console.ReadLine();

                if (double.TryParse(isDouble2, out length))
                {
                    if (double.TryParse(isDouble3, out breath))
                    {
                        Rectangle r1 = new Rectangle(colorrectangle, length, breath);
                        r1.PrintDetails();
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }
            else
            {
                Console.WriteLine("Invalid Name");
            }
        }

        /// <summary>
        /// Method checks for the string is number or not because colour doesn't contains any number
        /// </summary>
        /// <param name="s">It takes the string as input</param>
        /// <returns>It returns bool</returns>
        public static bool IsColor(string s)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(s))
            {
                return true;
            }

            return false;
        }
    }
}
