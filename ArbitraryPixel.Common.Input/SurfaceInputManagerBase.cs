using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// A base implementation of ISurfaceInputManager that handles some base funcitonality.
    /// </summary>
    public abstract class SurfaceInputManagerBase : ISurfaceInputManager
    {
        private object _globalConsumer = null;
        private Dictionary<int, object> _touchConsumers = new Dictionary<int, object>();

        /// <summary>
        /// Whether or not this input manager is active.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Update this input manager.
        /// </summary>
        /// <param name="gameTime">The current time state for the game.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Gets the state of the surface this object manages.
        /// </summary>
        /// <returns>The state of the surface.</returns>
        public abstract SurfaceState GetSurfaceState();

        /// <summary>
        /// Check if an object is able to consume input at the global input level.
        /// </summary>
        /// <param name="consumer">A reference to the potential consumer.</param>
        /// <returns>True if the consumer should consume the input, false otherwise.</returns>
        public bool ShouldConsumeInput(object consumer)
        {
            return (_globalConsumer == null || _globalConsumer == consumer);
        }

        /// <summary>
        /// Check if an object can consume a given touch id.
        /// </summary>
        /// <param name="touchId">The id of the touch to check.</param>
        /// <param name="consumer">A reference to the potential consumer.</param>
        /// <returns>True if the consumer should consume the touch id, false otherwise.</returns>
        public bool ShouldConsumeInput(int touchId, object consumer)
        {
            return this.ShouldConsumeInput(consumer) && (_touchConsumers.ContainsKey(touchId) == false || _touchConsumers[touchId] == consumer);
        }

        /// <summary>
        /// Set a global consumer object. Only this object may consume input.
        /// </summary>
        /// <param name="consumer">A reference to the consumer object.</param>
        public void SetConsumer(object consumer)
        {
            _globalConsumer = consumer;
        }

        /// <summary>
        /// Set the consumer object for a given touch. Only this object may consume input for this touch.
        /// </summary>
        /// <param name="touchId">The id of the touch to set the consumer for.</param>
        /// <param name="consumer">A reference to the consumer object.</param>
        public void SetConsumer(int touchId, object consumer)
        {
            if (_touchConsumers.ContainsKey(touchId))
            {
                if (_touchConsumers[touchId] != consumer)
                    throw new TouchAlreadyConsumedException();
            }
            else
            {
                _touchConsumers.Add(touchId, consumer);
            }
        }

        /// <summary>
        /// Clear the global consumer object, allowing all objects to consume input if a check is performed.
        /// </summary>
        public void ClearConsumer()
        {
            _globalConsumer = null;
        }

        /// <summary>
        /// Clear the consumer object for the specified touch id, allowing other objects to consume input for this touch id.
        /// </summary>
        /// <param name="touchId">The touch id to clear the consumer object for.</param>
        public void ClearConsumer(int touchId)
        {
            _touchConsumers.Remove(touchId);
        }
    }
}
