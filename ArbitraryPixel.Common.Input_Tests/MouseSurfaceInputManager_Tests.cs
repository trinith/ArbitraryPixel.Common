using ArbitraryPixel.Common.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using NSubstitute;
using System;

namespace ArbitraryPixel.Common.Input_Tests
{
    [TestClass]
    public class MouseSurfaceInputManager_Tests
    {
        private IMouseManager _mockMouseManager;
        private IMouseState _mockMouseState;

        private MouseSurfaceInputManager _sut;

        [TestInitialize]
        public void Initialize()
        {
            _mockMouseState = Substitute.For<IMouseState>();
            _mockMouseManager = Substitute.For<IMouseManager>();

            _mockMouseManager.GetState().Returns(_mockMouseState);

            _sut = new MouseSurfaceInputManager(_mockMouseManager);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullMouseManagerShouldThrowException()
        {
            _sut = new MouseSurfaceInputManager(null);
        }
        #endregion

        #region IsActive Tests
        [TestMethod]
        public void IsActiveShouldDefaultFalse()
        {
            Assert.IsFalse(_sut.IsActive);
        }

        [TestMethod]
        public void IsActiveShouldReturnTrueWhenSetToTrue()
        {
            _sut.IsActive = true;
            Assert.IsTrue(_sut.IsActive);
        }

        [TestMethod]
        public void IsActiveShouldReturnFalseWhenSetToFalse()
        {
            _sut.IsActive = false;
            Assert.IsFalse(_sut.IsActive);
        }
        #endregion

        #region GetSurfaceState Tests - Legacy Functionality
        [TestMethod]
        public void GetSurfaceStateShouldReturnExpectedMousePosition_TestA()
        {
            _mockMouseState.Position.Returns(new Point(100, 200));
            _sut.Update(new GameTime());
            SurfaceState state = _sut.GetSurfaceState();
            Assert.AreEqual<Vector2>(new Vector2(100, 200), state.SurfaceLocation);
        }

        [TestMethod]
        public void GetSurfaceStateShouldReturnExpectedMousePosition_TestB()
        {
            _mockMouseState.Position.Returns(new Point(400, 175));
            _sut.Update(new GameTime());
            SurfaceState state = _sut.GetSurfaceState();
            Assert.AreEqual<Vector2>(new Vector2(400, 175), state.SurfaceLocation);
        }

        [TestMethod]
        public void GetSurfaceStateShouldSetIsTouchedFalseWhenNoButtonsPressed()
        {
            Assert.IsFalse(_sut.GetSurfaceState().IsTouched);
        }

        [TestMethod]
        public void GetSurfaceStateShouldSetIsTouchedTrueWhenButtonPressed()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());
            Assert.IsTrue(_sut.GetSurfaceState().IsTouched);
        }
        #endregion

        #region GetSurfaceState Tests
        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedTouchId()
        {
            _sut.Update(new GameTime());

            Assert.AreEqual<int>(0, _sut.GetSurfaceState().Touches[0].Id);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveCorrectPosition()
        {
            _mockMouseState.Position.Returns(new Point(123, 456));
            _sut.Update(new GameTime());

            Assert.AreEqual<Vector2>(new Vector2(123, 456), _sut.GetSurfaceState().Touches[0].Position);
        }

        [TestMethod]
        public void GetSurfaceStateAfterSecondUpdateShouldHaveCorrectPosition()
        {
            _mockMouseState.Position.Returns(new Point(123, 456));
            _sut.Update(new GameTime());

            _mockMouseState.Position.Returns(new Point(321, 654));
            _sut.Update(new GameTime());

            Assert.AreEqual<Vector2>(new Vector2(321, 654), _sut.GetSurfaceState().Touches[0].Position);
        }

        [TestMethod]
        public void GetSurfaceStateAfterSecondUpdateShouldHaveCorrectPreviousPosition()
        {
            _mockMouseState.Position.Returns(new Point(123, 456));
            _sut.Update(new GameTime());

            _mockMouseState.Position.Returns(new Point(321, 654));
            _sut.Update(new GameTime());

            TouchLocation previousTouch;
            var result = _sut.GetSurfaceState().Touches[0].TryGetPreviousLocation(out previousTouch);

            Assert.AreEqual<Vector2>(new Vector2(123, 456), previousTouch.Position);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedState_Pressed()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Pressed, _sut.GetSurfaceState().Touches[0].State);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedState_Moved()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());
            _sut.Update(new GameTime());

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Moved, _sut.GetSurfaceState().Touches[0].State);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedState_Released()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());
            _mockMouseState.ButtonPressed.Returns(false);
            _sut.Update(new GameTime());

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Released, _sut.GetSurfaceState().Touches[0].State);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedPreviousState_Released()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());

            TouchLocation previousTouch;
            _sut.GetSurfaceState().Touches[0].TryGetPreviousLocation(out previousTouch);

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Released, previousTouch.State);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedPreviousState_Pressed()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());
            _sut.Update(new GameTime());

            TouchLocation previousTouch;
            _sut.GetSurfaceState().Touches[0].TryGetPreviousLocation(out previousTouch);

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Pressed, previousTouch.State);
        }

        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldHaveExpectedPreviousState_Moved()
        {
            _mockMouseState.ButtonPressed.Returns(true);
            _sut.Update(new GameTime());
            _sut.Update(new GameTime());
            _mockMouseState.ButtonPressed.Returns(false);
            _sut.Update(new GameTime());

            TouchLocation previousTouch;
            _sut.GetSurfaceState().Touches[0].TryGetPreviousLocation(out previousTouch);

            Assert.AreEqual<TouchLocationState>(TouchLocationState.Moved, previousTouch.State);
        }
        #endregion

        #region Global Consumer Checking Tests
        [TestMethod]
        public void ShouldConsumeInputShouldReturnTrueWithNoConsumerSet()
        {
            object consumer = new object();
            Assert.IsTrue(_sut.ShouldConsumeInput(consumer));
        }

        [TestMethod]
        public void ShouldConsumeInputShouldReturnTrueWithSetConsumerUsingThatConsumer()
        {
            object consumer = new object();
            _sut.SetConsumer(consumer);

            Assert.IsTrue(_sut.ShouldConsumeInput(consumer));
        }

        [TestMethod]
        public void ShouldConsumeInputShouldReturnFalseWithSetConsumerUsingDifferentConsumer()
        {
            object c1 = new object();
            object c2 = new object();
            _sut.SetConsumer(c1);

            Assert.IsFalse(_sut.ShouldConsumeInput(c2));
        }

        [TestMethod]
        public void ShouldCOnsumeInputShouldReturnTrueWithClearedConsumer()
        {
            object c1 = new object();
            object c2 = new object();
            _sut.SetConsumer(c1);
            _sut.ClearConsumer();

            Assert.IsTrue(_sut.ShouldConsumeInput(c2));
        }
        #endregion

        #region Touch Id Consumer Checking Tests
        [TestMethod]
        public void ShouldConsumeInputWithoutGlobalConsumerAndUnconsumedTouchShouldReturnTrue()
        {
            object consumer = new object();

            Assert.IsTrue(_sut.ShouldConsumeInput(123, consumer));
        }

        [TestMethod]
        public void ShouldConsumeInputWithoutGlobalConsumerAndConsumedTouchSameConsumerShouldReturnTrue()
        {
            object consumer = new object();
            _sut.SetConsumer(123, consumer);

            Assert.IsTrue(_sut.ShouldConsumeInput(123, consumer));
        }

        [TestMethod]
        public void ShouldConsumeInputWithoutGlobalConsumerAndConsumedTouchDifferentConsumerShouldReturnFalse()
        {
            object consumerA = new object();
            object consumerB = new object();
            _sut.SetConsumer(123, consumerA);

            Assert.IsFalse(_sut.ShouldConsumeInput(123, consumerB));
        }

        [TestMethod]
        public void ShouldConsumeInputAfterConsumerClearShouldReturnTrue()
        {
            object consumerA = new object();
            object consumerB = new object();
            _sut.SetConsumer(123, consumerA);
            _sut.ClearConsumer(123);

            Assert.IsTrue(_sut.ShouldConsumeInput(123, consumerB));
        }

        [TestMethod]
        public void ShouldConsumeInputWithGlobalConsumerAndUnconsumedTouchOnDifferentConsumerShouldReturnFalse()
        {
            object globalConsumer = new object();
            object touchConsumer = new object();
            _sut.SetConsumer(globalConsumer);

            Assert.IsFalse(_sut.ShouldConsumeInput(123, touchConsumer));
        }

        [TestMethod]
        public void ShouldConsumeInputWithGlobalConsumerAndUnConsumedTouchOnGlobalConsumerShouldReturnTrue()
        {
            object globalConsumer = new object();
            _sut.SetConsumer(globalConsumer);

            Assert.IsTrue(_sut.ShouldConsumeInput(123, globalConsumer));
        }

        [TestMethod]
        [ExpectedException(typeof(TouchAlreadyConsumedException))]
        public void SetConsumerWithConsumedTouchFromDifferentConsumerShouldThrowException()
        {
            object consumerA = new object();
            object consumerB = new object();
            _sut.SetConsumer(123, consumerA);

            _sut.SetConsumer(123, consumerB);
        }
        #endregion
    }
}
