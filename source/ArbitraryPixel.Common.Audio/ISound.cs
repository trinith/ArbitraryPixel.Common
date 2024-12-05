using System;

namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// Represents an instance of a sound resource that can be played.
    /// </summary>
    public interface ISound : IDisposable
    {
        /// <summary>
        /// An event that occurs when this sound has been disposed.
        /// </summary>
        event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Whether or not this sound has been disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Whether or not this should should audibly play.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// The current playback state of this sound.
        /// </summary>
        SoundState State { get; }

        /// <summary>
        /// Whether or not this sound should loop when played.
        /// </summary>
        bool IsLooped { get; set; }

        /// <summary>
        /// The volume of this sound, relative to the ISoundResource object that created it.
        /// </summary>
        float Volume { get; set; }

        /// <summary>
        /// Play the sound.
        /// </summary>
        void Play();

        /// <summary>
        /// Stop the sound, if it is currently playing.
        /// </summary>
        void Stop();
    }
}
