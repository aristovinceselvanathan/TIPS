namespace IDisposableDemo
{

    /// <summary>
    /// It writes to the file
    /// </summary>
    internal class FileWriter : IDisposable
    {
        private StreamWriter _writer;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileWriter"/> class.
        /// Constructor that loads the file
        /// </summary>
        /// <param name="filePath">It takes the filePath as string parameter</param>
        public FileWriter(string filePath)
        {
            _writer = new StreamWriter(filePath);
        }

        /// <summary>
        /// It writes to the file
        /// </summary>
        /// <param name="text">It takes the information as string</param>
        public void WriteToTheFile(string text)
        {
            _writer.WriteLine(text);
        }

        /// <summary>
        /// It will dispose the unmanaged files
        /// </summary>
        public void Dispose()
        {
            _writer.Close();    // Closes the file
            _writer.Dispose();  // Release the resources
        }
    }
}