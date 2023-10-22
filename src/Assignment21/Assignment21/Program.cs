namespace Assignment21
{
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;

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
        /// Direct to the different reflection concepts
        /// </summary>
        /// <param name="args">String array in the parameters of the main method</param>
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
                            MockingFramework();
                            break;
                        case Options.SerializationAPI:
                            SerializationAPI();
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
            string assemblyPathFile;
            assemblyPathFile = GetTheFilePath();
            LoadTheMetaData(assemblyPathFile);
        }

        /// <summary>
        /// Load the Meta Data from the assembly file
        /// </summary>
        /// <param name="filePath">Path of the assembly file</param>
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
        /// To Change the Property of the object
        /// </summary>
        public static void DynamicObjectInspector()
        {
            string filePath = GetTheFilePath();
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            if (type != null)
            {
                var objectOfTheClass = Activator.CreateInstance(type);
                ReflectionsMethods.ChangeThePropertyOfTheObject(objectOfTheClass);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// To Invoke the Method Dynamically
        /// </summary>
        public static void DynamicMethodInvoker()
        {
            string filePath = GetTheFilePath();
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            if (type != null)
            {
                var objectOfTheClass = Activator.CreateInstance(type);
                ReflectionsMethods.InvokeTheMethodFromObject(objectOfTheClass);
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Plugin System to Load the Different assembler class implements the same interface
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
        /// To mock the interface in the assembly
        /// </summary>
        public static void MockingFramework()
        {
            string filePath = GetTheFilePath();
            Console.WriteLine("\nPlease Select only the interface (starts with I)");
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            if (type != null)
            {
                object userSelectedObject = ReflectionsMethods.CreateMockingInterface(type);
                if (userSelectedObject == null)
                {
                    return;
                }

                Console.WriteLine("\nSelected Interface implemented and mocked successfully");
                Console.WriteLine("\nPress enter to display details of the Mocked Object : ");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                if (consoleKey.Equals(ConsoleKey.Enter))
                {
                    DisplayTheTypeDetails(userSelectedObject.GetType());
                }
                else
                {
                    Console.WriteLine("Invalid Key - Please Enter the Valid Key");
                }
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// To print the object in the serialized manner
        /// </summary>
        public static void SerializationAPI()
        {
            string filePath = GetTheFilePath();
            Console.WriteLine("Select the object : ");
            Type type = GetTheObjectType.GetTheTypeOfTheObject(filePath);
            if (type != null)
            {
                var userSelectedObject = Activator.CreateInstance(type);
                string serializedData = JsonConvert.SerializeObject(userSelectedObject, Formatting.Indented);
                Console.WriteLine($"Serialized Data : {serializedData}");
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Display all the type details of the given type
        /// </summary>
        /// <param name="type">Type from the user selected object</param>
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
        /// To validate the path of the file
        /// </summary>
        /// <param name="filePath">Path of the file</param>
        /// <returns>Valid path of the file</returns>
        public static string ValidatePath(string filePath)
        {
            Regex regex = new Regex("^(?!.*[\\\\\\/]\\s+)(?!(?:.*\\s|.*\\.|\\W+)$)(?:[a-zA-Z]:)?(?:(?:[^<>:\"\\|\\?\\*\\n])+(?:\\/\\/|\\/|\\\\\\\\|\\\\)?)+$");
            if (File.Exists(filePath) && regex.IsMatch(filePath))
            {
                return filePath;
            }
            else
            {
                Console.WriteLine("Invalid File Path - Kindly check the file path");
                return string.Empty;
            }
        }

        /// <summary>
        /// Clear the User Input
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

        /// <summary>
        /// Get the Assembly File DLL Path
        /// </summary>
        /// <returns>File path of the Assembly DLL</returns>
        public static string GetTheFilePath()
        {
            Console.Write("\n1.Enter the Path for Assembly File\n2.Use the Default Assembly file\nEnter the choice: ");
            if (int.TryParse(Console.ReadLine(), out int userOption))
            {
                string assemblyFilePath = string.Empty;
                if (userOption == 1)
                {
                    Console.Write("\nEnter the DLL file path : ");
                    assemblyFilePath = Console.ReadLine();
                    if (!ValidatePath(assemblyFilePath).Equals(string.Empty))
                    {
                        return assemblyFilePath;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }
                else if (userOption == 2)
                {
                    assemblyFilePath = "D:\\TIPS\\src\\Assignment21\\Assignment21\\bin\\Debug\\net6.0\\Assignment21.dll";
                    return assemblyFilePath;
                }
                else
                {
                    Console.WriteLine("Invalid Option - Please Enter Option 1 or 2");
                }
            }
            else
            {
                Console.WriteLine("Invalid User Options- Please Enter the number");
            }

            return string.Empty;
        }
    }
}