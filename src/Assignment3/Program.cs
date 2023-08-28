namespace Assignment3
{
    using Newtonsoft.Json;

    /// <summary>
    /// Program Class
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main method that prints the list.
        /// </summary>
        /// <param name="args">It takes string array from the command line interface</param>
        public static void Main(string[] args)
        {
            Account account = new Account
            {
                Email = "james@example.com",
                Active = true,
                CreatedDate = new DateTime(2013, 1, 20, 0, 0, 0, DateTimeKind.Utc),
                Roles = new List<string> { "User", "Admin" },
            };
            Console.WriteLine("Helloo");
            string json = JsonConvert.SerializeObject(account, Newtonsoft.Json.Formatting.Indented);
            Console.WriteLine(json);
        }
    }
}
