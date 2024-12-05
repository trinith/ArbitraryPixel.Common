using ArbitraryPixel.Common.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;

namespace ArbitraryPixel.Common.Drawing_Tests
{
    [TestClass]
    public class RectangleF_ConstructWithVector2SizeF_Tests
    {
        private RectangleF _sut;

        [TestInitialize]
        public void Initialize()
        {
            _sut = new RectangleF(new Vector2(100, 200), new SizeF(300, 400));
        }

        [TestMethod]
        public void ConstructShouldSetExpectedParameter_X()
        {
            Assert.AreEqual(100, _sut.X);
        }

        [TestMethod]
        public void ConstructShouldSetExpectedParameter_Y()
        {
            Assert.AreEqual(200, _sut.Y);
        }

        [TestMethod]
        public void ConstructShouldSetExpectedParameter_Width()
        {
            Assert.AreEqual(300, _sut.Width);
        }

        [TestMethod]
        public void ConstructShouldSetExpectedParameter_Height()
        {
            Assert.AreEqual(400, _sut.Height);
        }
    }
}
