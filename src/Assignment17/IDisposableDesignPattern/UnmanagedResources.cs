namespace IDisposableDesignPattern
{
    /// <summary>
    /// Unmanaged Resources Class
    /// </summary>
    public class UnmanagedResources : IDisposable
    {
        private bool _disposed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="UnmanagedResources"/> class.
        /// </summary>
        /// <param name="filePath">FilePath of the file to be modified</param>
        public UnmanagedResources(string filePath)
        {
            this.Writer = new StreamWriter(filePath);
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnmanagedResources"/> class.
        /// </summary>
        ~UnmanagedResources()
        {
            this.Dispose(false);
        }

        /// <summary>
        /// Gets it is stream writer.
        /// </summary>
        /// <value>
        /// It is stream writer
        /// </value>
        public StreamWriter Writer { get; private set; }

        /// <summary>
        /// It writes to the file by using the stream writer
        /// </summary>
        /// <param name="text">Text Information to be added</param>
        public void WriteToTheFile(string text)
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            else
            {
                this.Writer.WriteLine(text);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nWrote to the file is successfully");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        /// <summary>
        /// It will close file by using the stream reader.
        /// </summary>
        public void CloseFile()
        {
            if (this._disposed)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }
            else
            {
                this.Writer.Dispose();
                this.Writer = null;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nFile Closed successfully.");
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
        /// Dispose method from IDisposable
        /// </summary>
        /// <param name="disposing">It status of list is disposed</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    this.CloseFile();
                }

                this._disposed = true;
            }
        }
    }
}
