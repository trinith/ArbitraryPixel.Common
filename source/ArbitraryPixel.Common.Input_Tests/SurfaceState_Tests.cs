using ArbitraryPixel.Common.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input.Touch;
using System.Linq;

namespace ArbitraryPixel.Common.Input_Tests
{
    [TestClass]
    public class SurfaceState_Tests
    {
        private SurfaceState _sut;

        #region Constructor Tests
        [TestMethod]
        public void DefaultConstructorShouldGiveExpectedSurfaceLocation()
        {
            Assert.AreEqual<Vector2>(Vector2.Zero, _sut.SurfaceLocation);
        }

        [TestMethod]
        public void DefaultConstructorShouldGiveExpectedIsTouched()
        {
            Assert.AreEqual<bool>(false, _sut.IsTouched);
        }

        [TestMethod]
        public void DefaultConstructorShouldGiveEmptyTouchCollection()
        {
            Assert.AreEqual<int>(0, _sut.Touches.Count);
        }

        [TestMethod]
        public void ConstructWithTouchesShouldSetTouchesToExpectedValue()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Moved, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Pressed, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsTrue(_sut.Touches.ToList().SequenceEqual(new TouchLocation[] { touchA, touchB }));
        }
        #endregion

        #region SurfaceLocation Tests
        [TestMethod]
        public void SurfaceLocationWithEmptyTouchesShouldReturnDefaultVector()
        {
            Assert.AreEqual<Vector2>(default(Vector2), _sut.SurfaceLocation);
        }

        [TestMethod]
        public void SurfaceLocationWithNonEmptyTouchesShouldReturnFirstTouchPosition_TestA()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Moved, new Vector2(200, 300));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA }));

            Assert.AreEqual<Vector2>(new Vector2(200, 300), _sut.SurfaceLocation);
        }

        [TestMethod]
        public void SurfaceLocationWithNonEmptyTouchesShouldReturnFirstTouchPosition_TestB()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Moved, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Pressed, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.AreEqual<Vector2>(new Vector2(200, 300), _sut.SurfaceLocation);
        }
        #endregion

        #region IsTouched Tests
        [TestMethod]
        public void IsTouchedWithEmptyTouchesShouldReturnFalse()
        {
            Assert.IsFalse(_sut.IsTouched);
        }

        [TestMethod]
        public void IsTouchedWithNonEmptyTouchesAndPressedTouchShouldReturnTrue_TestA()
        {
            // Index 0
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Pressed, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Invalid, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsTrue(_sut.IsTouched);
        }

        [TestMethod]
        public void IsTouchedWithNonEmptyTouchesAndPressedTouchShouldReturnTrue_TestB()
        {
            // Index 1
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Invalid, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Pressed, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsTrue(_sut.IsTouched);
        }

        [TestMethod]
        public void IsTouchedWithNonEmptyTouchesAndMovedTouchShouldReturnTrue_TestA()
        {
            // Index 0
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Moved, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Invalid, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsTrue(_sut.IsTouched);
        }

        [TestMethod]
        public void IsTouchedWithNonEmptyTouchesAndMovedTouchShouldReturnTrue_TestB()
        {
            // Index 1
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Invalid, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Moved, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsTrue(_sut.IsTouched);
        }

        [TestMethod]
        public void IsTouchedWithNonEmptyTouchesButNotTouchedShouldReturnFalse()
        {
            TouchLocation touchA = new TouchLocation(123, TouchLocationState.Invalid, new Vector2(200, 300));
            TouchLocation touchB = new TouchLocation(444, TouchLocationState.Released, new Vector2(400, 100));
            _sut = new SurfaceState(new TouchCollection(new TouchLocation[] { touchA, touchB }));

            Assert.IsFalse(_sut.IsTouched);
        }
        #endregion
    }
}
