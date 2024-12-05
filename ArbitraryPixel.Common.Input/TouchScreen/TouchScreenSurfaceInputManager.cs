using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Gets surface information for a screen that is interacted with via a touch screen.
    /// </summary>
    public class TouchScreenSurfaceInputManager : SurfaceInputManagerBase, ISurfaceInputManager
    {
        private ITouchPanelManager _touchManager;
        private TouchCollection _currentState;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="touchManager">An object responsible for getting touch screen state.</param>
        public TouchScreenSurfaceInputManager(ITouchPanelManager touchManager)
        {
            _touchManager = touchManager ?? throw new ArgumentNullException();
        }

        /// <summary>
        /// Update this input manager.
        /// </summary>
        /// <param name="gameTime">The current time state for the game.</param>
        public override void Update(GameTime gameTime)
        {
            _currentState = _touchManager.GetState();
        }

        /// <summary>
        /// Gets the state of the surface this object manages.
        /// </summary>
        /// <returns>The state of the surface.</returns>
        public override SurfaceState GetSurfaceState()
        {
            return new SurfaceState(_currentState);
        }
    }
}
