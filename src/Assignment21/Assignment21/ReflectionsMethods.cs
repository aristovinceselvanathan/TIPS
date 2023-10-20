namespace Assignment21
{
    using System.Reflection;
    /// <summary>
    /// Reflections Methods Class
    /// </summary>
    internal class ReflectionsMethods
    {
        /// <summary>
        /// Change The property of The Object
        /// </summary>
        /// <param name="selectedObject">USer Selected Object</param>
        public static void ChangeThePropertyOfTheObject(object selectedObject)
        {
            Type type = selectedObject.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();
            List<string> propertiesName = propertyInfo.Select(property => property.Name).ToList();
            string selectedPropertyName = GetTheObjectType.GetTheAvailableTypeFromTheUser("Enter the Property :", propertiesName, "Property Name doesn't exists");
            Console.Write($"\nEnter the Value for {selectedPropertyName} : ");
            string valueOfTheProperty = Console.ReadLine();

            PropertyInfo propertyToSet = propertyInfo[propertiesName.IndexOf(selectedPropertyName)];
            var changedType = Convert.ChangeType(valueOfTheProperty, propertyToSet.PropertyType);
            propertyToSet.SetValue(selectedObject, changedType);

            Console.WriteLine($"\nProperty : {selectedPropertyName}, Value : {propertyToSet.GetValue(selectedObject)}");
            Console.WriteLine("\nValue Updated Successfully");
        }

        /// <summary>
        /// Invoke the method
        /// </summary>
        /// <param name="selectedObject">USer Selected Object</param>
        public static void InvokeTheMethodFromObject(object selectedObject)
        {
            Type type = selectedObject.GetType();
            MethodInfo[] methodsInfo = type.GetMethods();
            List<string> methodsName = methodsInfo.Select(method => method.Name).ToList();
            string selectedMethodName = GetTheObjectType.GetTheAvailableTypeFromTheUser("Enter the Property :", methodsName, "Property Name doesn't exists");

            MethodInfo methodToInvoke = methodsInfo[methodsName.IndexOf(selectedMethodName)];
            var parameterList = methodToInvoke.GetParameters();
            List<object> userInputValue = new List<object>();
            foreach (var parameter in parameterList)
            {
                Console.Write($"\nEnter {parameter.Name} value : ");
                string userInput = Console.ReadLine();
                userInputValue.Add(Convert.ChangeType(userInput, parameter.ParameterType));
            }

            var functionOutput = methodToInvoke.Invoke(selectedObject, userInputValue.ToArray());
            Console.WriteLine($"\nReturned Value : {functionOutput}");
            Console.WriteLine("\nFunction Invoked Successfully");
        }

        /// <summary>
        /// TO Load The Plugins
        /// </summary>
        /// <param name="plugins">Dictionary COnsists of the Path and </param>
        public static void LoadPlugins(Dictionary<string, ISampleInterface> plugins)
        {
            Console.WriteLine();
            string dllPath = "D:\\TIPS\\src\\Assignment21\\Assignment21\\SampleDLL\\";
            foreach (var plugin in Directory.GetFiles(dllPath, "*.dll"))
            {
                Assembly assemblyData = Assembly.LoadFile(plugin);
                Type[] pluginArray = assemblyData.GetTypes().Where(pluginType => pluginType.GetInterface("ISampleInterface", true) != null).ToArray();
                foreach (Type pluginType in pluginArray)
                {
                    var pluginObject = Activator.CreateInstance(pluginType) as ISampleInterface;
                    plugins.Add(plugin, pluginObject);
                }
            }
        }
    }
}
