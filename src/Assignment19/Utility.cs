using System.Text;
using System.Text.RegularExpressions;

namespace Assignment19
{
    /// <summary>
    /// Utility class
    /// </summary>
    public static class Utility
    {
        /// <summary>
        /// Read The Multiple Files using stream reader
        /// </summary>
        /// <param name="pathPosition1">Path Position of the blog post1</param>
        /// <param name="pathPosition2">Path Position of the blog post2</param>
        /// <param name="dataRequired">Return the data or path of the files</param>
        /// <returns>Task of the List consists of the data of the post</returns>
        public static async Task<List<string>> AccessMultipleFilesAsync(int? pathPosition1 = null, int? pathPosition2 = null, bool dataRequired = false)
        {
            List<string> htmlDocument = new List<string>();
            List<string> filePaths = new List<string>();
            if (pathPosition1 == null && pathPosition2 == null)
            {
                filePaths.AddRange(Directory.GetFiles("SW"));
                foreach (var item in filePaths)
                {
                    htmlDocument.Add(await FileOperations.ReadTheFile(item));
                }

                if (dataRequired)
                {
                    return htmlDocument;
                }

                return filePaths;
            }
            else if (pathPosition1 != null && pathPosition2 == null)
            {
                htmlDocument.Add(await FileOperations.ReadTheFile($"SW\\{pathPosition1}.txt"));
            }
            else
            {
                htmlDocument.Add(await FileOperations.ReadTheFile($"SW\\{pathPosition1}.txt"));
                htmlDocument.Add(await FileOperations.ReadTheFile($"SW\\{pathPosition2}.txt"));
            }

            return htmlDocument;
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

            float percentage = (count / (float)(document1.Count + document2.Count)) * 100;
            return Math.Round(percentage, 2);
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
            int startIndexOfTitle = 7, endIndexOfTitle = 15;
            foreach (var path in filePaths)
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    string line = streamReader.ReadToEnd();
                    MatchCollection match = regex.Matches(line);
                    foreach (Match match1 in match)
                    {
                        string result = match1.Value.ToString();
                        allFilesTiles.Append($"{result.Substring(startIndexOfTitle, result.Length - endIndexOfTitle)},\n");
                    }
                }
            }

            Console.WriteLine(allFilesTiles.ToString());
            return allFilesTiles.ToString();
        }

        /// <summary>
        /// Display the details in the list
        /// </summary>
        /// <param name="dataStored">List of the data to be displayed</param>
        public static void DisplayTheList(List<string> dataStored)
        {
            dataStored.ForEach(x => Console.Write($"{x}, "));
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
        /// Format the post by adding the paragraphs tags in blog post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>Modified string content replaced by the tags</returns>
        public static string FormatPost(string post)
        {
            StringBuilder stringBuilder = new StringBuilder(post.Trim());
            stringBuilder.Replace("\n", "<br>");
            stringBuilder.Replace("\n\n", "<p></p>");
            return stringBuilder.ToString();
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
        /// Take URLS from the given blog post
        /// </summary>
        /// <param name="post">HTML Document of the blog post</param>
        /// <returns>List consists of the URLS present in the post</returns>
        public static List<string> ParseURL(string post)
        {
            List<string> listOfTheUrlS = new List<string>();
            Regex regex = new Regex("[(http(s)?):\\/\\/(www\\.)?a-zA-Z0-9@:%._\\+~#=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%_\\+.~#?&//=]*)");
            MatchCollection match = regex.Matches(post);
            foreach (Match word in match)
            {
                listOfTheUrlS.Add(word.ToString());
            }
            return listOfTheUrlS;
        }

        /// <summary>
        /// Search for the text in the given blog post
        /// </summary>
        /// <param name="query">Query to search in the blog post</param>
        /// <returns>List of all post consists of the data</returns>
        public static async Task<List<string>> SearchForTheQueryInFiles(string query)
        {
            List<string> dataOfTheFiles = await AccessMultipleFilesAsync(null, null, true);
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
    }
}