namespace ArbitraryPixel.Common.Graphics
{
    /// <summary>
    /// Represents an object with functionality to manage a graphics device.
    /// </summary>
    public interface IGrfxDeviceManager
    {
        /// <summary>
        /// The graphics device object this manager manages.
        /// </summary>
        IGrfxDevice GraphicsDevice { get; }

        /// <summary>
        /// The preferred width of the screen buffer.
        /// </summary>
        int PreferredBackBufferWidth { get; set; }

        /// <summary>
        /// The preferred height of the screen buffer.
        /// </summary>
        int PreferredBackBufferHeight { get; set; }

        /// <summary>
        /// Whether or not the device is created as full screen.
        /// </summary>
        bool IsFullScreen { get; set; }

        /// <summary>
        /// Apply this object's changes to the device it owns.
        /// </summary>
        void ApplyChanges();
    }
}
