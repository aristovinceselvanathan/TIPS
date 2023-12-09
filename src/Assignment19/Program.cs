namespace Assignment19
{
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Program Class
    /// </summary>
    public class Program
    {
        private enum Options
        {
            AddTags = 1,
            ExtractTags = 2,
            SearchText = 3,
            StopWords = 4,
            TextComparison = 5,
            FindURLS = 6,
            AllTitles = 7,
            Exit = 8,
        }

        /// <summary>
        /// Ask for the operations in string to be performed
        /// </summary>
        /// <param name="args">It is string array in the parameter of the main method</param>
        /// <returns>Task for the asynchronous programming</returns>
        public static async Task Main(string[] args)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Welcome to String Manipulation \n!!!Type Exit in the Console to Exit Anywhere!!!\nType Exit to Exit Application");
                Console.Write("1 - Add Tags\n2 - Extract the Hash Tags\n3 - Search for the text\n4 - Stop Word Analysis\n5 - Text Comparison\n6 - Find URLs\n7 - All Titles\n8 - Exit\nEnter Choice : ");
                string userInput = Console.ReadLine();
                if (int.TryParse(userInput, out int option))
                {
                    Options options = (Options)option;
                    switch (options)
                    {
                        case Options.AddTags:
                            flag = await AddTagsAsync();
                            break;
                        case Options.ExtractTags:
                            List<string> resultTags = await ExtractTagsAsync();
                            Utility.DisplayTheList(resultTags);
                            break;
                        case Options.SearchText:
                            flag = await SearchForQueryOption();
                            break;
                        case Options.StopWords:
                            flag = await StopWordsAsync();
                            break;
                        case Options.TextComparison:
                            flag = await TextComparisonAsync();
                            break;
                        case Options.FindURLS:
                            List<string> resultURLs = await FindAllURLs();
                            Utility.DisplayTheList(resultURLs);
                            break;
                        case Options.AllTitles:
                            Console.WriteLine(Utility.ConcatenateTitle(await Utility.AccessMultipleFilesAsync()));
                            break;
                        case Options.Exit:
                            Console.WriteLine("Are want to exit ? y or n");
                            char userInput1 = Console.ReadLine().ElementAt(0);
                            if (userInput1 == 'y' || userInput1 == 'Y')
                            {
                                Console.WriteLine("Exiting...");
                                flag = false;
                            }
                            break;
                        default:
                            Console.Out.WriteLine("Invalid option - Please enter the option from 1 to 8");
                            break;
                    }
                }
                else if (string.Compare(userInput, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid Number - Enter the number in this range 1 - 7 ");
                }

                Console.WriteLine("Press any key to continue : ");
                Console.ReadKey(false);
                Console.Clear();
            }
        }

        /// <summary>
        /// Add paragraph tags in the blog post
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<bool> AddTagsAsync()
        {
            int pathNumber1 = 0;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                List<string> tags = await Utility.AccessMultipleFilesAsync(pathNumber1);
                string data = Utility.FormatPost(tags.ElementAt(0));
                Console.WriteLine($"{data}\n");
            }
            else if (string.Compare(userInput, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid number - In the range of 0 - 340");
                await AddTagsAsync();
            }

            return true;
        }

        /// <summary>
        /// Extract the words consists of the hash tags
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<List<string>> ExtractTagsAsync()
        {
            int pathNumber1 = 0, filesMinIndex = 0, filesMaxIndex = 340;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= filesMinIndex && pathNumber1 <= filesMaxIndex)
            {
                List<string> tags = await Utility.AccessMultipleFilesAsync(pathNumber1);
                List<string> data = Utility.ExtractTags(tags.ElementAt(0));
                return data;
            }
            else if (string.Compare(userInput, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return null;
            }
            else
            {
                Console.WriteLine("\nInvalid number - In the range of 0 - 340");
            }

            return null;
        }

        /// <summary>
        /// Search for the query in all the files
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<bool> SearchForQueryOption()
        {
            Console.Write("\nEnter the Query : ");
            string query = Console.ReadLine();
            if (!query.Equals(string.Empty))
            {
                List<string> output = await Utility.SearchForTheQueryInFiles(query);
                foreach (var item in output)
                {
                    Console.WriteLine($"{item}\n");
                }
            }
            else if (string.Compare(query, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid Query, Please Try with the other query");
            }

            return true;
        }

        /// <summary>
        /// Frequency of the stop words present in the blog post
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<bool> StopWordsAsync()
        {
            int pathNumber1 = 0;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                List<string> tags = await Utility.AccessMultipleFilesAsync(pathNumber1);
                Dictionary<string, int> data = Utility.GetStopWords(tags.ElementAt(0));
                foreach (var d in data)
                {
                    Console.Write($"{d.Key}: {d.Value}, ");
                }

                Console.WriteLine();
            }
            else if (string.Compare(userInput, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid number - In the range of 0 - 340");
            }

            return true;
        }

        /// <summary>
        /// Compare the words that are present in the both the blog post
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<bool> TextComparisonAsync()
        {
            int pathNumber1 = 0, pathNumber2 = 0;
            Console.Write("\nEnter the File Number 1 : ");
            string userInput1 = Console.ReadLine();
            if (int.TryParse(userInput1, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                Console.Write("\nEnter the File Number 2 : ");
                string userInput2 = Console.ReadLine();
                if (int.TryParse(userInput2, out pathNumber2) && pathNumber2 >= 0 && pathNumber2 <= 340 && pathNumber1 != pathNumber2)
                {
                    List<string> tags = await Utility.AccessMultipleFilesAsync(pathNumber1, pathNumber2);
                    double score = Utility.CompareText(tags.ElementAt(0), tags.ElementAt(1));
                    Console.WriteLine($"\nScore is : {score} \n");
                }
                else if (string.Compare(userInput2, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
                {
                    return false;
                }
                else if (pathNumber1 == pathNumber2)
                {
                    Console.WriteLine("\nBoth ath Should not be equal, Try with other paths");
                }
            }
            else if (string.Compare(userInput1, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return false;
            }
            else
            {
                Console.WriteLine("\nInvalid number - In the range of 0 - 340");
            }

            return true;
        }

        /// <summary>
        /// Find all the URLs present in the blog post
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<List<string>> FindAllURLs()
        {
            int pathNumber1 = 0;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                List<string> tags = await Utility.AccessMultipleFilesAsync(pathNumber1);
                List<string> data = Utility.ParseURL(tags.ElementAt(0));
                return data;
            }
            else if (string.Compare(userInput, "exit", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return null;
            }
            else
            {
                Console.WriteLine("\nInvalid number - In the range of 0 - 340");
            }

            return null;
        }
    }
}