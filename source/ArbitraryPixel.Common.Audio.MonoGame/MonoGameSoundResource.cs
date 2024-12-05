using Microsoft.Xna.Framework.Audio;
using System;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame
{
    /// <summary>
    /// A simple wrapper for ISoundResource implemented using MonoGame's SoundEffect object.
    /// </summary>
    public class MonoGameSoundResource : WrapperBase<SoundEffect>, ISoundResource
    {
        public MonoGameSoundResource(SoundEffect objectToWrap)
            : base(objectToWrap)
        {
        }

        #region ISoundResource Implementation
        public event EventHandler<EventArgs> Disposed;

        public bool Enabled { get; set; }

        public bool IsDisposed
        {
            get => this.WrappedObject.IsDisposed;
        }

        public float MasterVolume
        {
            get { return SoundEffect.MasterVolume; }
            set { SoundEffect.MasterVolume = value; }
        }

        public ISound CreateInstance()
        {
            return
                new Sound(
                    new MonoGameSound(
                        this.WrappedObject.CreateInstance()
                    )
                );
        }

        public void Dispose()
        {
            this.WrappedObject.Dispose();

            if (this.Disposed != null)
                this.Disposed(this, new EventArgs());
        }

        public void Play()
        {
            if (this.Enabled == true)
                this.WrappedObject.Play();
        }

        /// <summary>
        /// Not implemented. A MonoGame SoundEffect instance does not contain the functionality to stop all currently playing instances.
        /// </summary>
        public void StopAll()
        {
            throw new NotImplementedException();
        }
        #endregion


    }
}
