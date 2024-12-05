using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Gets surface information for a screen that is interacted with via a mouse.
    /// </summary>
    public class MouseSurfaceInputManager : SurfaceInputManagerBase, ISurfaceInputManager
    {
        private IMouseManager _mouseManager;
        private TouchLocation _touch = new TouchLocation(0, TouchLocationState.Released, default(Vector2));

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="mouseManager">An object responsible for getting mouse state.</param>
        public MouseSurfaceInputManager(IMouseManager mouseManager)
        {
            _mouseManager = mouseManager ?? throw new ArgumentNullException();
            this.IsActive = false;
        }

        /// <summary>
        /// Update this input manager.
        /// </summary>
        /// <param name="gameTime">The current time state for the game.</param>
        public override void Update(GameTime gameTime)
        {
            bool wasTouched = false;
            TouchLocation previousTouch = _touch;
            wasTouched = previousTouch.State == TouchLocationState.Pressed || previousTouch.State == TouchLocationState.Moved;

            IMouseState state = _mouseManager.GetState();

            TouchLocationState newState = TouchLocationState.Released;
            if (state.ButtonPressed == false)
            {
                newState = TouchLocationState.Released; // (wasTouched) ? TouchLocationState.Released : TouchLocationState.Invalid;
            }
            else
            {
                newState = (wasTouched) ? TouchLocationState.Moved : TouchLocationState.Pressed;
            }

            _touch = new TouchLocation(
                0,
                newState,
                state.Position.ToVector2(),
                previousTouch.State,
                previousTouch.Position
            );
        }

        /// <summary>
        /// Gets the state of the surface this object manages.
        /// </summary>
        /// <returns>The state of the surface.</returns>
        public override SurfaceState GetSurfaceState()
        {
            return new SurfaceState(new TouchCollection(new TouchLocation[] { _touch }));
        }
    }
}
