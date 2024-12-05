using ArbitraryPixel.Common.ValueConversion;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common_Tests.ValueConversion
{
    [TestClass]
    public class ValueConverterManager_Tests
    {
        private ValueConverterManager _sut;

        private IValueConverter<string> _mockConverter;

        [TestInitialize]
        public void Initialize()
        {
            _mockConverter = Substitute.For<IValueConverter<string>>();
        }

        private void Construct()
        {
            _sut = new ValueConverterManager();
        }

        [TestMethod]
        public void RegisterConverterWithUnregisteredTypeShouldNotThrowException()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterConverterWithAlreadyRegisteredTypeShouldThrowException()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.RegisterConverter<string>(_mockConverter);
        }

        [TestMethod]
        public void HasValueConverterWithRegisteredConverterShouldReturnTrue()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            Assert.IsTrue(_sut.HasValueConverter<string>());
        }

        [TestMethod]
        public void HasValueConverterWithUnregisteredConverterShouldReturnFalse()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            Assert.IsFalse(_sut.HasValueConverter<int>());
        }

        [TestMethod]
        public void ConvertFromStringWithRegisteredConverterShouldCallConverterConvertFromString()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.ConvertFromString<string>("asdf");

            _mockConverter.Received(1).ConvertFromString("asdf");
        }

        [TestMethod]
        public void ConvertFromStringWithRegisteredConverterShouldReturnConverterConvertToStringResult()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);
            _mockConverter.ConvertFromString("asdf").Returns("blah");

            Assert.AreEqual<string>("blah", _sut.ConvertFromString<string>("asdf"));
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ConvertFromstringWithUnregisteredConverterShouldThrowExpectedException()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.ConvertFromString<int>("asdf");
        }

        [TestMethod]
        public void TryConvertFromStringWithRegisteredConverterShouldReturnConverterTryConvertFromString()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            string result;
            _sut.TryConvertFromString<string>("asdf", out result);

            _mockConverter.Received(1).TryConvertFromString("asdf", out result);
        }

        [TestMethod]
        public void TryConvertFromStringWithRegisteredConverterShouldReturnConverterTryConvertToStringResult()
        {
            string result = "";
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);
            _mockConverter.TryConvertFromString("asdf", out result).Returns(true);

            Assert.IsTrue(_sut.TryConvertFromString<string>("asdf", out result));
        }

        [TestMethod]
        public void TryConvertFromStringWithRegisteredConverterShouldSetExpectedOutParameterResult()
        {
            string result = "";
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);
            _mockConverter.TryConvertFromString("asdf", out result).Returns(
                x =>
                {
                    x[1] = "blah";
                    return true;
                }
            );

            _sut.TryConvertFromString<string>("asdf", out result);

            Assert.AreEqual<string>("blah", result);
        }

        [TestMethod]
        public void TryConvertFromStringWithUnregiseteredConverterShouldReturnFalse()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            int result;
            Assert.IsFalse(_sut.TryConvertFromString<int>("asdf", out result));
        }

        [TestMethod]
        public void TryConvertFromStringWithUnregisteredConverterShouldSetResultToTypeDefault_TestA()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            int result;
            _sut.TryConvertFromString<int>("asdf", out result);

            Assert.AreEqual<int>(default(int), result);
        }

        [TestMethod]
        public void TryConvertFromStringWithUnregisteredConverterShouldSetResultToTypeDefault_TestB()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            List<double> result;
            _sut.TryConvertFromString<List<double>>("asdf", out result);

            Assert.AreEqual<List<double>>(default(List<double>), result);
        }

        [TestMethod]
        public void ConvertToStringWithRegisteredConverterShouldCallConverterConvertToString()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.ConvertToString<string>("asdf");

            _mockConverter.Received(1).ConvertToString("asdf");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ConvertToStringWithUnregisteredConverterShouldThrowExpectedException()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.ConvertToString<int>(123);
        }

        [TestMethod]
        public void GetConverterWithRegisteredTypeShouldReturnExpectedConverter()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            Assert.AreSame(_mockConverter, _sut.GetConverter<string>());
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void GetConverterWithUnregisteredTypeShouldThrowExpectedException()
        {
            Construct();
            _sut.RegisterConverter<string>(_mockConverter);

            _sut.GetConverter<int>();
        }
    }
}
