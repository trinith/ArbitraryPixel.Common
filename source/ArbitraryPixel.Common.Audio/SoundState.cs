namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// The current state of sound playback.
    /// </summary>
    public enum SoundState
    {
        /// <summary>
        /// The sound is currently playing.
        /// </summary>
        Playing = 0,

        /// <summary>
        /// The sound is currently paused.
        /// </summary>
        Paused = 1,

        /// <summary>
        /// The sound is currently stopped.
        /// </summary>
        Stopped = 2
    }
}
