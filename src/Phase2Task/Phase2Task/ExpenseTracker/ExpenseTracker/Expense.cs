using System;

namespace ExpenseTracker
{
    /// <summary>
    /// Expense Class
    /// </summary>
    public class Expense
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="entryDate">Date of the entry</param>
        /// <param name="amount">Amount involved in the transaction</param>
        /// <param name="category">category of the expense</param>
        public Expense(DateTime entryDate, int amount, string category)
        {
            this.EntryDate = entryDate;
            this.Amount = amount;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets EntryDate
        /// </summary>
        /// <value>
        /// EntryDate
        /// </value>
        public DateTime EntryDate { get; set; }

        /// <summary>
        /// Gets or sets Amount
        /// </summary>
        /// <value>
        /// Amount
        /// </value>
        public int Amount { get; set; }

        /// <summary>
        /// Gets or sets Category
        /// </summary>
        /// <value>
        /// Category
        /// </value>
        public string Category { get; set; }
    }
}
