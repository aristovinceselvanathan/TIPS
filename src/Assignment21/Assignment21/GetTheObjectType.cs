using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Assignment21
{
    /// <summary>
    /// Get The Object Type Class
    /// </summary>
    internal class GetTheObjectType
    {
        /// <summary>
        /// Get the input of the type from the user
        /// </summary>
        /// <param name="path">Path of the assembly file</param>
        /// <returns>Type of the object</returns>
        public static Type GetTheTypeOfTheObject(string path)
        {
            Assembly assemblyData = Assembly.LoadFile(path);
            Type[] types = assemblyData.GetTypes();
            List<string> objectNames = types.Select(type => type.Name).ToList();
            string objectName = GetTheAvailableTypeFromTheUser("Enter the Object Name: ", objectNames, "Object Name doesn't exists");
            if (!string.IsNullOrEmpty(objectName))
            {
                return types[objectNames.IndexOf(objectName)];
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// Get the Type that present in the list
        /// </summary>
        /// <param name="userPrompts">Prompts to the user</param>
        /// <param name="objectNames">List consists of the types</param>
        /// <param name="warningMessage">Warning Message to the user</param>
        /// <returns>Object name that is selected</returns>
        public static string GetTheAvailableTypeFromTheUser(string userPrompts, List<string> objectNames, string warningMessage)
        {
            Console.WriteLine($"\nAvailable : [{string.Join(",", objectNames)}]");
            Console.Write($"\n{userPrompts} ");
            string objectName = Console.ReadLine();
            if (!string.IsNullOrEmpty(objectName))
            {
                if (objectNames.Contains(objectName))
                {
                    return objectName;
                }
                else if (objectName.ToLower().Equals("exit"))
                {
                    return string.Empty;
                }
                else
                {
                    Console.WriteLine(warningMessage);
                    objectName = GetTheAvailableTypeFromTheUser(userPrompts, objectNames, warningMessage);
                    return objectName;
                }
            }
            else
            {
                Console.WriteLine("Invalid String - Please Enter the Valid Name\nType Exit to Exit the Window");
                objectName = GetTheAvailableTypeFromTheUser(userPrompts, objectNames, warningMessage);
                return objectName;
            }
        }
    }
}
