using System;

namespace ArbitraryPixel.Common.Graphics.MonoGame
{
    public class WrapperBase<T> : IGraphicsWrapper where T : class
    {
        private T _wrappedObject = default(T);

        public T WrappedObject => _wrappedObject;

        public WrapperBase(T objectToWrap)
        {
            if (objectToWrap == null)
                throw new ArgumentNullException();

            _wrappedObject = objectToWrap;
        }

        public OutputType GetWrappedObject<OutputType>() where OutputType : class
        {
            return _wrappedObject as OutputType;
        }
    }
}
