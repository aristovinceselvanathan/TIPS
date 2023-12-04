namespace AsyncAwait
{
    using System.Text.RegularExpressions;
    using HtmlAgilityPack;

    /// <summary>
    /// Class to Get data from the server
    /// </summary>
    public class GetFromServer
    {
        /// <summary>
        /// Method will get the string from the web server
        /// </summary>
        /// <param name="url">It takes the url from the web</param>
        /// <returns>Html document present of the website</returns>
        public static async Task<string> GetFromWeb(string url)
        {
            HtmlDocument htmlDoc = new HtmlDocument();
            HttpClient httpClient;
            string result;

            try
            {
                if (ValidateURL(url))
                {
                    using (httpClient = new HttpClient())
                    using (var data = httpClient.GetStringAsync(url))
                    {
                        await data;
                        if (data.IsCompleted)
                        {
                            Program.SuccessfulColor("Data Fetched Successfully");
                            htmlDoc.LoadHtml($"{data.Result}");
                            result = htmlDoc.DocumentNode.InnerText;
                            return result;
                        }
                        else
                        {
                            Program.InvalidWarning("Problem in Fetching the Data");
                        }
                    }
                }
                else
                {
                    Program.InvalidWarning("Invalid URL : It should contain the base address");
                }
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Out.WriteLine("Page Not Found!!!");
                Console.Out.WriteLine($"Message : {e.Message}");
                Console.ForegroundColor = ConsoleColor.White;
            }

            return string.Empty;
        }

        /// <summary>
        /// This method will validate the url whether the url is valid one
        /// </summary>
        /// <param name="urlAddress">It takes the URL Address</param>
        /// <returns>Valid of url status</returns>
        public static bool ValidateURL(string urlAddress)
        {
            Regex pattern = new Regex("^((http|https)://)[-a-zA-Z0-9@:%._\\+~#?&//=]{2,256}\\.[a-z]{2,6}\\b([-a-zA-Z0-9@:%._\\+~#?&//=]*)$");
            if (pattern.IsMatch(urlAddress))
            {
                return true;
            }

            return false;
        }
    }
}