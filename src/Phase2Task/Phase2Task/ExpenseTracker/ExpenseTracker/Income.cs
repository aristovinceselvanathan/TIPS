namespace ExpenseTracker
{
    /// <summary>
    /// Income Class
    /// </summary>
    public class Income
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Income"/> class.
        /// </summary>
        /// <param name="entryDate">Date of the entry</param>
        /// <param name="amount">Amount involved in the transaction</param>
        /// <param name="source">source of the income</param>
        public Income(DateTime entryDate, int amount, string source)
        {
            this.EntryDate = entryDate;
            this.Amount = amount;
            this.Source = source;
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
        /// Gets or sets Source
        /// </summary>
        /// <value>
        /// Source
        /// </value>
        public string Source { get; set; }

        /// <summary>
        /// Method overrides the equals method in object class
        /// </summary>
        /// <param name="obj"> It uses the instance of the object class</param>
        /// <returns>It returns bool</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Expense other = obj as Expense;
            if (other == null)
            {
                return false;
            }

            return this.EntryDate == other.EntryDate;
        }

        /// <summary>
        /// It overrides the GetHashCode when Equals Method overridden in the Income class
        /// </summary>
        /// <returns>It returns the Integer</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
