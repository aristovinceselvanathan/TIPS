namespace Banking_System
{
    /// <summary>
    /// BankAccount Class
    /// </summary>
    internal class BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankAccount"/> class.
        /// It sets the Account Number, Balance
        /// </summary>
        /// <param name="accountNumber">It takes the account number as a string</param>
        /// <param name="balance">It takes the balance as a integer</param>
        public BankAccount(string accountNumber, decimal balance)
        {
            this.AccountNumber = accountNumber;
            this.Balance = balance;
        }

        /// <summary>
        /// Gets or Sets the AccountNumber
        /// </summary>
        /// <value>string</value>
        public string AccountNumber { get; set; }

        /// <summary>
        /// Gets or Sets the Balance
        /// </summary>
        /// <value>string</value>
        public decimal Balance { get; set; }

        /// <summary>
        /// It shows the colourful successful message for transactions
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void SuccessfulColor(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"{nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// It shows the colourful warning message of the failed transactions
        /// </summary>
        /// <param name="nameOfInput">It takes the name of the input</param>
        public static void FailedWarning(string nameOfInput)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"Invalid {nameOfInput}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        /// <summary>
        /// Method that used to deposit money in account number
        /// </summary>
        /// <param name="amount">It takes the amount in decimal</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            SuccessfulColor("Amount is Deposited Successfully");
        }

        /// <summary>
        /// Method withdraws the money from the account
        /// </summary>
        /// <param name="amount">It takes the amount as a decimal</param>
        public virtual void Withdraw(decimal amount)
        {
            if (this.Balance - amount < 0)
            {
                FailedWarning("Transaction is Failed! Insufficient Funds");
            }
            else
            {
                this.Balance -= amount;
            }
        }
    }
}
