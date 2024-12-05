namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Represents an object that gets the state of a mouse.
    /// </summary>
    public interface IMouseManager
    {
        /// <summary>
        /// Get the current mouse state.
        /// </summary>
        /// <returns>The current mouse state.</returns>
        IMouseState GetState();
    }
}
