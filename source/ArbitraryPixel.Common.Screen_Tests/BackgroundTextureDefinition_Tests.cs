using System;
using ArbitraryPixel.Common.Graphics;
using ArbitraryPixel.Common.Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using NSubstitute;

namespace ArbitraryPixel.Common.Screen_Tests
{
    [TestClass]
    public class BackgroundTextureDefinition_Tests
    {
        private BackgroundTextureDefinition _sut;
        private ITexture2D _mockTexture;

        [TestInitialize]
        public void Initialize()
        {
            _mockTexture = Substitute.For<ITexture2D>();
        }

        private void Construct()
        {
            _sut = new BackgroundTextureDefinition(_mockTexture, Color.Pink);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_Texture()
        {
            _sut = new BackgroundTextureDefinition(null, Color.Pink);
        }
        #endregion

        #region Property Tests
        [TestMethod]
        public void PropertyShouldReturnConstructorValue_Texture()
        {
            Construct();

            Assert.AreSame(_mockTexture, _sut.Texture);
        }

        [TestMethod]
        public void PropertyShouldReturnConstructorValue_Color()
        {
            Construct();

            Assert.AreEqual<Color>(Color.Pink, _sut.Mask);
        }
        #endregion
    }
}
