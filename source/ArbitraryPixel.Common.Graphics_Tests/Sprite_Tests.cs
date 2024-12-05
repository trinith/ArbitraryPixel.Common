using System;
using ArbitraryPixel.Common.Graphics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NSubstitute;

namespace ArbitraryPixel.Common.Graphics_Tests
{
    [TestClass]
    public class Sprite_Tests
    {
        private Sprite _sut;
        private ITexture2D _mockTexture;

        private Rectangle _sourceRectangle = new Rectangle(1, 2, 3, 4);

        [TestInitialize]
        public void Init()
        {
            _mockTexture = Substitute.For<ITexture2D>();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_Texture()
        {
            _sut = new Sprite(null, _sourceRectangle);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_Texture()
        {
            _sut = new Sprite(_mockTexture, _sourceRectangle);

            Assert.AreSame(_mockTexture, _sut.Texture);
        }

        [TestMethod]
        public void ConstructShouldSetPropertyToExpectedValue_SourceRectangle()
        {
            _sut = new Sprite(_mockTexture, _sourceRectangle);

            Assert.AreEqual<Rectangle>(new Rectangle(1, 2, 3, 4), _sut.SourceRectangle.Value);
        }
    }
}
