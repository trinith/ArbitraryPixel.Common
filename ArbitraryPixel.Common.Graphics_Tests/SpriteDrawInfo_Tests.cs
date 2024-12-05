using ArbitraryPixel.Common.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArbitraryPixel.Common.Graphics_Tests
{
    [TestClass]
    public class SpriteDrawInfo_Tests
    {
        private SpriteDrawInfo _sut;

        private void Construct()
        {
            _sut = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );
        }

        #region Constructor Tests
        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Position()
        {
            Construct();

            Assert.AreEqual(new Vector2(123, 456), _sut.Position);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Mask()
        {
            Construct();

            Assert.AreEqual(Color.Pink, _sut.Mask);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Rotation()
        {
            Construct();

            Assert.AreEqual(123f, _sut.Rotation);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Origin()
        {
            Construct();

            Assert.AreEqual(new Vector2(456, 123), _sut.Origin);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Scale()
        {
            Construct();

            Assert.AreEqual(new Vector2(135, 246), _sut.Scale);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Effects()
        {
            Construct();

            Assert.AreEqual(SpriteEffects.FlipHorizontally, _sut.Effects);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_LayerDepth()
        {
            Construct();

            Assert.AreEqual(456f, _sut.LayerDepth);
        }
        #endregion

        #region Equals Tests
        [TestMethod]
        public void EqualsWithEquivalentObjectShouldReturnTrue()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            Assert.IsTrue(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Position()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Position = new Vector2(999);

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Mask()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Mask = Color.Teal;

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Rotation()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Rotation = 987f;

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Origin()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Origin = new Vector2(864);

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Scale()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Scale = new Vector2(789);

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_Effects()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Effects = SpriteEffects.FlipVertically;

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse_LayerDepth()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.LayerDepth = 44f;

            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonSpriteDrawInfoObjectShouldReturnFalse()
        {
            Construct();

            Assert.IsFalse(_sut.Equals("eleven twelve!!"));
        }

        [TestMethod]
        public void EqualsWithNullShouldReturnFalse()
        {
            Construct();

            Assert.IsFalse(_sut.Equals(null));
        }
        #endregion

        #region GetHashCode Tests
        [TestMethod]
        public void GetHashCodeShouldReturnExpectedValue()
        {
            Construct();

            int expected = 17;
            unchecked
            {
                expected = expected * 29 + _sut.Position.GetHashCode();
                expected = expected * 29 + _sut.Mask.GetHashCode();
                expected = expected * 29 + _sut.Rotation.GetHashCode();
                expected = expected * 29 + _sut.Origin.GetHashCode();
                expected = expected * 29 + _sut.Scale.GetHashCode();
                expected = expected * 29 + _sut.Effects.GetHashCode();
                expected = expected * 29 + _sut.LayerDepth.GetHashCode();
            }

            Assert.AreEqual(expected, _sut.GetHashCode());
        }
        #endregion

        #region Operator Tests (== and !=)
        [TestMethod]
        public void EqualsOperatorWithEquivalentObjectShouldReturnTrue()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            Assert.IsTrue(_sut == other);
        }

        [TestMethod]
        public void EqualsOperatorWithNonEquivalentObjectShouldReturnFalse()
        {
            // Only testing one property not being equal
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );
            other.Mask = Color.BlanchedAlmond;

            Assert.IsFalse(_sut == other);
        }

        [TestMethod]
        public void NotEqualsOperatorWithEquivalentObjectShouldReturnFalse()
        {
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            Assert.IsFalse(_sut != other);
        }

        [TestMethod]
        public void NotEqualsOperatorWithNonEquivalentObjectShouldReturnTrue()
        {
            // Only testing one property not being equal
            Construct();

            SpriteDrawInfo other = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.Pink,
                123f,
                new Vector2(456, 123),
                new Vector2(135, 246),
                SpriteEffects.FlipHorizontally,
                456f
            );

            other.Mask = Color.LavenderBlush;

            Assert.IsTrue(_sut != other);
        }
        #endregion

        #region Factory Tests
        [TestMethod]
        public void FactoryDefaultShouldCreateExpectedObject()
        {
            _sut = SpriteDrawInfo.Default;
            var expected = new SpriteDrawInfo(
                Vector2.Zero,
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1),
                SpriteEffects.None,
                0f
            );

            Assert.AreEqual(expected, _sut);
        }

        [TestMethod]
        public void FactoryMethodShouldCreateExpectedObject_Position_TestA()
        {
            _sut = SpriteDrawInfo.Create(new Vector2(123, 456));

            var expected = new SpriteDrawInfo(
                new Vector2(123, 456),
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1),
                SpriteEffects.None,
                0f
            );

            Assert.AreEqual(expected, _sut);
        }

        [TestMethod]
        public void FactoryMethodShouldCreateExpectedObject_Position_TestB()
        {
            _sut = SpriteDrawInfo.Create(new Vector2(753, 159));

            var expected = new SpriteDrawInfo(
                new Vector2(753, 159),
                Color.White,
                0f,
                Vector2.Zero,
                new Vector2(1),
                SpriteEffects.None,
                0f
            );

            Assert.AreEqual(expected, _sut);
        }
        #endregion
    }
}
