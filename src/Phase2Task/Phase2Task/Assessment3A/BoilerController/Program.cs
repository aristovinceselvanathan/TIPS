namespace BoilerConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userName = Utility.GetTheStringInput("Name");
            string passWord = Utility.GetTheStringInput("Password");
            if (userName.Equals("Admin") && passWord.Equals("Admin123"))
            {
                Console.Clear();
                UserInterface userInterface = new UserInterface();
                userInterface.StartTheUserInterface();
            }
            else
            {
                FileOperation.LogToTheFile("Invalid Username or Password");
                Console.WriteLine("Invalid Username or Password");
            }
        }
    }
}