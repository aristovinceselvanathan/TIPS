namespace Shape_Hierarchy
{
    using System.Diagnostics;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            Circle = 1,
            Rectangle = 2,
            Exit = 3,
        }

        /// <summary>
        /// Main Method takes the color, radius for the circle and color, length, breadth for the rectangle shapes
        /// It prints the details of each shape
        /// </summary>
        /// <param name="args">It takes the string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Shape item;
            bool flag = true;
            Console.WriteLine("Welcome to Shape Area Calculator");
            while (flag)
            {
                Console.WriteLine("Choose the Shape 1.Circle, 2.Rectangle, 3.Exit : ");
                if (int.TryParse(Console.ReadLine(), out int option))
                {
                    Options selectedOption = (Options)option;
                    switch (selectedOption)
                    {
                        case Options.Circle:
                            item = new Circle();
                            GetDetailsOfShape(item);
                            break;
                        case Options.Rectangle:
                            item = new Rectangle();
                            GetDetailsOfShape(item);
                            break;
                        case Options.Exit:
                            flag = false;
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;
                    }
                }
                else
                {
                    WarningMessageFromConsole("Option - Required number only");
                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();
            }

            Console.WriteLine("Exiting....");
        }

        /// <summary>
        /// Method checks for the string is contains only alphabets
        /// </summary>
        /// <param name="color">It takes the name of color of the shape</param>
        /// <returns>It returns bool about the match the pattern</returns>
        public static bool IsValidNameOfColor(string color)
        {
            Regex r = new Regex("^[a-zA-Z\\s]+$");
            if (r.IsMatch(color))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// It shows the colorful warning message of the invalid input
        /// </summary>
        /// <param name="nameOfEvent">It takes the name of the input</param>
        public static void WarningMessageFromConsole(string nameOfEvent)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfEvent}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// It takes the details about the shape
        /// </summary>
        /// <param name="typeOfShape">It determines the type of the shape</param>
        public static void GetDetailsOfShape(Shape typeOfShape)
        {
            string colorOfShape, userInputOfDimensions1, userInputOfDimensions2;
            double dimensions1OfShape, dimensions2OfShape;

            Console.WriteLine($"Color of the {typeOfShape.GetType().Name}: ");
            colorOfShape = Console.ReadLine();
            if (IsValidNameOfColor(colorOfShape))
            {
                if (typeOfShape.GetType().Name.Equals("Rectangle"))
                {
                    Console.WriteLine("Enter the length of the rectangle (cm): ");
                    userInputOfDimensions1 = Console.ReadLine();
                    if (double.TryParse(userInputOfDimensions1, out dimensions1OfShape) && dimensions1OfShape >= 0)
                    {
                        Console.WriteLine("Enter the breadth of the rectangle (cm): ");
                        userInputOfDimensions2 = Console.ReadLine();
                        if (double.TryParse(userInputOfDimensions2, out dimensions2OfShape) && dimensions2OfShape >= 0)
                        {
                            typeOfShape.Color = colorOfShape;
                            typeOfShape.Input1 = dimensions1OfShape;
                            typeOfShape.Input2 = dimensions2OfShape;
                            typeOfShape.PrintDetails();
                        }
                        else
                        {
                            WarningMessageFromConsole("Breadth of the Rectangle");
                        }
                    }
                    else
                    {
                        WarningMessageFromConsole("Length of the rectangle");
                    }
                }
                else if (typeOfShape.GetType().Name.Equals("Circle"))
                {
                    Console.WriteLine("Enter the radius of the circle (cm): ");
                    userInputOfDimensions1 = Console.ReadLine();
                    if (double.TryParse(userInputOfDimensions1, out dimensions1OfShape) && dimensions1OfShape >= 0)
                    {
                        typeOfShape.Color = colorOfShape;
                        typeOfShape.Input1 = dimensions1OfShape;
                        typeOfShape.PrintDetails();
                    }
                    else
                    {
                        WarningMessageFromConsole("Radius of the circle");
                    }
                }
                else
                {
                    WarningMessageFromConsole("Invalid Shape");
                }
            }
            else
            {
                WarningMessageFromConsole($"Color of the {typeOfShape.GetType().Name}");
            }
        }
    }
}
