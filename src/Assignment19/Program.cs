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
                Console.WriteLine("Welcome to String Manipulation \n!!!Type Exit in the Console to Exit Anywhere!!!");
                Console.Write("1 - Add Tags\n2 - Extract the Hash Tags\n3 - Search for the text\n4 - Stop Word Analysis\n5 - Text Comparison\n6 - Find URLs\n7 - All Titles\nEnter Choice : ");
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
                            flag = await ExtractTagsAsync();
                            break;
                        case Options.SearchText:
                            flag = await SearchTextAsync();
                            break;
                        case Options.StopWords:
                            flag = await StopWordsAsync();
                            break;
                        case Options.TextComparison:
                            flag = await TextComparisonAsync();
                            break;
                        case Options.FindURLS:
                            flag = await FindAllURLs();
                            break;
                        case Options.AllTitles:
                            Console.WriteLine(ConcatenateTitle(await AccessMultipleFiles()));
                            break;
                        default:
                            Console.WriteLine("Are want to exit ? y or n");
                            char userInput1 = Console.ReadLine().ElementAt(0);
                            if (userInput1 == 'y' || userInput1 == 'Y')
                            {
                                Console.WriteLine("Exiting...");
                                flag = false;
                            }

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
                List<string> tags = await AccessMultipleFiles(pathNumber1);
                string data = FormatPost(tags.ElementAt(0));
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
        public static async Task<bool> ExtractTagsAsync()
        {
            int pathNumber1 = 0;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                List<string> tags = await AccessMultipleFiles(pathNumber1);
                List<string> data = ExtractTags(tags.ElementAt(0));
                foreach (var d in data)
                {
                    Console.Write($"{d}, ");
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
                await ExtractTagsAsync();
            }

            return true;
        }

        /// <summary>
        /// Search for the query in all the files
        /// </summary>
        /// <returns>Task for the Asynchronous Programming</returns>
        public static async Task<bool> SearchTextAsync()
        {
            Console.Write("\nEnter the Query : ");
            string query = Console.ReadLine();
            if (!query.Equals(string.Empty))
            {
                List<string> output = await SearchForTextAsync(query);
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
                List<string> tags = await AccessMultipleFiles(pathNumber1);
                Dictionary<string, int> data = GetStopWords(tags.ElementAt(0));
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
                    List<string> tags = await AccessMultipleFiles(pathNumber1, pathNumber2);
                    double score = CompareText(tags.ElementAt(0), tags.ElementAt(1));
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
        public static async Task<bool> FindAllURLs()
        {
            int pathNumber1 = 0;
            Console.Write("\nEnter the File Number : ");
            string userInput = Console.ReadLine();
            if (int.TryParse(userInput, out pathNumber1) && pathNumber1 >= 0 && pathNumber1 <= 340)
            {
                List<string> tags = await AccessMultipleFiles(pathNumber1);
                List<string> data = ParseURL(tags.ElementAt(0));
                foreach (var d in data)
                {
                    Console.Write($"{d}, ");
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
        /// Get the stop words frequency from the post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>Frequency of the stop words in blog post</returns>
        public static Dictionary<string, int> GetStopWords(string post)
        {
            List<string> wordsOfDocument = new ();
            Dictionary<string, int> frequencyOfWords = new ();
            using (var sw = new StreamReader("StopWords.txt"))
            {
                for (int i = 0; i < 173; i++)
                {
                    wordsOfDocument.Add(sw.ReadLine());
                }
            }

            foreach (var word in post.Split(" "))
            {
                if (wordsOfDocument.Contains(word.ToLower()))
                {
                    if (frequencyOfWords.ContainsKey(word.ToLower()))
                    {
                        frequencyOfWords[word] += 1;
                    }
                    else
                    {
                        frequencyOfWords[word] = 1;
                    }
                }
            }

            return frequencyOfWords;
        }

        /// <summary>
        /// Read The Multiple Files using stream reader
        /// </summary>
        /// <param name="pathPosition1">Path Position of the blog post1</param>
        /// <param name="pathPosition2">Path Position of the blog post2</param>
        /// <param name="dataRequired">Return the data or path of the files</param>
        /// <returns>Task of the List consists of the data  or path of the post</returns>
        public static async Task<List<string>> AccessMultipleFiles(int? pathPosition1 = null, int? pathPosition2 = null, bool dataRequired = false)
        {
            List<string> htmlDocument = new List<string>();
            List<string> filePaths = new List<string>();
            if (pathPosition1 == null && pathPosition2 == null)
            {
                filePaths.AddRange(Directory.GetFiles("SW"));
                foreach (var item in filePaths)
                {
                    htmlDocument.Add(await ReadTheFile(item));
                }

                if (dataRequired)
                {
                    return htmlDocument;
                }

                return filePaths;
            }
            else if (pathPosition1 != null && pathPosition2 == null)
            {
                htmlDocument.Add(await ReadTheFile($"SW\\{pathPosition1}.txt"));
            }
            else
            {
                htmlDocument.Add(await ReadTheFile($"SW\\{pathPosition1}.txt"));
                htmlDocument.Add(await ReadTheFile($"SW\\{pathPosition2}.txt"));
            }

            return htmlDocument;
        }

        /// <summary>
        /// Read the file using the stream reader
        /// </summary>
        /// <param name="path">Path of the file to be accessed</param>
        /// <returns>Task of the HTML document data</returns>
        public static async Task<string> ReadTheFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return await sr.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Write the file using the stream Writer
        /// </summary>
        /// <param name="path">Path of the file to be modified</param>
        /// <param name="data">Data to be written in the file</param>
        /// <returns>Task object for asynchronous programming</returns>
        public static async Task WriteTheFile(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(data);
            }
        }

        /// <summary>
        /// Format the post by adding the paragraphs tags in blog post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>Modified string content replaced by the tags</returns>
        public static string FormatPost(string post)
        {
            StringBuilder stringBuilder = new StringBuilder(post.Trim());
            stringBuilder.Replace("\n\n", "<br>");
            stringBuilder.Replace("\n", "<p></p>");
            return stringBuilder.ToString();
        }

        /// <summary>
        /// Extract the tags from the blog post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>List of the hashtag words present in the content</returns>
        public static List<string> ExtractTags(string post)
        {
            List<string> hashTagWords = new List<string>();
            Regex pattern = new Regex("#\\S+");
            MatchCollection match = pattern.Matches(post);
            foreach (Match name in match)
            {
                hashTagWords.Add(name.Value);
            }

            return hashTagWords;
        }

        /// <summary>
        /// Search for the text in the given blog post
        /// </summary>
        /// <param name="query">Query to search in the blog post</param>
        /// <returns>List of all post consists of the data</returns>
        public static async Task<List<string>> SearchForTextAsync(string query)
        {
            List<string> dataOfTheFiles = await AccessMultipleFiles(null, null, true);
            List<string> filesConsistsOfTheData = new List<string>();
            Regex regex = new Regex(query);
            for (int i = 0; i < dataOfTheFiles.Count; i++)
            {
                if (regex.IsMatch(dataOfTheFiles.ElementAt(i)))
                {
                    filesConsistsOfTheData.Add($"SW\\{i}.txt");
                }
            }

            return filesConsistsOfTheData;
        }

        /// <summary>
        /// Score based on the common words in the both the blog post
        /// </summary>
        /// <param name="post1">HTML Document of the blog post 1</param>
        /// <param name="post2">HTML Document of the blog post 2</param>
        /// <returns>Score of the comparison</returns>
        public static double CompareText(string post1, string post2)
        {
            float count = 0;
            List<string> document1 = new List<string>(post1.ToLower().Split(" "));
            List<string> document2 = new List<string>(post2.ToLower().Split(" "));
            foreach (string word in document1)
            {
                if (document2.Contains(word))
                {
                    count++;
                }
            }

            return Math.Round(count / (float)(document1.Count + document2.Count), 2);
        }

        /// <summary>
        /// Take URLS from the given blog post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>List consists of the URLS present in the post</returns>
        public static List<string> ParseURL(string post)
        {
            List<string> listOfTheURLS = new List<string>();
            Regex regex = new Regex("[(http(s)?):\\/\\/(www\\.)?a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)");
            var match = regex.Matches(post);
            foreach (Match word in match)
            {
                listOfTheURLS.Add(word.ToString());
            }
            return listOfTheURLS;
        }

        /// <summary>
        /// Concatenate the titles in the all files
        /// </summary>
        /// <param name="filePaths">Consists of the all files in the directory</param>
        /// <returns>Concatenated string of the all titles</returns>
        public static string ConcatenateTitle(List<string> filePaths)
        {
            StringBuilder allFilesTiles = new StringBuilder();
            Regex regex = new Regex("<title>(.*?)</title>|<TITLE>(.*?)</TITLE>");
            foreach (var path in filePaths)
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string line = streamReader.ReadToEnd();
                    var match = regex.Matches(line);
                    foreach (Match match1 in match)
                    {
                        string result = match1.Value.ToString();
                        allFilesTiles.Append($"{result.Substring(7, result.Length - 15)}, ");
                    }
                }
            }

            Console.WriteLine(allFilesTiles.ToString());
            return allFilesTiles.ToString();
        }
    }
}