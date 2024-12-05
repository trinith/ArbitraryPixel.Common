using ArbitraryPixel.Common.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using NSubstitute;
using System;
using System.Linq;

namespace ArbitraryPixel.Common.Input_Tests
{
    [TestClass]
    public class TouchScreenSurfaceInputManager_Tests
    {
        ITouchPanelManager _mockTouchManager;

        TouchScreenSurfaceInputManager _sut;

        [TestInitialize]
        public void Initialize()
        {
            _mockTouchManager = Substitute.For<ITouchPanelManager>();

            _sut = new TouchScreenSurfaceInputManager(_mockTouchManager);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorWithNullTouchPanelManagerShouldThrowException()
        {
            _sut = new TouchScreenSurfaceInputManager(null);
        }
        #endregion

        #region IsActive Tests
        [TestMethod]
        public void IsActiveShouldDefaultFalse()
        {
            Assert.IsFalse(_sut.IsActive);
        }

        [TestMethod]
        public void IsActiveShouldReturnFalseWhenSetToFalse()
        {
            _sut.IsActive = false;
            _sut.IsActive = true;
            Assert.IsTrue(_sut.IsActive);
        }

        [TestMethod]
        public void IsActiveShouldReturnFalseWhenSetToTrue()
        {
            _sut.IsActive = true;
            _sut.IsActive = false;
            Assert.IsFalse(_sut.IsActive);
        }
        #endregion

        #region GetSurfaceStateTests
        [TestMethod]
        public void GetSurfaceStateAfterUpdateShouldReturnExpectedTouchCollection()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Invalid, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Pressed, new Vector2(400, 100));
            TouchCollection touches = new TouchCollection(new TouchLocation[] { touchA, touchB });
            _mockTouchManager.GetState().Returns(touches);

            _sut.Update(new GameTime());

            Assert.IsTrue(_sut.GetSurfaceState().Touches.ToList().SequenceEqual(new TouchLocation[] { touchA, touchB }));
        }

        [TestMethod]
        public void GetSurfaceStateSubsequentCallAfterUpdateShouldReturnExpectedTouchCollection()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Invalid, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Pressed, new Vector2(400, 100));
            TouchCollection touches = new TouchCollection(new TouchLocation[] { touchA, touchB });
            _mockTouchManager.GetState().Returns(touches);

            _sut.Update(new GameTime());

            var firstState = _sut.GetSurfaceState();
            var secondState = _sut.GetSurfaceState();

            Assert.IsTrue(firstState.Touches.Count == secondState.Touches.Count);
            Assert.IsTrue(firstState.Touches.ToList().SequenceEqual(secondState.Touches.ToList()));
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
