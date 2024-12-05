namespace ArbitraryPixel.Common.SimpleFileSystem
{
    /// <summary>
    /// Represents an object that can perform simple interactions with a file system.
    /// </summary>
    public interface ISimpleFileSystem
    {
        /// <summary>
        /// Check whether or not a file exists.
        /// </summary>
        /// <param name="fileName">The file to check.</param>
        /// <returns>True if the file exists on the file system, false otherwise.</returns>
        bool FileExists(string fileName);

        /// <summary>
        /// Check whether or not a folder exists.
        /// </summary>
        /// <param name="folderName">The folder to check.</param>
        /// <returns>True if the folder exists on the file system, false otherwise.</returns>
        bool FolderExists(string folderName);

        /// <summary>
        /// Create a folder in the file system. An exception will be thrown if the folder already exists.
        /// </summary>
        /// <param name="folderName">The name of the folder to create.</param>
        void CreateFolder(string folderName);

        /// <summary>
        /// Read the contents of a file.
        /// </summary>
        /// <param name="fileName">The file to read.</param>
        /// <returns>A string containing the contents of the file.</returns>
        string ReadFileContents(string fileName);

        /// <summary>
        /// Write a string to a file, overwriting the file if it exists.
        /// </summary>
        /// <param name="fileName">The file to write to.</param>
        /// <param name="contents">The string to write to the file.</param>
        void WriteFileContents(string fileName, string contents);

        /// <summary>
        /// Delete a file.
        /// </summary>
        /// <param name="fileName">The file to delete.</param>
        void DeleteFile(string fileName);
    }
}
