using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.ValueConversion
{
    /// <summary>
    /// An object responsible for managing IValueConverter objects.
    /// </summary>
    public class ValueConverterManager : IValueConverterManager
    {
        private Dictionary<Type, object> _converters = new Dictionary<Type, object>();

        #region IValueConverterManager
        /// <summary>
        /// Register a converter with this manager.
        /// </summary>
        /// <typeparam name="TType">The type the converter is responsible for.</typeparam>
        /// <param name="valueConverter">The converter object to register.</param>
        public void RegisterConverter<TType>(IValueConverter<TType> valueConverter)
        {
            _converters.Add(typeof(TType), valueConverter);
        }

        /// <summary>
        /// Whether or not this manager has a converter registered for the specified type.
        /// </summary>
        /// <typeparam name="TType">The type to check.</typeparam>
        /// <returns>True if a converter is registered for the supplied type, false otherwise.</returns>
        public bool HasValueConverter<TType>()
        {
            return _converters.ContainsKey(typeof(TType));
        }

        /// <summary>
        /// Convert the supplied string to an object of the specified type using the converter registered for that type. If no converter exists, an exception is thrown.
        /// </summary>
        /// <typeparam name="TType">The type to convert to.</typeparam>
        /// <param name="valueString">The string representation of a value of the specified type.</param>
        /// <returns>The result of the conversion.</returns>
        public TType ConvertFromString<TType>(string valueString)
        {
            return this.GetConverter<TType>().ConvertFromString(valueString);
        }

        /// <summary>
        /// Attempt to convert the supplied string to an object of the specified type using the converter registered for that type.
        /// </summary>
        /// <typeparam name="TType">The type to convert to.</typeparam>
        /// <param name="valueString"></param>
        /// <param name="result">The result of the conversion. If a converter is not available for the specified type, the type default will be stored here.</param>
        /// <returns>True if valueString can be converted to the specified type, false otherwise.</returns>
        public bool TryConvertFromString<TType>(string valueString, out TType result)
        {
            bool canConvert = false;

            if (this.HasValueConverter<TType>())
                canConvert = this.GetConverter<TType>().TryConvertFromString(valueString, out result);
            else
                result = default(TType);

            return canConvert;
        }

        /// <summary>
        /// Convert a value of the specified type to a string representation using the converter registered for that type.
        /// </summary>
        /// <typeparam name="TType">The type that is being converted.</typeparam>
        /// <param name="value">A value to convert to a string.</param>
        /// <returns>A string representation of the supplied value.</returns>
        public string ConvertToString<TType>(TType value)
        {
            return this.GetConverter<TType>().ConvertToString(value);
        }

        /// <summary>
        /// Get the converter of the specified type from this manager. If the type has not been registered, an exception is thrown.
        /// </summary>
        /// <typeparam name="TType">The type to get a converter for.</typeparam>
        /// <returns>The converter for the specified type.</returns>
        public IValueConverter<TType> GetConverter<TType>()
        {
            return (IValueConverter<TType>)_converters[typeof(TType)];
        }
        #endregion
    }
}
