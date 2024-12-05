using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ArbitraryPixel.Common.Input.MonoGame
{
    public struct MonoGameMouseState : IMouseState
    {
        public Point Position { get; private set; }
        public ButtonState LeftButton { get; private set; }
        public ButtonState MiddleButton { get; private set; }
        public ButtonState RightButton { get; private set; }
        public ButtonState XButton1 { get; private set; }
        public ButtonState XButton2 { get; private set; }
        public int ScrollWheelValue { get; private set; }

        public bool ButtonPressed
        {
            get
            {
                return false
                    || this.LeftButton == ButtonState.Pressed
                    || this.MiddleButton == ButtonState.Pressed
                    || this.RightButton == ButtonState.Pressed
                    || this.XButton1 == ButtonState.Pressed
                    || this.XButton2 == ButtonState.Pressed
                    || false;
            }
        }

        public MonoGameMouseState(
            Point position,
            int scrollWheel,
            ButtonState leftButton,
            ButtonState middleButton,
            ButtonState rightButton,
            ButtonState xButton1,
            ButtonState xButton2
        )
            : this()
        {
            this.Position = position;
            this.ScrollWheelValue = scrollWheel;

            this.LeftButton = leftButton;
            this.MiddleButton = middleButton;
            this.RightButton = rightButton;
            this.XButton1 = xButton1;
            this.XButton2 = xButton2;
        }
    }
}
