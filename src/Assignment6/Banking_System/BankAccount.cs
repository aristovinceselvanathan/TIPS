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
        /// Method that used to deposit money in account number
        /// </summary>
        /// <param name="amount">It takes the amount in decimal</param>
        public void Deposit(decimal amount)
        {
            this.Balance += amount;
            Console.WriteLine("Amount is Deposited Successfully");
        }

        /// <summary>
        /// Method withdraws the money from the account
        /// </summary>
        /// <param name="amount">It takes the amount as a decimal</param>
        public virtual void Withdraw(decimal amount)
        {
            this.Balance -= amount;
        }
    }
}
