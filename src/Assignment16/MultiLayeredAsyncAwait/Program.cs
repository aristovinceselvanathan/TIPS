namespace MultiLayeredAsyncAwait
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Program Class it contains the entry point of the program
    /// </summary>
    public class Program
    {
        /// <summary>
        /// It will await for the MethodC to complete.
        /// </summary>
        /// <param name="args">It is String array in the parameters of the main method</param>
        /// <returns>Task to be awaited</returns>
        public static async Task Main(string[] args)
        {
            try
            {
                var result = await MethodC();
                Console.WriteLine($"Number of Key Value Pairs Present in JSON Url : {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        /// <summary>
        /// It run the CPU-bound Task for 3 seconds and returns 49
        /// </summary>
        /// <returns>Task that contains 56</returns>
        public static async Task<string> MethodA()
        {
            // Simulate a CPU-bound operation
            var x = Task.Run(() =>
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Intensive Task is Running...\n");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(4000);
                return "56";
            });
            return await x;
        }

        /// <summary>
        /// It will make the http request to the website
        /// </summary>
        /// <param name="input">Input is required to construct the url to get json data</param>
        /// <returns>A <see cref="Task"/>Representing the result of the asynchronous operation and contains json data</returns>
        public static async Task<string> MethodB(string input)
        {
            // Simulate an async operation (e.g., making a web service call)
            using (var httpClient = new HttpClient())
            {
                var url = $"https://jsonplaceholder.typicode.com/posts/{input}";
                Console.Out.WriteLine($"Getting the JSON File from the url : {url}\n");
                var response = await httpClient.GetStringAsync(url);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Out.WriteLine("JSON File Fetched Successfully.\n");
                Console.ForegroundColor = ConsoleColor.White;
                return response;
            }
        }

        /// <summary>
        /// It will process the json text from the Method B
        /// </summary>
        /// <returns>Number of the key value pair present in the json file</returns>
        public static async Task<int> MethodC()
        {
            try
            {
                var taskA = Task.Run(() => MethodA());
                var resultFromA = await taskA;

                var taskB = MethodB(resultFromA);

                var resultFromB = await taskB;
                JObject jsonObject = JObject.Parse(resultFromB);

                // Process the result (e.g., parse JSON and extract the number of key-value pairs)
                var numberOfPairs = jsonObject.Properties().Count();

                return numberOfPairs;
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                throw new Exception("An error occurred in MethodC\n", ex);
            }
        }
    }
}
