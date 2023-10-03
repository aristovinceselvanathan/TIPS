namespace IDisposableDesignPattern
{
    /// <summary>
    /// Managed Resources Class
    /// </summary>
    public class ManagedResources : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ManagedResources"/> class.
        /// </summary>
        public ManagedResources()
        {
            this.DataList = new List<string>();
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="ManagedResources"/> class.
        /// </summary>
        ~ManagedResources()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets or sets it consists of the data.
        /// </summary>
        /// <value>
        /// It consists of string data
        /// </value>
        public List<string> DataList { get; set; }

        /// <summary>
        /// It add the data to the list
        /// </summary>
        /// <param name="datavalue">It is denotes the data of the string</param>
        public void AddData(string datavalue)
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            else
            {
                this.DataList.Add(datavalue);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nValue added successfully into the list");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// It clears the data present in the list
        /// </summary>
        public void ClearData()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            else
            {
                this.DataList.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nDataList Cleared Successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// It will clear the managed resources and unmanaged resources and supress the finalizer
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose method of the IDisposable
        /// </summary>
        /// <param name="disposing">It status of list to be disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.DataList.Clear();
                }

                this._disposed = true;
            }
        }
    }
}
