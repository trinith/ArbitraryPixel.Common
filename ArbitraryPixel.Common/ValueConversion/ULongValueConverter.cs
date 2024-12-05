namespace ArbitraryPixel.Common.ValueConversion
{
    /// <summary>
    /// An object responsiible for converting ulong values to and from strings.
    /// </summary>
    public class ULongValueConverter : IValueConverter<ulong>
    {
        #region IValueConverter Implementation
        /// <summary>
        /// Convert a string representing a value for this converter into this converter's type. If the string cannot be converted, an exception is thrown.
        /// </summary>
        /// <param name="valueString">The string to convert.</param>
        /// <returns>The converted value.</returns>
        public ulong ConvertFromString(string valueString)
        {
            return ulong.Parse(valueString);
        }

        /// <summary>
        /// Attempt to convert a string representing a value for this converter into this converter's type.
        /// </summary>
        /// <param name="valueString">The string to convert.</param>
        /// <param name="result">The conversion result will be stored in this out parameter.</param>
        /// <returns>True if the string could be converted to the specified value, false otherwise.</returns>
        public bool TryConvertFromString(string valueString, out ulong result)
        {
            return ulong.TryParse(valueString, out result);
        }

        /// <summary>
        /// Convert the supplied value to a string representation, as defined by this converter.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>A string representing the supplied value.</returns>
        public string ConvertToString(ulong value)
        {
            return value.ToString();
        }
        #endregion
    }
}
