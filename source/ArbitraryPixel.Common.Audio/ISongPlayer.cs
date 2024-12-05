using ArbitraryPixel.Common.Audio.Factory;
using System;

namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// Represents an object that will play an ISong object.
    /// </summary>
    public interface ISongPlayer
    {
        /// <summary>
        /// A factory that can create ISong objects.
        /// </summary>
        ISongFactory Factory { get; }

        /// <summary>
        /// Whether or not the currently playing song should repeat.
        /// </summary>
        bool IsRepeating { get; set; }

        /// <summary>
        /// Whether or not song playback is muted.
        /// </summary>
        bool IsMuted { get; set; }

        /// <summary>
        /// The volume, between 0 and 1, to play the song at.
        /// </summary>
        float Volume { get; set; }

        /// <summary>
        /// The current position that song playback is at.
        /// </summary>
        TimeSpan PlayPosition { get; }

        /// <summary>
        /// Play the supplied song.
        /// </summary>
        /// <param name="song">The song to play.</param>
        void Play(ISong song);

        /// <summary>
        /// Play the supplied song at, starting at the supplied position.
        /// </summary>
        /// <param name="song">The song to play.</param>
        /// <param name="startPosition">The position to start playback at.</param>
        void Play(ISong song, TimeSpan startPosition);

        /// <summary>
        /// Stop any currently playing song.
        /// </summary>
        void Stop();
    }
}
