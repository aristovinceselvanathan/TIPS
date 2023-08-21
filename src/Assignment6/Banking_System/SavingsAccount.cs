﻿namespace Banking_System
{
    /// <summary>
    /// Saving Account Class that inherit the BankAccount class
    /// </summary>
    internal class SavingsAccount : BankAccount
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SavingsAccount"/> class.
        /// Method calls the base class and pass the parameter to constructor of the base class
        /// </summary>
        /// <param name="number">It takes number as string</param>
        /// <param name="balance">It takes balance as decimal</param>
        public SavingsAccount(string number, decimal balance)
            : base(number, balance)
        {
            Console.WriteLine("This is a Savings Account");
        }

        /// <summary>
        /// Method overrides the withdraw method in the base class
        /// It sets the restriction for the amount to be withdrawn
        /// </summary>
        /// <param name="amount">It takes amount as decimal</param>
        public override void Withdraw(decimal amount)
        {
            if (this.Balance - amount < 5000)
            {
                this.Balance -= amount;
            }
            else
            {
                Console.WriteLine("Withdraw Limit Exceeded");
            }
        }
    }
}
