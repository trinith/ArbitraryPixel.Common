namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that can perform debugging actions.
    /// </summary>
    public interface IDebug
    {
        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        void WriteLine(string message);
    }
}
