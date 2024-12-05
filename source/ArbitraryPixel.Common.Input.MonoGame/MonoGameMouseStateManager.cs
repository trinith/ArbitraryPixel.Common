using Microsoft.Xna.Framework.Input;

namespace ArbitraryPixel.Common.Input.MonoGame
{
    public class MonoGameMouseStateManager : IMouseManager
    {
        public IMouseState GetState()
        {
            MouseState state = Mouse.GetState();
            return new MonoGameMouseState(
                state.Position,
                state.ScrollWheelValue,
                state.LeftButton,
                state.MiddleButton,
                state.RightButton,
                state.XButton1,
                state.XButton2
            );
        }
    }
}
