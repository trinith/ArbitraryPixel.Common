using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Represents an object that gets input state for a screen surface.
    /// </summary>
    public interface ISurfaceInputManager
    {
        /// <summary>
        /// Whether or not this input manager is active.
        /// </summary>
        bool IsActive { get; set; }

        /// <summary>
        /// Update this input manager.
        /// </summary>
        /// <param name="gameTime">The current time state for the game.</param>
        void Update(GameTime gameTime);

        /// <summary>
        /// Gets the state of the surface this object manages.
        /// </summary>
        /// <returns>The state of the surface.</returns>
        SurfaceState GetSurfaceState();

        /// <summary>
        /// Check if an object is able to consume input at the global input level.
        /// </summary>
        /// <param name="consumer">A reference to the potential consumer.</param>
        /// <returns>True if the consumer should consume the input, false otherwise.</returns>
        bool ShouldConsumeInput(object consumer);

        /// <summary>
        /// Check if an object can consume a given touch id.
        /// </summary>
        /// <param name="touchId">The id of the touch to check.</param>
        /// <param name="consumer">A reference to the potential consumer.</param>
        /// <returns>True if the consumer should consume the touch id, false otherwise.</returns>
        bool ShouldConsumeInput(int touchId, object consumer);

        /// <summary>
        /// Set a global consumer object. Only this object may consume input.
        /// </summary>
        /// <param name="consumer">A reference to the consumer object.</param>
        void SetConsumer(object consumer);

        /// <summary>
        /// Set the consumer object for a given touch. Only this object may consume input for this touch.
        /// </summary>
        /// <param name="touchId">The id of the touch to set the consumer for.</param>
        /// <param name="consumer">A reference to the consumer object.</param>
        void SetConsumer(int touchId, object consumer);

        /// <summary>
        /// Clear the global consumer object, allowing all objects to consume input if a check is performed.
        /// </summary>
        void ClearConsumer();

        /// <summary>
        /// Clear the consumer object for the specified touch id, allowing other objects to consume input for this touch id.
        /// </summary>
        /// <param name="touchId">The touch id to clear the consumer object for.</param>
        void ClearConsumer(int touchId);
    }


}
