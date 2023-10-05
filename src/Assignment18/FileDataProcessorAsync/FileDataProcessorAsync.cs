namespace FileDataProcessorAsync
{
    /// <summary>
    /// File Data Processor Asynchronously
    /// </summary>
    public class FileDataProcessorAsync
    {
        /// <summary>
        /// Method process the file asynchronously
        /// </summary>
        /// <param name="source">Source file paths</param>
        /// <param name="destination">Destination file path</param>
        /// <returns><see cref="Task"/> representing the asynchronous operation.</returns>
        public static async Task FileProcessAsync(string[] source, string destination)
        {
            var maxConcurrentTask = new ParallelOptions{ MaxDegreeOfParallelism = 4 };
            await Parallel.ForEachAsync(source, maxConcurrentTask, async (source, token) =>
            {
                string sourceFilePath = $"source\\{source}";
                string destinationFilePath = Path.Combine(destination, Path.GetFileName(sourceFilePath).Replace("source", "destination"));
                await ProcessFileToUpperCaseAsync(sourceFilePath, destinationFilePath);
            });
        }

        /// <summary>
        /// Process the file
        /// </summary>
        /// <param name="sourceFilePath">Source file</param>
        /// <param name="destinationFilePath">Destination file</param>
        /// <returns>task</returns>
        public static async Task ProcessFileToUpperCaseAsync(string sourceFilePath, string destinationFilePath)
        {
            using (FileStream fileStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read))
            using (BufferedStream bufferStream = new BufferedStream(fileStream))
            using (StreamWriter streamWriter = new StreamWriter(destinationFilePath))
            {
                int bytesRead;
                int bufferSize = (int)Math.Min(fileStream.Length, int.MaxValue);
                byte[] buffer = new byte[bufferSize];

                while ((bytesRead = await bufferStream.ReadAsync(buffer, 0, bufferSize)) > 0)
                {
                    await fileStream.ReadAsync(buffer, 0, bufferSize);
                    string data = System.Text.Encoding.UTF8.GetString(buffer, 0, bufferSize);
                    await streamWriter.WriteLineAsync(data.ToUpper());
                }
            }
        }
    }
}
