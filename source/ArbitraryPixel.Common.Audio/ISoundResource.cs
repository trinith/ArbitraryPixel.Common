using System;

namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// Represents an object that can create sounds to play.
    /// </summary>
    public interface ISoundResource : IDisposable
    {
        /// <summary>
        /// An event that occurs when this sound has been disposed.
        /// </summary>
        event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Whether or not this object has been disposed.
        /// </summary>
        bool IsDisposed { get; }

        /// <summary>
        /// Whether or not ISound objects created and owned by this resource should audibly play sound.
        /// </summary>
        bool Enabled { get; set; }

        /// <summary>
        /// The master volume of all ISound objects created from this resource.
        /// </summary>
        float MasterVolume { get; set; }

        /// <summary>
        /// Create a sound and play it automatically.
        /// </summary>
        void Play();

        /// <summary>
        /// Stop all instances of sounds created from this resource.
        /// </summary>
        void StopAll();

        /// <summary>
        /// Create a new instance of a sound from this resource.
        /// </summary>
        /// <returns>The newly created sound instance.</returns>
        ISound CreateInstance();
    }
}
