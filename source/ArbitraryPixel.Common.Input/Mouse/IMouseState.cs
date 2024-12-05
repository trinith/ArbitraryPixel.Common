using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace ArbitraryPixel.Common.Input
{
    /// <summary>
    /// Represents a mouse state.
    /// </summary>
    public interface IMouseState
    {
        /// <summary>
        /// The position of the mouse.
        /// </summary>
        Point Position { get; }

        /// <summary>
        /// Whether or not at least one button is currently pressed.
        /// </summary>
        bool ButtonPressed { get; }

        /// <summary>
        /// The state of the left button.
        /// </summary>
        ButtonState LeftButton { get; }

        /// <summary>
        /// The state of the middle button.
        /// </summary>
        ButtonState MiddleButton { get; }

        /// <summary>
        /// The state of the right button.
        /// </summary>
        ButtonState RightButton { get; }

        /// <summary>
        /// The state of the XButton1.
        /// </summary>
        ButtonState XButton1 { get; }

        /// <summary>
        /// The state of the XButton2.
        /// </summary>
        ButtonState XButton2 { get; }

        /// <summary>
        /// The cumulative scroll wheel value since the game start.
        /// </summary>
        int ScrollWheelValue { get; }
    }
}
