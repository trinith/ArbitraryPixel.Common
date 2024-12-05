using Microsoft.Xna.Framework.Input.Touch;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Represents an object that gets the state of a touch screen.
    /// </summary>
    public interface ITouchPanelManager
    {
        /// <summary>
        /// Get the current touch screen state.
        /// </summary>
        /// <returns>The current touch screen state.</returns>
        TouchCollection GetState();
    }
}
