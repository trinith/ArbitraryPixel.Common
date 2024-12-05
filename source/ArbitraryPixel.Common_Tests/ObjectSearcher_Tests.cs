using System;
using System.Linq;
using ArbitraryPixel.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ArbitraryPixel.Common_Tests
{
    [TestClass]
    public class ObjectSearcher_Tests
    {
        private ObjectSearcher _sut;

        private ObjectSearchComparer<string> _comparer;

        [TestInitialize]
        public void Initialize()
        {
            _comparer =
                (targetObject, compareObject) =>
                {
                    return compareObject.StartsWith(targetObject);
                };

            _sut = new ObjectSearcher();
        }

        #region GetFirstMatchingObject Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFirstMatchingObjectWithNullParameterShouldThrowException_Objects()
        {
            _sut.GetFirstMatchingObject<string>(null, "b", _comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFirstMatchingObjectWithNullParameterShouldThrowException_Comparer()
        {
            _sut.GetFirstMatchingObject<string>(new string[] { "a", "b" }, "a", null);
        }

        [TestMethod]
        public void GetFirstMatchingObjectWithMatchShouldReturnObject()
        {
            Assert.AreEqual<string>("testA", _sut.GetFirstMatchingObject<string>(new string[] { "start", "testA", "abcd", "something" }, "test", _comparer));
        }

        [TestMethod]
        public void GetFirstMatchingObjectWithMultipleMatchShouldReturnFirstMatch()
        {
            Assert.AreEqual<string>("testA", _sut.GetFirstMatchingObject<string>(new string[] { "start", "testA", "testB", "something" }, "test", _comparer));
        }

        [TestMethod]
        public void GetFirstMatchingObjectWithoutMatchShouldReturnNull()
        {
            Assert.AreEqual<string>(null, _sut.GetFirstMatchingObject<string>(new string[] { "start", "testA", "abcd", "something" }, "nope", _comparer));
        }
        #endregion

        #region GetMatchingObjects Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMatchingObjectsWithNullParameterShouldThrowException_Objects()
        {
            _sut.GetMatchingObjects<string>(null, "b", _comparer);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMatchingObjectsWithNullParameterShouldThrowException_Comparer()
        {
            _sut.GetMatchingObjects<string>(new string[] { "a", "b" }, "a", null);
        }

        [TestMethod]
        public void GetMatchingObjectsWithMatchShouldReturnArrayContainingMatchObject()
        {
            Assert.IsTrue(_sut.GetMatchingObjects<string>(new string[] { "first", "testA", "last" }, "test", _comparer).SequenceEqual(new string[] { "testA" }));
        }

        [TestMethod]
        public void GetMatchingObjectsWithMultipleMatchesShouldReturnArrayContainingAllMatches()
        {
            Assert.IsTrue(_sut.GetMatchingObjects<string>(new string[] { "first", "testA", "testB", "last" }, "test", _comparer).SequenceEqual(new string[] { "testA", "testB" }));
        }

        [TestMethod]
        public void GetMatchingObjectsWithNoMatchesShouldReturnEmptyArray()
        {
            Assert.IsTrue(_sut.GetMatchingObjects<string>(new string[] { "first", "testA", "last" }, "nope", _comparer).SequenceEqual(new string[] { }));
        }
        #endregion
    }
}
