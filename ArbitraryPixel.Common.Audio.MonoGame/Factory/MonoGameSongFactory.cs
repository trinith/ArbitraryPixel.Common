using ArbitraryPixel.Common.Audio.Factory;
using ArbitraryPixel.Common.ContentManagement;
using Microsoft.Xna.Framework.Media;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame.Factory
{
    public class MonoGameSongFactory : ISongFactory
    {
        public ISong Create(IContentManager content, string assetName)
        {
            Song song = content.Load<Song>(assetName);
            return new MonoGameSong(song);
        }
    }
}
