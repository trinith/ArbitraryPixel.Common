using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Represents the state of a screen surface.
    /// </summary>
    public struct SurfaceState
    {
        /// <summary>
        /// The location, on the surface, of the first input of any state.
        /// </summary>
        public Vector2 SurfaceLocation
        {
            get { return (this.Touches.Count > 0) ? this.Touches[0].Position : default(Vector2); }
        }

        /// <summary>
        /// Whether or not a touch exists that is currently in contact with the surface.
        /// </summary>
        public bool IsTouched
        {
            get
            {
                bool isTouched = false;

                foreach (var touch in this.Touches)
                {
                    if (touch.State == TouchLocationState.Pressed || touch.State == TouchLocationState.Moved)
                    {
                        isTouched = true;
                        break;
                    }
                }

                return isTouched;
            }
        }

        /// <summary>
        /// A collection of touches for the state of input.
        /// </summary>
        public TouchCollection Touches { get; private set; }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="surfaceLocation">The input location.</param>
        /// <param name="isTouched">Whether or not the surface is considered touched.</param>
        [Obsolete("This constructor is obsolete and is left in for backward compatibility purposes. It will be removed \"soon\"... :D")]
        public SurfaceState(Vector2 surfaceLocation, bool isTouched)
            : this()
        {
            //this.SurfaceLocation = surfaceLocation;
            //this.IsTouched = isTouched;
            this.Touches = new TouchCollection(new TouchLocation[] { new TouchLocation(0, (isTouched) ? TouchLocationState.Pressed : TouchLocationState.Invalid, surfaceLocation) });
        }

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="touches">A collection of touches for the state of input.</param>
        public SurfaceState(TouchCollection touches)
            : this()
        {
            this.Touches = touches;
        }
    }
}
