using ArbitraryPixel.Common.Graphics;
using ArbitraryPixel.Common.Graphics.Factory;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ArbitraryPixel.Common.Screen
{
    /// <summary>
    /// An object that manages resolution scaling for screens, scaling up the world to best fit the screen area while maintaining aspect ratio.
    /// </summary>
    public class ScreenManager : IScreenManager
    {
        #region Private Members
        private Viewport _viewport = new Viewport(0, 0, 1, 1);
        private bool _matrixNeedsUpdate = false;
        private Matrix _scaleMatrix = Matrix.Identity;
        #endregion

        #region Public Properties
        /// <summary>
        /// The unscaled world size.
        /// </summary>
        public Point World
        {
            get { return _world; }
            set
            {
                if (value != _world)
                {
                    _world = value;
                    CalculateViewport();
                }
            }
        }
        private Point _world = new Point(1, 1);

        /// <summary>
        /// The screen size.
        /// </summary>
        public Point Screen
        {
            get { return _screen; }
            set
            {
                if (value != _screen)
                {
                    _screen = value;
                    CalculateViewport();
                }
            }
        }
        private Point _screen = new Point(1, 1);

        /// <summary>
        /// True if fullscreen is desired, False if windows behaviour is desired.
        /// </summary>
        public bool IsFullScreen { get; set; } = false;

        /// <summary>
        /// The scale of this screen manager's screen size to its world size.
        /// </summary>
        public Vector3 Scale
        {
            get
            {
                return new Vector3(
                    _viewport.Width / (float)this.World.X,
                    _viewport.Height / (float)this.World.Y,
                    1f
                );
            }
        }

        /// <summary>
        /// The scale matrix for this ScreenManager
        /// </summary>
        public Matrix ScaleMatrix
        {
            get
            {
                if (_matrixNeedsUpdate)
                {
                    _scaleMatrix = Matrix.CreateScale(this.Scale);
                }

                return _scaleMatrix;
            }
        }

        /// <summary>
        /// The options for this screen manager.
        /// </summary>
        public ScreenManagerOptions Options { get; set; } = null;
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Construct a new object.
        /// </summary>
        public ScreenManager()
        {
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Convert a point in screen coordinates to world coorindates.
        /// </summary>
        /// <param name="screenPoint">A point relative to screen coordinates</param>
        /// <returns>The point converted to world coordinates.</returns>
        public Vector2 PointToWorld(Vector2 screenPoint)
        {
            Vector2 worldPoint = screenPoint;

            Vector3 scale = this.Scale;

            worldPoint.X /= scale.X;
            worldPoint.Y /= scale.Y;

            worldPoint.X -= _viewport.X / scale.X;
            worldPoint.Y -= _viewport.Y / scale.Y;

            return worldPoint;
        }

        /// <summary>
        /// Convert a point in screen coordinates to world coorindates.
        /// </summary>
        /// <param name="screenPoint">A point relative to screen coordinates</param>
        /// <returns>The point converted to world coordinates.</returns>
        public Vector2 PointToWorld(Point screenPoint)
        {
            return PointToWorld(new Vector2(screenPoint.X, screenPoint.Y));
        }

        /// <summary>
        /// Convert a point in world coordiantes to screen coordinates.
        /// </summary>
        /// <param name="worldPoint">A point relative to world coordinates.</param>
        /// <returns>The point converted to screen coordinates.</returns>
        public Vector2 PointToScreen(Vector2 worldPoint)
        {
            Vector2 screenPoint = worldPoint;

            Vector3 scale = this.Scale;

            screenPoint.X += _viewport.X / scale.X;
            screenPoint.Y += _viewport.Y / scale.Y;

            screenPoint.X *= scale.X;
            screenPoint.Y *= scale.Y;

            return screenPoint;
        }

        /// <summary>
        /// Convert a point in world coordiantes to screen coordinates.
        /// </summary>
        /// <param name="worldPoint">A point relative to world coordinates.</param>
        /// <returns>The point converted to screen coordinates.</returns>
        public Vector2 PointToScreen(Point worldPoint)
        {
            return PointToScreen(new Vector2(worldPoint.X, worldPoint.Y));
        }

        /// <summary>
        /// Apply this screen manager's settings to the specified graphics device manager object. This should be called during initialization, or when screen dimensions need to change.
        /// </summary>
        /// <param name="manager">An object responsible for managing a graphics device.</param>
        public void ApplySettings(IGrfxDeviceManager manager)
        {
            manager.PreferredBackBufferWidth = this.Screen.X;
            manager.PreferredBackBufferHeight = this.Screen.Y;
            manager.IsFullScreen = this.IsFullScreen;

            manager.ApplyChanges();
        }

        /// <summary>
        /// Set the specified graphics device up for rendering. This should be called at the start of a draw/render pass.
        /// </summary>
        /// <param name="device">An object responisible for representing a graphics device.</param>
        public void BeginDraw(IGrfxDevice device)
        {
            device.Clear(Color.Black);

            device.Viewport = new Viewport(0, 0, this.Screen.X, this.Screen.Y);
            if (this.Options != null && this.Options.ScreenBackground != null)
            {
                this.Options.SpriteBatch.Begin();
                this.Options.SpriteBatch.Draw(this.Options.ScreenBackground.Texture, new Rectangle(0, 0, this.Screen.X, this.Screen.Y), this.Options.ScreenBackground.Mask);
                this.Options.SpriteBatch.End();
            }

            device.Viewport = _viewport;

            if (this.Options != null && this.Options.WorldBackground != null)
            {
                this.Options.SpriteBatch.Begin();
                this.Options.SpriteBatch.Draw(this.Options.WorldBackground.Texture, new Rectangle(0, 0, _viewport.Width, _viewport.Height), this.Options.WorldBackground.Mask);
                this.Options.SpriteBatch.End();
            }
        }
        #endregion

        #region Private Methods
        private void CalculateViewport()
        {
            float worldAspectRatio = this.World.X / (float)this.World.Y;

            int width = (int)this.Screen.X;
            int height = (int)(width / worldAspectRatio + 0.5f);

            if (height > this.Screen.Y)
            {
                height = this.Screen.Y;
                width = (int)(height * worldAspectRatio + 0.5f);
            }

            _viewport = new Viewport();
            _viewport.X = (this.Screen.X / 2) - (width / 2);
            _viewport.Y = (this.Screen.Y / 2) - (height / 2);
            _viewport.Width = width;
            _viewport.Height = height;
            _viewport.MinDepth = 0;
            _viewport.MaxDepth = 1;

            _matrixNeedsUpdate = true;
        }
        #endregion
    }
}
