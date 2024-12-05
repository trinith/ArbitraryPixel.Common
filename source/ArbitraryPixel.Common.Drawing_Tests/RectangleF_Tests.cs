using ArbitraryPixel.Common.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Drawing_Tests
{
    [TestClass]
    public class RectangleF_Tests
    {
        private RectangleF _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new RectangleF(200f, 100f, 400f, 300f);
        }

        #region Property Tests
        [TestMethod]
        public void LocationShouldGetValueFromConstructor()
        {
            Assert.AreEqual(new Vector2(200f, 100f), _sut.Location);
        }

        [TestMethod]
        public void LocationShouldReturnSetValue()
        {
            _sut.Location = new Vector2(1, 2);
            Assert.AreEqual(new Vector2(1, 2), _sut.Location);
        }

        [TestMethod]
        public void SizeShouldGetValueFromConstructor()
        {
            Assert.AreEqual(new SizeF(400, 300), _sut.Size);
        }

        [TestMethod]
        public void SizeShouldReturnSetValue()
        {
            _sut.Size = new SizeF(1, 2);
            Assert.AreEqual(new SizeF(1, 2), _sut.Size);
        }

        [TestMethod]
        public void XShouldReturnLocationX()
        {
            Assert.AreEqual(200f, _sut.X);
        }

        [TestMethod]
        public void XShouldReturnSetValue()
        {
            _sut.X = 45;
            Assert.AreEqual(45, _sut.X);
        }

        [TestMethod]
        public void YShouldReturnLocationY()
        {
            Assert.AreEqual(100f, _sut.Y);
        }

        [TestMethod]
        public void YShouldReturnSetValue()
        {
            _sut.Y = 45;
            Assert.AreEqual(45, _sut.Y);
        }

        [TestMethod]
        public void WidthShouldReturnSizeWidth()
        {
            Assert.AreEqual(400, _sut.Width);
        }

        [TestMethod]
        public void WidthShouldReturnSetValue()
        {
            _sut.Width = 45;
            Assert.AreEqual(45, _sut.Width);
        }

        [TestMethod]
        public void HeightShouldReturnSizeWidth()
        {
            Assert.AreEqual(300, _sut.Height);
        }

        [TestMethod]
        public void HeightShouldReturnSetValue()
        {
            _sut.Height = 45;
            Assert.AreEqual(45, _sut.Height);
        }

        [TestMethod]
        public void OppositeCornerShouldReturnExpectedValue()
        {
            Assert.AreEqual(new Vector2(600, 400), _sut.OppositeCorner);
        }

        [TestMethod]
        public void TopShouldReturnExpectedValue()
        {
            Assert.AreEqual(100, _sut.Top);
        }

        [TestMethod]
        public void LeftShouldReturnExpectedValue()
        {
            Assert.AreEqual(200, _sut.Left);
        }

        [TestMethod]
        public void RightShouldReturnExpectedValue()
        {
            Assert.AreEqual(600, _sut.Right);
        }

        [TestMethod]
        public void BottomShouldReturnExpectedValue()
        {
            Assert.AreEqual(400, _sut.Bottom);
        }

        [TestMethod]
        public void CentreShouldReturnCentreOfRectangle()
        {
            //200f, 100f, 400f, 300f);
            Assert.AreEqual<Vector2>(new Vector2(400, 250), _sut.Centre);
        }
        #endregion

        #region Equality / Inequality Tests
        [TestMethod]
        public void EqualOperatorWithEquivalentValueShouldReturnTrue_NormalRectangle()
        {
            Assert.IsTrue(_sut == new RectangleF(200, 100, 400, 300));
        }

        [TestMethod]
        public void EqualOperatorWithEquivalentValueShouldReturnTrue_NegativeRectangle()
        {
            Assert.IsTrue(_sut == new RectangleF(600, 400, -400, -300));
        }

        [TestMethod]
        public void EqualOperatorWithNonEquivalentValueShouldReturnFalse()
        {
            Assert.IsFalse(_sut == new RectangleF(1, 2, 3, 4));
        }

        [TestMethod]
        public void NotEqualOperatorWithNonEquivalentValueShouldReturnTrue()
        {
            Assert.IsTrue(_sut != new RectangleF(1, 2, 3, 4));
        }

        [TestMethod]
        public void NotEqualOperatorWithEquivalentValueShouldReturnFalse()
        {
            Assert.IsFalse(_sut != new RectangleF(200, 100, 400, 300));
        }

        [TestMethod]
        public void EqualsWithNullShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Equals(null));
        }

        [TestMethod]
        public void EqualsWithOtherTypeShoudlReturnFalse()
        {
            Assert.IsFalse(_sut.Equals("test"));
        }

        [TestMethod]
        public void EqualsWithEquivalentValueShouldReturnTrue()
        {
            Assert.IsTrue(_sut.Equals(new RectangleF(200, 100, 400, 300)));
        }

        [TestMethod]
        public void EqualsWithNonEquivalentValueShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Equals(new RectangleF(1, 2, 3, 4)));
        }
        #endregion

        #region ToString Tests
        [TestMethod]
        public void ToStringShouldReturnExpectedValue()
        {
            Assert.AreEqual("{X=200, Y=100, Width=400, Height=300}", _sut.ToString());
        }
        #endregion

        #region GetHashCode Tests
        [TestMethod]
        public void GetHashCodeForEquivalentObjectShouldReturnSameValue()
        {
            Assert.AreEqual((new RectangleF(200, 100, 400, 300)).GetHashCode(), _sut.GetHashCode());
        }
        #endregion

        #region Contains Tests
        [TestMethod]
        public void ContainsWithVector2InsideRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.Contains(new Vector2(250, 150)));
        }

        [TestMethod]
        public void ContainsWithVector2OutsideRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(new Vector2(50, 50)));
        }

        [TestMethod]
        public void ContainsWithFloatsInsideRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.Contains(250, 150));
        }

        [TestMethod]
        public void ContainsWithFloatsOutsideRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(50, 50));
        }

        [TestMethod]
        public void ContainsWithRectangleInsideShouldReturnTrue()
        {
            Assert.IsTrue(_sut.Contains(new RectangleF(250, 150, 300, 200)));
        }

        [TestMethod]
        public void ContainsWithIntersectingRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(new RectangleF(0, 0, 400, 300)));
        }

        [TestMethod]
        public void ContainsWithOutsideRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(new RectangleF(0, 0, 100, 100)));
        }
        #endregion

        #region IntersectsWith Tests
        [TestMethod]
        public void IntersectsWithUsingOutsideRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.IntersectsWith(new RectangleF(0, 0, 100, 100)));
        }

        [TestMethod]
        public void IntersectsWithUsingIntersectingRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.IntersectsWith(new RectangleF(0, 0, 400, 400)));
        }

        [TestMethod]
        public void IntersectsWithUsingInsideRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.IntersectsWith(new RectangleF(250, 150, 100, 100)));
        }
        #endregion

        #region Intersect Tests
        [TestMethod]
        public void IntersectWithNonIntersectingRectanglesShouldReturnEmpty()
        {
            Assert.AreEqual(
                RectangleF.Empty,
                RectangleF.Intersect(
                    new RectangleF(0, 0, 100, 100),
                    new RectangleF(200, 200, 100, 100)
                )
            );
        }

        [TestMethod]
        public void IntersectWithIntersectingRectanglesShouldReturnExpectedResult()
        {
            Assert.AreEqual(
                new RectangleF(100, 100, 200, 200),
                RectangleF.Intersect(
                    new RectangleF(0, 0, 300, 300),
                    new RectangleF(100, 100, 300, 300)
                )
            );
        }

        [TestMethod]
        public void IntersectWithContainedRectangleShouldReturnContainedRectangle()
        {
            Assert.AreEqual(
                new RectangleF(100, 100, 100, 100),
                RectangleF.Intersect(
                    new RectangleF(0, 0, 400, 400),
                    new RectangleF(100, 100, 100, 100)
                )
            );
        }
        #endregion

        #region Union Tests
        [TestMethod]
        public void UnionWithSeparateRectanglesShouldReturnExpectedResult()
        {
            Assert.AreEqual(
                new RectangleF(0, 0, 400, 400),
                RectangleF.Union(
                    new RectangleF(0, 0, 100, 100),
                    new RectangleF(300, 300, 100, 100)
                )
            );
        }

        [TestMethod]
        public void UnionWithIntersectingRectanglesShouldReturnExpectedResult()
        {
            Assert.AreEqual(
                new RectangleF(0, 0, 400, 400),
                RectangleF.Union(
                    new RectangleF(0, 0, 300, 300),
                    new RectangleF(100, 100, 300, 300)
                )
            );
        }

        [TestMethod]
        public void UnionWithContainedRectangleShouldReturnContainerRectangle()
        {
            Assert.AreEqual(
                new RectangleF(0, 0, 400, 400),
                RectangleF.Union(
                    new RectangleF(0, 0, 400, 400),
                    new RectangleF(100, 100, 100, 100)
                )
            );
        }
        #endregion

        #region Casting Tests
        [TestMethod]
        public void CastToRectangleShouldReturnExpectedValue()
        {
            RectangleF source = new RectangleF(1, 2, 3, 4);

            Assert.AreEqual(new Rectangle(1, 2, 3, 4), (Rectangle)source);
        }

        [TestMethod]
        public void CastToRectangleShouldFloorValues()
        {
            RectangleF source = new RectangleF(1.5f, 2.5f, 3.5f, 4.5f);

            Assert.AreEqual(new Rectangle(1, 2, 3, 4), (Rectangle)source);
        }

        [TestMethod]
        public void CastToRectangleFShouldReturnExpectedValue()
        {
            Assert.AreEqual(new RectangleF(1, 2, 3, 4), ((RectangleF)(new Rectangle(1, 2, 3, 4))));
        }
        #endregion

        #region Inflate Tests
        [TestMethod]
        public void InflateWithZeroShouldNotChangeRectangle()
        {
            RectangleF expected = _sut;
            _sut.Inflate(0, 0);

            Assert.AreEqual<RectangleF>(expected, _sut);
        }

        [TestMethod]
        public void InflateWithPositiveHorizontalAmountShouldUpdateWidth()
        {
            float expected = _sut.Width + 2;

            _sut.Inflate(1, 0);

            Assert.AreEqual<float>(expected, _sut.Width);
        }

        [TestMethod]
        public void InflateWithPositiveHorizontalAmountShouldUpdateX()
        {
            float expected = _sut.X - 1;

            _sut.Inflate(1, 0);

            Assert.AreEqual<float>(expected, _sut.X);
        }

        [TestMethod]
        public void InflateWithPositiveVerticalAmountShouldUpdateHeight()
        {
            float expected = _sut.Height + 2;

            _sut.Inflate(0, 1);

            Assert.AreEqual<float>(expected, _sut.Height);
        }

        [TestMethod]
        public void InflateWithPositiveVerticalAmountShouldUpdateY()
        {
            float expected = _sut.Y - 1;

            _sut.Inflate(0, 1);

            Assert.AreEqual<float>(expected, _sut.Y);
        }

        [TestMethod]
        public void InflateWithNegativeValuesShouldUpdateRectangle()
        {
            _sut.Inflate(-1, -1);

            Assert.AreEqual<RectangleF>(new RectangleF(201, 101, 398, 298), _sut);
        }

        [TestMethod]
        public void InflateWithSizeShouldUpdateRectangle()
        {
            _sut.Inflate(new SizeF(1, 1));

            Assert.AreEqual<RectangleF>(new RectangleF(199, 99, 402, 302), _sut);
        }
        #endregion
    }
}
