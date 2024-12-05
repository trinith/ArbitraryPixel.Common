using System;
using System.Collections.Generic;
using System.Reflection;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// A base implementation of an object that wraps another object.
    /// </summary>
    /// <typeparam name="TTypeToWrap">The type of object to wrap.</typeparam>
    public class WrapperBase<TTypeToWrap> : IWrapper
    {
        private TTypeToWrap _wrappedObject = default(TTypeToWrap);

        /// <summary>
        /// Get the wrapped object.
        /// </summary>
        public TTypeToWrap WrappedObject => _wrappedObject;

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The object that will be wrapped.</param>
        public WrapperBase(TTypeToWrap objectToWrap)
        {
            // If the passed object is a class and it's null (default), then throw an exception.
            if (typeof(TTypeToWrap).GetTypeInfo().IsClass && EqualityComparer<TTypeToWrap>.Default.Equals(objectToWrap, default(TTypeToWrap)))
                throw new ArgumentNullException();

            _wrappedObject = objectToWrap;
        }

        /// <summary>
        /// Get the object that is wrapped.
        /// </summary>
        /// <typeparam name="TOutputType">The type to convert the wrapped object to.</typeparam>
        /// <returns>The wrapped object, cast to the specified type parameter.</returns>
        public TOutputType GetWrappedObject<TOutputType>()  where TOutputType : class
        {
            return _wrappedObject as TOutputType;
        }

        /// <summary>
        /// Get the object that is wrapped.
        /// </summary>
        /// <returns>The wrapped object, as an object.</returns>
        public object GetWrappedObject()
        {
            return _wrappedObject;
        }
    }
}
