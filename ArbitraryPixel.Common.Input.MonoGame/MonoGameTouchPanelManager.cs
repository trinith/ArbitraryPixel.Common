using Microsoft.Xna.Framework.Input.Touch;

namespace ArbitraryPixel.Common.Input.MonoGame
{
    public class MonoGameTouchPanelManager : ITouchPanelManager
    {
        public TouchCollection GetState()
        {
            return TouchPanel.GetState();
        }
    }
}
