using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArbitraryPixel.Common.Drawing;
using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Drawing_Tests
{
    [TestClass]
    public class SizeF_Tests
    {
        private SizeF _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new SizeF(200f, 100f);
        }

        #region Constructor Tests
        [TestMethod]
        public void ConstructWithSingleValueShouldSetWidth()
        {
            _sut = new SizeF(500);
            Assert.AreEqual<float>(500, _sut.Width);
        }

        [TestMethod]
        public void ConstructWithSingleValueShouldSetHeight()
        {
            _sut = new SizeF(500);
            Assert.AreEqual<float>(500, _sut.Height);
        }
        #endregion

        #region Property Tests
        [TestMethod]
        public void WidthShouldReturnValueFromConstructor()
        {
            Assert.AreEqual<float>(200f, _sut.Width);
        }

        [TestMethod]
        public void WidthShouldReturnSetvalue()
        {
            _sut.Width = 45f;

            Assert.AreEqual<float>(45f, _sut.Width);
        }

        [TestMethod]
        public void HeightShouldReturnValueFromContructor()
        {
            Assert.AreEqual<float>(100f, _sut.Height);
        }

        [TestMethod]
        public void HeightShouldReturnSetValue()
        {
            _sut.Height = 45f;

            Assert.AreEqual<float>(45f, _sut.Height);
        }

        [TestMethod]
        public void CentreShouldReturnExpectedWidth()
        {
            Assert.AreEqual<float>(100f, _sut.Centre.X);
        }

        [TestMethod]
        public void CentreShouldReturnExpectedHeight()
        {
            Assert.AreEqual<float>(50f, _sut.Centre.Y);
        }
        #endregion

        #region Equality/Inequality Tests
        [TestMethod]
        public void EqualOperatorWithEquivalentObjectsShouldReturnTrue()
        {
            SizeF other = new SizeF(200f, 100f);
            Assert.IsTrue(_sut == other);
        }

        [TestMethod]
        public void EqualOperatorWithNonEquivalentObjectsShouldReturnFalse()
        {
            SizeF other = new SizeF(1f, 2f);
            Assert.IsFalse(_sut == other);
        }

        [TestMethod]
        public void NotEqualOperatorWithNonEquivalentObjectsShouldReturnTrue()
        {
            SizeF other = new SizeF(1f, 2f);
            Assert.IsTrue(_sut != other);
        }

        [TestMethod]
        public void NotEqualOperatorWithEquivalentObjectsShouldReturnFalse()
        {
            SizeF other = new SizeF(200f, 100f);
            Assert.IsFalse(_sut != other);
        }

        [TestMethod]
        public void EqualsWithEquivalentObjeectShouldReturnTrue()
        {
            SizeF other = new SizeF(200f, 100f);
            Assert.IsTrue(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentObjectShouldReturnFalse()
        {
            SizeF other = new SizeF(1f, 2f);
            Assert.IsFalse(_sut.Equals(other));
        }

        [TestMethod]
        public void EqualsWithDifferentTypeShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Equals("test"));
        }

        [TestMethod]
        public void EqualsWithNullShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Equals(null));
        }
        #endregion

        #region ToString Tests
        [TestMethod]
        public void ToStringShouldOutputExpectedFormat()
        {
            Assert.AreEqual<string>("{Width=200, Height=100}", _sut.ToString());
        }
        #endregion

        #region GetHashCode Tests
        [TestMethod]
        public void GetHashCodeShouldReturnSameValueForEquivalentObjects()
        {
            SizeF other = new SizeF(200f, 100f);
            Assert.AreEqual<int>(other.GetHashCode(), _sut.GetHashCode());
        }
        #endregion

        #region Casting Tests
        [TestMethod]
        public void CastToVector2ShouldCopyWidthToX()
        {
            Vector2 casted = (Vector2)_sut;
            Assert.AreEqual<float>(200f, casted.X);
        }

        [TestMethod]
        public void CastToVector2ShouldCopyHeightToY()
        {
            Vector2 casted = (Vector2)_sut;
            Assert.AreEqual<float>(100f, casted.Y);
        }

        [TestMethod]
        public void CastVector2ToSizeFShouldCopyXToWidth()
        {
            Vector2 v = new Vector2(200f, 100f);
            SizeF casted = (SizeF)v;

            Assert.AreEqual<float>(200f, casted.Width);
        }

        [TestMethod]
        public void CastVector2ToSizeFShouldCopyYToHeight()
        {
            Vector2 v = new Vector2(200f, 100f);
            SizeF casted = (SizeF)v;

            Assert.AreEqual<float>(100f, casted.Height);
        }

        [TestMethod]
        public void CastToPointShouldCopyWidthToX()
        {
            SizeF s = new SizeF(100.5f, 200.5f);
            Point p = (Point)s;

            Assert.AreEqual<int>(100, p.X);
        }

        [TestMethod]
        public void CastToPointShouldCopyHeightToY()
        {
            SizeF s = new SizeF(100.5f, 200.5f);
            Point p = (Point)s;

            Assert.AreEqual<int>(200, p.Y);
        }

        [TestMethod]
        public void CastPointToSizeFShouldCopyXToWidth()
        {
            Point p = new Point(100, 200);
            SizeF s = (SizeF)p;

            Assert.AreEqual<float>(100, s.Width);
        }

        [TestMethod]
        public void CastPointToSizeFShouldCopyYToHeight()
        {
            Point p = new Point(100, 200);
            SizeF s = (SizeF)p;

            Assert.AreEqual<float>(200, s.Height);
        }
        #endregion

        #region Multiplcation Operator Tests
        [TestMethod]
        public void MultiplyByFloatShouldGiveExpectedWidth()
        {
            _sut *= 5;
            Assert.AreEqual<float>(1000f, _sut.Width);
        }

        [TestMethod]
        public void MultiplyByFloatShoudlGiveExpectedHeight()
        {
            _sut *= 5;
            Assert.AreEqual<float>(500f, _sut.Height);
        }

        [TestMethod]
        public void MultiplyBySizeFShouldGiveExpectedWidth()
        {
            _sut *= new SizeF(2, 2);
            Assert.AreEqual<float>(400, _sut.Width);
        }

        [TestMethod]
        public void MultiplyBySizeFShouldGiveExpectedHeight()
        {
            _sut *= new SizeF(2, 2);
            Assert.AreEqual<float>(200, _sut.Height);
        }
        #endregion

        #region Division Operator Tests
        [TestMethod]
        public void DivideByFloatShouldGiveExpectedWidth()
        {
            _sut /= 2;
            Assert.AreEqual<float>(100, _sut.Width);
        }

        [TestMethod]
        public void DivideByFloatShoudlGiveExpectedHeight()
        {
            _sut /= 2;
            Assert.AreEqual<float>(50, _sut.Height);
        }

        [TestMethod]
        public void DivideBySizeFShouldGiveExpectedWidth()
        {
            _sut /= new SizeF(2, 2);
            Assert.AreEqual<float>(100, _sut.Width);
        }

        [TestMethod]
        public void DivideBySizeFShouldGiveExpectedHeight()
        {
            _sut /= new SizeF(2, 2);
            Assert.AreEqual<float>(50, _sut.Height);
        }
        #endregion

        #region Addition Operator Tests
        [TestMethod]
        public void AddWithSizeFShouldGiveExpecetedWidth()
        {
            _sut += new SizeF(200, 200);
            Assert.AreEqual<float>(400, _sut.Width);
        }

        [TestMethod]
        public void AddWithSizeFShouldGiveExpecetedHeight()
        {
            _sut += new SizeF(200, 200);
            Assert.AreEqual<float>(300, _sut.Height);
        }
        #endregion

        #region Subtraction Operator Tests
        [TestMethod]
        public void SubtractWithSizeFShouldGiveExpecetedWidth()
        {
            _sut -= new SizeF(150, 75);
            Assert.AreEqual<float>(50, _sut.Width);
        }

        [TestMethod]
        public void SubtractWithSizeFShouldGiveExpecetedHeight()
        {
            _sut -= new SizeF(150, 75);
            Assert.AreEqual<float>(25, _sut.Height);
        }
        #endregion

        #region UnaryMinus Operator Tests
        [TestMethod]
        public void UnaryMinusWithPositiveSizeShouldChangeSizeToNegative()
        {
            _sut = -_sut;

            Assert.AreEqual<SizeF>(new SizeF(-200f, -100f), _sut);
        }
        #endregion
    }
}
