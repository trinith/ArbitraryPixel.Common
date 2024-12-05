using System.Diagnostics;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Implements IDebug using System.Diagnostics.Debug.
    /// </summary>
    public class DotNetDebug : IDebug
    {
        /// <summary>
        /// Write a debug message.
        /// </summary>
        /// <param name="message">The message to write.</param>
        public void WriteLine(string message)
        {
            Debug.WriteLine(message);
        }
    }
}
