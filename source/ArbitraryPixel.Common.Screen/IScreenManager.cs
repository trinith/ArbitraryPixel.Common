using ArbitraryPixel.Common.Graphics;
using Microsoft.Xna.Framework;
using System;

namespace ArbitraryPixel.Common.Screen
{
    /// <summary>
    /// Represents an object that manages the screen.
    /// </summary>
    public interface IScreenManager
    {
        #region Properties
        /// <summary>
        /// Whether or not this screen manager should be in full screen mode.
        /// </summary>
        bool IsFullScreen { get; set; }

        /// <summary>
        /// The current scale of this screen manager.
        /// </summary>
        Vector3 Scale { get; }

        /// <summary>
        /// A matrix representing the current scale of this screen manager.
        /// </summary>
        Matrix ScaleMatrix { get; }

        /// <summary>
        /// The dimensions of this manager's screen space.
        /// </summary>
        Point Screen { get; set; }

        /// <summary>
        /// The dimensions of this manager's world space.
        /// </summary>
        Point World { get; set; }

        /// <summary>
        /// Options that specify parameters to be used during BeginDraw.
        /// </summary>
        ScreenManagerOptions Options { get; set; }
        #endregion

        #region Methods
        /// <summary>
        /// Apply this screen manager's settings to the specified graphics device manager object. This should be called during initialization, or when screen dimensions need to change.
        /// </summary>
        /// <param name="manager">An object responsible for managing a graphics device.</param>
        void ApplySettings(IGrfxDeviceManager manager);

        /// <summary>
        /// Set the specified graphics device up for rendering. This should be called at the start of a draw/render pass.
        /// </summary>
        /// <param name="device">An object responisible for representing a graphics device.</param>
        void BeginDraw(IGrfxDevice device);

        /// <summary>
        /// Convert a point in world coordiantes to screen coordinates.
        /// </summary>
        /// <param name="worldPoint">A point relative to world coordinates.</param>
        /// <returns>The point converted to screen coordinates.</returns>
        Vector2 PointToScreen(Point worldPoint);

        /// <summary>
        /// Convert a point in world coordiantes to screen coordinates.
        /// </summary>
        /// <param name="worldPoint">A point relative to world coordinates.</param>
        /// <returns>The point converted to screen coordinates.</returns>
        Vector2 PointToScreen(Vector2 worldPoint);

        /// <summary>
        /// Convert a point in screen coordinates to world coorindates.
        /// </summary>
        /// <param name="screenPoint">A point relative to screen coordinates</param>
        /// <returns>The point converted to world coordinates.</returns>
        Vector2 PointToWorld(Point screenPoint);

        /// <summary>
        /// Convert a point in screen coordinates to world coorindates.
        /// </summary>
        /// <param name="screenPoint">A point relative to screen coordinates</param>
        /// <returns>The point converted to world coordinates.</returns>
        Vector2 PointToWorld(Vector2 screenPoint);
        #endregion
    }
}