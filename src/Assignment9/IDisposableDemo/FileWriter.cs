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
        /// </summary>
        /// <param name="filePath">FilePath of the file to be modified</param>
        public FileWriter(string filePath)
        {
            _writer = new StreamWriter(filePath);
        }

        /// <summary>
        /// It writes to the file by using the stream writer
        /// </summary>
        /// <param name="text">Text Information to be added</param>
        public void WriteToTheFile(string text)
        {
            _writer.WriteLine(text);
        }

        /// <summary>
        /// It will dispose the unmanaged files to clear the unwanted memory.
        /// </summary>
        public void Dispose()
        {
            _writer.Close();    // Closes the file
            _writer.Dispose();  // Release the resources
        }
    }
}