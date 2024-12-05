using Microsoft.Xna.Framework.Audio;
using System;

#pragma warning disable 1591

namespace ArbitraryPixel.Common.Audio.MonoGame
{
    /// <summary>
    /// A simple wrapper for ISound implemented using MonoGame's SoundEffectInstance object.
    /// </summary>
    public class MonoGameSound : WrapperBase<SoundEffectInstance>, ISound
    {
        public MonoGameSound(SoundEffectInstance objectToWrap)
            : base(objectToWrap)
        {
        }

        #region ISound Implementation
        public event EventHandler<EventArgs> Disposed;

        public bool IsDisposed => this.WrappedObject.IsDisposed;

        public bool Enabled { get; set; }

        public SoundState State => (SoundState)this.WrappedObject.State;

        public bool IsLooped
        {
            get { return this.WrappedObject.IsLooped; }
            set { this.WrappedObject.IsLooped = value; }
        }

        public float Volume
        {
            get { return this.WrappedObject.Volume; }
            set { this.WrappedObject.Volume = value; }
        }

        public void Dispose()
        {
            this.WrappedObject.Dispose();

            if (this.Disposed != null)
                this.Disposed(this, new EventArgs());
        }

        public void Play()
        {
            this.WrappedObject.Play();
        }

        public void Stop()
        {
            this.WrappedObject.Stop();
        }
        #endregion
    }
}
