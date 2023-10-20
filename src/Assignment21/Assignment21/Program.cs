namespace Assignment21
{
    using System.Reflection;
    using System.Text.RegularExpressions;
    /// <summary>
    /// Program Class contains the entry point of the program
    /// </summary>
    internal class Program
    {
        private enum Options
        {
            AssemblyMetaData = 1,
            DynamicObjectInspector = 2,
            DynamicMethodInvoker = 3,
            PluginSystem = 4,
            MockingFramework = 5,
            SerializationAPI = 6,
        }

        private enum LoadFile
        {
            LoadFromTheFile = 1,
            UseDefaultFile = 2,
        }

        private enum ChooseDLL
        {
            Application1 = 1,
            Application2 = 2,
        }

        /// <summary>
        /// I
        /// </summary>
        /// <param name="args">String array in the parameters of the ma</param>
        public static void Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Welcome to Reflection");
                Console.Write("\n1.Inspect Assembly Metadata\n2.Dynamic Object Inspector\n3.Dynamic Method Invoker\n4.Plugin System\n5.Mocking System\n6.Serialization API\nEnter the Choice : ");
                if (int.TryParse(Console.ReadLine(), out int userChoice))
                {
                    Options options = (Options)userChoice;
                    switch (options)
                    {
                        case Options.AssemblyMetaData:
                            AssemblyMetaData();
                            break;
                        case Options.DynamicObjectInspector:
                            DynamicObjectInspector();
                            break;
                        case Options.DynamicMethodInvoker:
                            DynamicMethodInvoker();
                            break;
                        case Options.PluginSystem:
                            PluginSystem();
                            break;
                        case Options.MockingFramework:
                            break;
                        case Options.SerializationAPI:
                            break;
                        default:
                            Console.WriteLine("Exiting...");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Number - Please Enter number between 1 to 6");
                }

                ClearTheUserInput();
            }
        }

        /// <summary>
        /// Print the Meta Data of the Assembly
        /// </summary>
        public static void AssemblyMetaData()
        {
            string assemblyPathFile = string.Empty;
            Console.Write("\n1.Load the Assembly file from file path\n2.Use Sample Assembly File\nEnter the option : ");
            if (int.TryParse(Console.ReadLine(), out int userInput))
            {
                LoadFile loadFile = (LoadFile)userInput;
                switch (loadFile)
                {
                    case LoadFile.LoadFromTheFile:
                        Console.Write("Enter the File Path : ");
                        assemblyPathFile = ValidatePath(Console.ReadLine());
                        LoadTheMetaData(assemblyPathFile);
                        break;
                    case LoadFile.UseDefaultFile:
                        assemblyPathFile = "D:\\TIPS\\src\\Assignment21\\Assignment21\\bin\\Debug\\net6.0\\Assignment21.dll";
                        LoadTheMetaData(assemblyPathFile);
                        break;
                    default:
                        Console.WriteLine("Invalid Input");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Number - Please enter the valid number from 1 to 2");
            }
        }

        /// <summary>
        /// Load the Meta Data from the assembly file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        public static void LoadTheMetaData(string filePath)
        {
            Assembly assemblyMetaData = Assembly.LoadFile(filePath);
            Type[] typeData = assemblyMetaData.GetTypes();
            foreach (var type in typeData)
            {
                DisplayTheTypeDetails(type);
            }
        }

        /// <summary>
        /// Dynamic Object Inspector
        /// </summary>
        /// <param name="filePath">Path of the Assembly file</param>
        public static void DynamicObjectInspector()
        {
            string filePath = "D:\\TIPS\\src\\Assignment21\\Assignment21\\bin\\Debug\\net6.0\\Assignment21.dll";
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            var objectOfTheClass = Activator.CreateInstance(type);
            ReflectionsMethods.ChangeThePropertyOfTheObject(objectOfTheClass);
        }

        /// <summary>
        /// Invoke the Method Dynamically
        /// </summary>
        public static void DynamicMethodInvoker()
        {
            string filePath = "D:\\TIPS\\src\\Assignment21\\Assignment21\\bin\\Debug\\net6.0\\Assignment21.dll";
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            var objectOfTheClass = Activator.CreateInstance(type);
            ReflectionsMethods.InvokeTheMethodFromObject(objectOfTheClass);
        }

        /// <summary>
        /// Plugin System
        /// </summary>
        public static void PluginSystem()
        {
            Dictionary<string, ISampleInterface> plugins = new Dictionary<string, ISampleInterface>();
            ReflectionsMethods.LoadPlugins(plugins);
            foreach (var item in plugins)
            {
                Console.WriteLine($"{item.Key} DLL : ");
                item.Value.PrintWelcomeMessage();
            }

            Console.WriteLine("\nSuccessfully Executed Plugins");
        }

        /// <summary>
        /// Display all the type details of the given type
        /// </summary>
        /// <param name="type">type from the assembly</param>
        public static void DisplayTheTypeDetails(Type type)
        {
            Console.WriteLine($"\nType Name {type.FullName}");
            MethodInfo[] methodsInfo = type.GetMethods();
            Console.WriteLine("\nMethods:\n");
            foreach (MethodInfo methodInfo in methodsInfo)
            {
                Console.Write($"{methodInfo.Name}, ");
            }

            Console.WriteLine("\nFields : \n");
            FieldInfo[] fieldsInfo = type.GetFields();
            foreach (FieldInfo fieldInfo in fieldsInfo)
            {
                Console.Write($"{fieldInfo.Name}, ");
            }

            Console.WriteLine("\nProperty : \n");
            PropertyInfo[] propertiesInfo = type.GetProperties();
            foreach (PropertyInfo propertyInfo in propertiesInfo)
            {
                Console.Write($"{propertyInfo.Name}, ");
            }

            Console.WriteLine("\nEvents : \n");
            EventInfo[] eventsInfo = type.GetEvents();
            foreach (EventInfo eventInfo in eventsInfo)
            {
                Console.Write($"{eventInfo.Name}, ");
            }
        }

        /// <summary>
        /// Ti validate the path of the file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Valid path of the file</returns>
        public static string ValidatePath(string filePath)
        {
            Regex regex = new Regex("^(?!.*[\\\\\\/]\\s+)(?!(?:.*\\s|.*\\.|\\W+)$)(?:[a-zA-Z]:)?(?:(?:[^<>:\"\\|\\?\\*\\n])+(?:\\/\\/|\\/|\\\\\\\\|\\\\)?)+$");
            if (regex.IsMatch(filePath))
            {
                return filePath;
            }
            else
            {
                Console.WriteLine();
                return string.Empty;
            }
        }

        /// <summary>
        /// CLear the User Input
        /// </summary>
        public static void ClearTheUserInput()
        {
            Console.WriteLine("\nPress enter to clear the screen and escape to continue");
            ConsoleKey consoleKey = Console.ReadKey().Key;
            if (consoleKey.Equals(ConsoleKey.Enter))
            {
                Console.Clear();
            }
            else if (consoleKey.Equals(ConsoleKey.Escape))
            {
                return;
            }
            else
            {
                Console.WriteLine("Invalid User Key");
                Console.WriteLine("Press Escape key to Exit");
            }
        }
    }
}