namespace Assignment21
{
    using System.Reflection;
    using System.Reflection.Emit;

    /// <summary>
    /// Reflections Methods Class
    /// </summary>
    internal class ReflectionsMethods
    {
        /// <summary>
        /// Change The property of The Object
        /// </summary>
        /// <param name="selectedObject">User Selected Object to be processed</param>
        public static void ChangeThePropertyOfTheObject(object selectedObject)
        {
            Type type = selectedObject.GetType();
            PropertyInfo[] propertyInfo = type.GetProperties();
            List<string> propertiesName = propertyInfo.Select(property => property.Name).ToList();
            string selectedPropertyName = GetTheObjectType.GetTheAvailableTypeFromTheUser("Enter the Property :", propertiesName, "Property Name doesn't exists");
            if (string.IsNullOrEmpty(selectedPropertyName))
            {
                Console.Write($"\nEnter the Value for {selectedPropertyName} : ");
                string valueOfTheProperty = Console.ReadLine();

                PropertyInfo propertyToSet = propertyInfo[propertiesName.IndexOf(selectedPropertyName)];
                var changedType = Convert.ChangeType(valueOfTheProperty, propertyToSet.PropertyType);
                propertyToSet.SetValue(selectedObject, changedType);

                Console.WriteLine($"\nProperty : {selectedPropertyName}, Value : {propertyToSet.GetValue(selectedObject)}");
                Console.WriteLine("\nValue Updated Successfully");
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// Invoke the method by using the reflection
        /// </summary>
        /// <param name="selectedObject">User Selected Object to be processed</param>
        public static void InvokeTheMethodFromObject(object selectedObject)
        {
            Type type = selectedObject.GetType();
            MethodInfo[] methodsInfo = type.GetMethods();
            List<string> methodsName = methodsInfo.Select(method => method.Name).ToList();
            string selectedMethodName = GetTheObjectType.GetTheAvailableTypeFromTheUser("Enter the Property :", methodsName, "Property Name doesn't exists");
            if (string.IsNullOrEmpty(selectedMethodName))
            {
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
            else
            {
                return;
            }
        }

        /// <summary>
        /// To Load The Plugins in different assembler
        /// </summary>
        /// <param name="plugins">Dictionary Consists of the Path and the ISampleInterface to hold the object of the assembler</param>
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

        /// <summary>
        /// Create the Mocking System for the Interface
        /// </summary>
        /// <param name="interfaceObject">Interface to be mocked</param>
        /// <returns>The Dynamic Mocked Object</returns>
        public static object CreateMockingInterface(Type interfaceObject)
        {
            if (!interfaceObject.IsInterface)
            {
                Console.WriteLine("Invalid Interface");
                return null;
            }

            Console.WriteLine("Information about the Selected Interface : ");
            Program.DisplayTheTypeDetails(interfaceObject);

            AssemblyName assemblyName = new AssemblyName("MockingAssembly");
            AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
            ModuleBuilder moduleBuilder = assemblyBuilder.DefineDynamicModule("DynamicMockingModule");

            TypeBuilder typeBuilder = moduleBuilder.DefineType("MockingTypeBuilder", TypeAttributes.Class | TypeAttributes.Public);
            typeBuilder.AddInterfaceImplementation(interfaceObject);

            ConstructorBuilder constructorBuilder = typeBuilder.DefineDefaultConstructor(MethodAttributes.Public);

            foreach (var method in interfaceObject.GetMethods())
            {
                MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                    method.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    method.ReturnType,
                    method.GetParameters().Select(parameter => parameter.ParameterType).ToArray());

                ILGenerator ilGenerator = methodBuilder.GetILGenerator();
                if (method.ReturnType.IsValueType)
                {
                    ilGenerator.Emit(OpCodes.Ldc_I4_0);
                }
                else
                {
                    ilGenerator.Emit(OpCodes.Ldnull);
                }

                ilGenerator.Emit(OpCodes.Ret);
                typeBuilder.DefineMethodOverride(methodBuilder, method);
            }

            Type dynamicType = typeBuilder.CreateType();
            object dynamicTypeInstance = Activator.CreateInstance(dynamicType);
            return dynamicTypeInstance;
        }
    }
}
