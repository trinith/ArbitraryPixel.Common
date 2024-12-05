using System;

namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// An implementation of ISound that layers additional control functionality on top of an existing ISound object.
    /// </summary>
    public class Sound : ISound
    {
        private ISound _baseSound;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="baseSound">An base ISound object that this sound will use for playback.</param>
        public Sound(ISound baseSound)
        {
            _baseSound = baseSound ?? throw new ArgumentNullException();
        }

        #region ISound Implementation
        /// <summary>
        /// An event that occurs when this sound has been disposed.
        /// </summary>
        public event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Whether or not this sound has been disposed.
        /// </summary>
        public bool IsDisposed => _baseSound.IsDisposed;

        /// <summary>
        /// Whether or not this should should audibly play. If set to false while this sound is currently playing or paused, sound playback will stop.
        /// </summary>
        public bool Enabled
        {
            get { return _baseSound.Enabled; }
            set
            {
                if (value != _baseSound.Enabled)
                {
                    _baseSound.Enabled = value;

                    if (_baseSound.Enabled == false && this.State != SoundState.Stopped)
                        this.Stop();
                }
            }
        }

        /// <summary>
        /// The current playback state of this sound.
        /// </summary>
        public SoundState State => _baseSound.State;

        /// <summary>
        /// Whether or not this sound should loop when played.
        /// </summary>
        public bool IsLooped { get => _baseSound.IsLooped; set => _baseSound.IsLooped = value; }

        /// <summary>
        /// The volume of this sound, relative to the ISoundResource object that created it.
        /// </summary>
        public float Volume { get => _baseSound.Volume; set => _baseSound.Volume = value; }

        /// <summary>
        /// Play the sound. If this sound is not enabled, playback will not occur.
        /// </summary>
        public void Play()
        {
            if (this.Enabled)
                _baseSound.Play();
        }

        /// <summary>
        /// Stop the sound, if it is currently playing.
        /// </summary>
        public void Stop()
        {
            _baseSound.Stop();
        }
        #endregion

        #region IDisposable Implementation
        /// <summary>
        /// Dispose of this object's resources.
        /// </summary>
        public void Dispose()
        {
            if (!_baseSound.IsDisposed)
            {
                _baseSound.Dispose();

                if (this.Disposed != null)
                    this.Disposed(this, new EventArgs());
            }
        }
        #endregion
    }
}
