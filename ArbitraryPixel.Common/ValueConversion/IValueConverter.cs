namespace ArbitraryPixel.Common.ValueConversion
{
    /// <summary>
    /// Represents an object responsible for converting values between a specified type and a string.
    /// </summary>
    /// <typeparam name="TType">The type this value converter is responsible for.</typeparam>
    public interface IValueConverter<TType>
    {
        /// <summary>
        /// Convert a string representing a value for this converter into this converter's type. If the string cannot be converted, an exception is thrown.
        /// </summary>
        /// <param name="valueString">The string to convert.</param>
        /// <returns>The converted value.</returns>
        TType ConvertFromString(string valueString);

        /// <summary>
        /// Attempt to convert a string representing a value for this converter into this converter's type.
        /// </summary>
        /// <param name="valueString">The string to convert.</param>
        /// <param name="result">The conversion result will be stored in this out parameter.</param>
        /// <returns>True if the string could be converted to the specified value, false otherwise.</returns>
        bool TryConvertFromString(string valueString, out TType result);

        /// <summary>
        /// Convert the supplied value to a string representation, as defined by this converter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string representing the supplied value.</returns>
        string ConvertToString(TType value);
    }
}
