namespace Assignment19
{
    /// <summary>
    /// FileOperations CLass
    /// </summary>
    public static class FileOperations
    {
        /// <summary>
        /// Read the file using the stream reader
        /// </summary>
        /// <param name="path">Path of the file to be accessed</param>
        /// <returns>Task of the HTML document data</returns>
        public static async Task<string> ReadTheFile(string path)
        {
            using (StreamReader sr = new StreamReader(path))
            {
                return await sr.ReadToEndAsync();
            }
        }

        /// <summary>
        /// Write the file using the stream Writer
        /// </summary>
        /// <param name="path">Path of the file to be modified</param>
        /// <param name="data">Data to be written in the file</param>
        /// <returns>Task object for asynchronous programming</returns>
        public static async Task WriteTheFile(string path, string data)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                await sw.WriteAsync(data);
            }
        }
    }
}