using System;
using ArbitraryPixel.Common.Graphics;
using ArbitraryPixel.Common.Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ArbitraryPixel.Common.Screen_Tests
{
    [TestClass]
    public class ScreenManagerOptions_Tests
    {
        private ScreenManagerOptions _sut;
        private ISpriteBatch _mockSpriteBatch;

        [TestInitialize]
        public void Initialize()
        {
            _mockSpriteBatch = Substitute.For<ISpriteBatch>();
        }

        private void Construct()
        {
            _sut = new ScreenManagerOptions(_mockSpriteBatch);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_SpriteBatch()
        {
            _sut = new ScreenManagerOptions(null);
        }
        #endregion

        #region Property Tests
        [TestMethod]
        public void SpriteBatchShouldReturnConstructorValue()
        {
            Construct();

            Assert.AreSame(_mockSpriteBatch, _sut.SpriteBatch);
        }
        #endregion
    }
}
