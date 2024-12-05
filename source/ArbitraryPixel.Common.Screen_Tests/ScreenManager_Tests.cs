using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArbitraryPixel.Common.Screen;
using Microsoft.Xna.Framework;
using NSubstitute;
using ArbitraryPixel.Common.Graphics;
using Microsoft.Xna.Framework.Graphics;
using ArbitraryPixel.Common.Graphics.Factory;

namespace ArbitraryPixel.Common.Screen_Tests
{
    #region Helper Class
    public static partial class Extensions
    {
        private const float FLOAT_TOLERANCE = 0.00001f;

        public static bool AlmostEqual(this float me, float other)
        {
            return (Math.Abs(me - other) < FLOAT_TOLERANCE);
        }

        public static bool AlmostEqual(this Vector2 me, Vector2 other)
        {
            return (me.X.AlmostEqual(other.X) && me.Y.AlmostEqual(other.Y));
        }
    }
    #endregion

    [TestClass]
    public class ScreenManager_Tests
    {
        private ScreenManager _sut = null;

        private IGrfxDeviceManager _mockGrfxDeviceManager = null;
        private IGrfxDevice _mockGrfxDevice = null;

        [TestInitialize]
        public void Initialize()
        {
            _mockGrfxDevice = Substitute.For<IGrfxDevice>();
            _mockGrfxDeviceManager = Substitute.For<IGrfxDeviceManager>();

            _mockGrfxDeviceManager.GraphicsDevice.Returns(_mockGrfxDevice);

            _sut = new ScreenManager()
            {
                World = new Point(1000, 500),
                Screen = new Point(1500, 1000),
            };
        }

        #region Property Tests
        [TestMethod]
        public void OptionsShouldDefaultNull()
        {
            Assert.IsNull(_sut.Options);
        }

        [TestMethod]
        public void OptionsShouldReturnSetValue()
        {
            ScreenManagerOptions options = new ScreenManagerOptions(Substitute.For<ISpriteBatch>());
            _sut.Options = options;

            Assert.AreSame(options, _sut.Options);
        }

        [TestMethod]
        public void WorldShouldReturnSetValue()
        {
            Assert.AreEqual<Point>(new Point(1000, 500), _sut.World);
        }

        [TestMethod]
        public void ScreenShouldReturnValue()
        {
            Assert.AreEqual<Point>(new Point(1500, 1000), _sut.Screen);
        }

        [TestMethod]
        public void IsFullScreenShouldDefaultFalse()
        {
            Assert.IsFalse(_sut.IsFullScreen);
        }

        [TestMethod]
        public void IsFullScreenShouldReturnsetValue()
        {
            _sut.IsFullScreen = true;
            Assert.IsTrue(_sut.IsFullScreen);
        }
        #endregion

        #region ApplySettings Tests
        [TestMethod]
        public void ApplySettingsShouldSetManagerPreferredBackBufferWidth()
        {
            _sut.ApplySettings(_mockGrfxDeviceManager);

            _mockGrfxDeviceManager.Received(1).PreferredBackBufferWidth = _sut.Screen.X;
        }

        [TestMethod]
        public void ApplySettingsShouldSetManagerPreferredBackBufferHeight()
        {
            _sut.ApplySettings(_mockGrfxDeviceManager);

            _mockGrfxDeviceManager.Received(1).PreferredBackBufferHeight = _sut.Screen.Y;
        }

        [TestMethod]
        public void ApplySettingsShouldSetManagerIsFullScreen()
        {
            _sut.ApplySettings(_mockGrfxDeviceManager);

            _mockGrfxDeviceManager.Received(1).IsFullScreen = _sut.IsFullScreen;
        }

        [TestMethod]
        public void ApplySettingsShouldCallManagerApplyChanges()
        {
            _sut.ApplySettings(_mockGrfxDeviceManager);

            _mockGrfxDeviceManager.Received(1).ApplyChanges();
        }
        #endregion

        #region BeginDraw Tests
        [TestMethod]
        public void BeginDrawShouldCallDeviceClear()
        {
            _sut.BeginDraw(_mockGrfxDevice);

            _mockGrfxDevice.Received(1).Clear(Color.Black);
        }

        [TestMethod]
        public void BeginDrawShouldSetDeviceViewportToScreen()
        {
            _sut.BeginDraw(_mockGrfxDevice);

            _mockGrfxDevice.Received(1).Viewport = new Viewport(0, 0, _sut.Screen.X, _sut.Screen.Y, 0, 1);
        }

        [TestMethod]
        public void BeginDrawShouldSetDeviceViewportToScaledViewport()
        {
            _sut.BeginDraw(_mockGrfxDevice);

            _mockGrfxDevice.Received(1).Viewport = new Viewport(0, 125, 1500, 750, 0, 1);
        }

        [TestMethod]
        public void BeginDraw_OptionsSet_WithNoBackgroundsShouldNotCallSpriteBatchBegin()
        {
            ISpriteBatch mockSpriteBatch = Substitute.For<ISpriteBatch>();
            ScreenManagerOptions options = new ScreenManagerOptions(mockSpriteBatch);
            _sut.Options = options;

            _sut.BeginDraw(_mockGrfxDevice);

            mockSpriteBatch.Received(0).Begin();
        }

        [TestMethod]
        public void BeginDraw_OptionsSet_WithNoBackgroundsShouldNotCallSpriteBatchEnd()
        {
            ISpriteBatch mockSpriteBatch = Substitute.For<ISpriteBatch>();
            ScreenManagerOptions options = new ScreenManagerOptions(mockSpriteBatch);
            _sut.Options = options;

            _sut.BeginDraw(_mockGrfxDevice);

            mockSpriteBatch.Received(0).End();
        }

        [TestMethod]
        public void BeginDraw_OptionsSet_WithNoBackgroundsShouldNotCallSpriteBatchDraw()
        {
            ISpriteBatch mockSpriteBatch = Substitute.For<ISpriteBatch>();
            ScreenManagerOptions options = new ScreenManagerOptions(mockSpriteBatch);
            _sut.Options = options;

            _sut.BeginDraw(_mockGrfxDevice);

            mockSpriteBatch.Received(0).Draw(Arg.Any<ITexture2D>(), Arg.Any<Rectangle>(), Arg.Any<Color>());
        }

        [TestMethod]
        public void BeginDraw_OptionsSet_WithScreenBackgroundShouldDrawScreenBackground()
        {
            ITexture2D mockTexture = Substitute.For<ITexture2D>();
            ISpriteBatch mockSpriteBatch = Substitute.For<ISpriteBatch>();
            ScreenManagerOptions options = new ScreenManagerOptions(mockSpriteBatch);
            options.ScreenBackground = new BackgroundTextureDefinition(mockTexture, Color.Pink);
            _sut.Options = options;

            _sut.BeginDraw(_mockGrfxDevice);

            Received.InOrder(
                () =>
                {
                    mockSpriteBatch.Begin();
                    mockSpriteBatch.Draw(mockTexture, new Rectangle(0, 0, 1500, 1000), Color.Pink);
                    mockSpriteBatch.End();
                }
            );
        }

        [TestMethod]
        public void BeginDraw_OptionsSet_WithScreenBackgroundShouldDrawWorldBackground()
        {
            ITexture2D mockTexture = Substitute.For<ITexture2D>();
            ISpriteBatch mockSpriteBatch = Substitute.For<ISpriteBatch>();
            ScreenManagerOptions options = new ScreenManagerOptions(mockSpriteBatch);
            options.WorldBackground = new BackgroundTextureDefinition(mockTexture, Color.Pink);
            _sut.Options = options;

            _sut.BeginDraw(_mockGrfxDevice);

            Received.InOrder(
                () =>
                {
                    mockSpriteBatch.Begin();
                    mockSpriteBatch.Draw(mockTexture, new Rectangle(0, 0, 1500, 750), Color.Pink);
                    mockSpriteBatch.End();
                }
            );
        }
        #endregion

        #region Point Conversion Tests
        [TestMethod]
        public void PointToWorldWithVector2ShoudlReturnExpectedValue()
        {
            Assert.IsTrue(Vector2.Zero.AlmostEqual(_sut.PointToWorld(new Vector2(0, 125))));
        }

        [TestMethod]
        public void PointToWorldWithPointShoudlReturnExpectedValue()
        {
            Assert.IsTrue(Vector2.Zero.AlmostEqual(_sut.PointToWorld(new Point(0, 125))));
        }

        [TestMethod]
        public void PointToScreenWithVector2ShouldReturnExpectedValue()
        {
            Vector2 actual = _sut.PointToScreen(Vector2.Zero);
            Assert.AreEqual<Vector2>(new Vector2(0, 125), actual);
        }

        [TestMethod]
        public void PointToScreenWithPointShouldReturnExpectedValue()
        {
            Vector2 actual = _sut.PointToScreen(Point.Zero);
            Assert.AreEqual<Vector2>(new Vector2(0, 125), actual);
        }
        #endregion

        #region Scale Tests
        [TestMethod]
        public void ScaleShouldBeExpectedValue()
        {
            Assert.AreEqual<Vector3>(new Vector3(1.5f, 1.5f, 1f), _sut.Scale);
        }

        [TestMethod]
        public void ScaleShouldUpdateToExpectedValueWhenScreenChanges()
        {
            _sut.Screen = new Point(1600, 1000);
            Assert.AreEqual<Vector3>(new Vector3(1.6f, 1.6f, 1f), _sut.Scale);
        }

        [TestMethod]
        public void ScaleShouldUpdateToExpectedValueWhenWorldChanges()
        {
            _sut.World = new Point(500, 500);
            Assert.AreEqual<Vector3>(new Vector3(2f, 2f, 1f), _sut.Scale);
        }
        #endregion

        #region ScaleMatrix Tests
        [TestMethod]
        public void ScaleMatrixShouldBeExpectedValue()
        {
            Matrix expected = Matrix.CreateScale(_sut.Scale);

            Assert.AreEqual<Matrix>(expected, _sut.ScaleMatrix);
        }

        [TestMethod]
        public void ScaleMatrixShouldUpdateToDifferentValueWhenScreenChanges()
        {
            Matrix old = _sut.ScaleMatrix;
            _sut.Screen = new Point(1600, 1000);

            Assert.AreNotEqual<Matrix>(old, _sut.ScaleMatrix);
        }

        [TestMethod]
        public void ScaleMatrixShouldUpdateToDifferentValueWhenWorldChanges()
        {
            Matrix old = _sut.ScaleMatrix;
            _sut.World = new Point(1100, 500);

            Assert.AreNotEqual<Matrix>(old, _sut.ScaleMatrix);
        }

        [TestMethod]
        public void ScaleMatrixShouldUpdateToExpectedValueWhenScreenChanges()
        {
            _sut.Screen = new Point(1600, 1000);

            Matrix expected = Matrix.CreateScale(_sut.Scale);

            Assert.AreEqual<Matrix>(expected, _sut.ScaleMatrix);
        }

        [TestMethod]
        public void ScaleMatrixShouldUpdateToExpectedValueWhenWorldChanges()
        {
            _sut.World = new Point(1100, 500);

            Matrix expected = Matrix.CreateScale(_sut.Scale);

            Assert.AreEqual<Matrix>(expected, _sut.ScaleMatrix);
        }
        #endregion
    }
}
