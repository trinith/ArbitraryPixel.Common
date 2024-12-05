using ArbitraryPixel.Common.Audio.Factory;
using Microsoft.Xna.Framework.Media;
using System;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame
{
    public class MonoGameSongPlayer : ISongPlayer
    {
        public MonoGameSongPlayer(ISongFactory factory)
        {
            this.Factory = factory ?? throw new ArgumentNullException();
        }

        #region ISongManager Implementation
        public ISongFactory Factory { get; private set; }

        public bool IsRepeating
        {
            get { return MediaPlayer.IsRepeating; }
            set { MediaPlayer.IsRepeating = value; }
        }

        public bool IsMuted
        {
            get { return MediaPlayer.IsMuted; }
            set { MediaPlayer.IsMuted = value; }
        }

        public float Volume
        {
            get { return MediaPlayer.Volume; }
            set { MediaPlayer.Volume = value; }
        }

        public TimeSpan PlayPosition
        {
            get { return MediaPlayer.PlayPosition; }
        }

        public void Play(ISong song)
        {
            MediaPlayer.Play(song.GetWrappedObject<Song>());
        }

        public void Play(ISong song, TimeSpan startPosition)
        {
            MediaPlayer.Play(song.GetWrappedObject<Song>(), startPosition);
        }

        public void Stop()
        {
            MediaPlayer.Stop();
        }
        #endregion
    }
}
