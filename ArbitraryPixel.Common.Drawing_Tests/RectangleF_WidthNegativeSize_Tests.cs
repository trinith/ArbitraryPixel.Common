using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArbitraryPixel.Common.Drawing;
using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Drawing_Tests
{
    [TestClass]
    public class RectangleF_WidthNegativeSize_Tests
    {
        private RectangleF _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new RectangleF(600, 400, -400, -300);
        }

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

        [TestMethod]
        public void ContainsWithNegativeRectangleInsideShouldReturnTrue()
        {
            Assert.IsTrue(_sut.Contains(new RectangleF(500, 300, -100, -100)));
        }

        [TestMethod]
        public void ContainsWithNegativeIntersectingRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(new RectangleF(300, 200, -400, -400)));
        }

        [TestMethod]
        public void ContainsWithNegativeRectangleOutsideShouldReturnFalse()
        {
            Assert.IsFalse(_sut.Contains(new RectangleF(100, 100, -100, -100)));
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

        [TestMethod]
        public void IntersectsWithUsingNegativeOutsideRectangleShouldReturnFalse()
        {
            Assert.IsFalse(_sut.IntersectsWith(new RectangleF(100, 100, -100, -100)));
        }

        [TestMethod]
        public void IntersectsWithUsingNegativeIntersectingRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.IntersectsWith(new RectangleF(400, 400, -400, -400)));
        }

        [TestMethod]
        public void IntersectsWithUsingNegativeInsideRectangleShouldReturnTrue()
        {
            Assert.IsTrue(_sut.IntersectsWith(new RectangleF(350, 250, -100, -100)));
        }
        #endregion

        #region Intersect Tests
        [TestMethod]
        public void IntersectWithNonIntersectingRectanglesShouldReturnEmpty()
        {
            Assert.AreEqual(
                RectangleF.Empty,
                RectangleF.Intersect(
                    new RectangleF(100, 100, -100, -100),
                    new RectangleF(300, 300, -100, -100)
                )
            );
        }

        [TestMethod]
        public void IntersectWithIntersectingRectanglesShouldReturnExpectedResult()
        {
            Assert.AreEqual(
                new RectangleF(100, 100, 200, 200),
                RectangleF.Intersect(
                    new RectangleF(300, 300, -300, -300),
                    new RectangleF(400, 400, -300, -300)
                )
            );
        }

        [TestMethod]
        public void IntersectWithContainedRectangleShouldReturnContainedRectangle()
        {
            Assert.AreEqual(
                new RectangleF(100, 100, 100, 100),
                RectangleF.Intersect(
                    new RectangleF(400, 400, -400, -400),
                    new RectangleF(200, 200, -100, -100)
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
                    new RectangleF(100, 100, -100, -100),
                    new RectangleF(400, 400, -100, -100)
                )
            );
        }

        [TestMethod]
        public void UnionWithIntersectingRectanglesShouldReturnExpectedResult()
        {
            Assert.AreEqual(
                new RectangleF(0, 0, 400, 400),
                RectangleF.Union(
                    new RectangleF(300, 300, -300, -300),
                    new RectangleF(400, 400, -300, -300)
                )
            );
        }

        [TestMethod]
        public void UnionWithContainedRectangleShouldReturnContainerRectangle()
        {
            Assert.AreEqual(
                new RectangleF(0, 0, 400, 400),
                RectangleF.Union(
                    new RectangleF(400, 400, -400, -400),
                    new RectangleF(200, 200, -100, -100)
                )
            );
        }
        #endregion
    }
}
