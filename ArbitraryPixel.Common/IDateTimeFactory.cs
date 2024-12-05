namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that managed DateTime objects.
    /// </summary>
    public interface IDateTimeFactory
    {
        /// <summary>
        /// Gets a IDateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        IDateTime Now { get; }
    }
}
