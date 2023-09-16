namespace BankingSystem
{
    /// <summary>
    /// Checking Account Class
    /// </summary>
    internal class CheckingAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckingAccount"/> class.
        /// It prints This is Checking Account Method an pass the accountNumber, balance to base class
        /// </summary>
        /// <param name="number">It takes account number as string</param>
        /// <param name="balance">It takes balance as decimal</param>
        public CheckingAccount(string number, decimal balance)
            : base(number, balance)
        {
            Console.WriteLine("This is Checking Account");
        }
    }
}
