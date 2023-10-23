namespace BankingSystem
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
        /// Gets or Sets the AccountNumber of the customer
        /// </summary>
        /// <value>string</value>
        protected string AccountNumber { get; set; }

        /// <summary>
        /// Gets or Sets the Balance of the account
        /// </summary>
        /// <value>string</value>
        protected decimal Balance { get; set; }

        /// <summary>
        /// Method that used to deposit money in account number
        /// </summary>
        /// <param name="amount">It takes the amount in decimal</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("Amount is Deposited Successfully");
        }

        /// <summary>
        /// Method that used to withdraw the money from the account
        /// </summary>
        /// <param name="amount">It takes the amount as a decimal</param>
        public virtual void Withdraw(decimal amount)
        {
            if (this.Balance - amount > 0)
            {
                this.Balance -= amount;
            }
            else
            {
                Console.WriteLine("Transaction is Failed! Insufficient Funds");
            }
        }

        /// <summary>
        /// It will print the details of the account
        /// </summary>
        public void PrintDetailsOfAccount()
        {
            Console.WriteLine($"Account Number : {this.AccountNumber}");
            Console.WriteLine($"Balance : {this.Balance}");
        }
    }
}
