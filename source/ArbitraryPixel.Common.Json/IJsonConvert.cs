namespace ArbitraryPixel.Common.Json
{
    /// <summary>
    /// Represents an object responsible for converting an object to a Json string, and vice versa.
    /// </summary>
    public interface IJsonConvert
    {
        /// <summary>
        /// Serialize an object to a Json string.
        /// </summary>
        /// <param name="value">The object to serialize.</param>
        /// <param name="isIndented">Whether or not the resulting string should be intended or not.</param>
        /// <returns>A string that represents the supplied object.</returns>
        string SerializeObject(object value, bool isIndented = true);

        /// <summary>
        /// Deserialize a Json string into an object of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of object being deserialized.</typeparam>
        /// <param name="value">The Json string to deserialize the object from.</param>
        /// <returns>An object of the specified type, deserialized from the supplied Json string.</returns>
        T DeserializeObject<T>(string value);
    }
}
