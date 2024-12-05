namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Represents an object that will search an array of objects for a matching object, using the supplied delegate to determine if an object within the array is considered matching.
    /// </summary>
    public interface IObjectSearcher
    {
        /// <summary>
        /// Get the first object that matches targetObject within the objects array.
        /// </summary>
        /// <typeparam name="TType">The type of object to be searched.</typeparam>
        /// <param name="objects">The array of objects to search.</param>
        /// <param name="targetObject">The object to match against.</param>
        /// <param name="comparer">A delegate responsible for determining whether or not targetObject matches a particular object within the objects array.</param>
        /// <returns>The first entity in the array that matches. Null if no matching entity is found.</returns>
        TType GetFirstMatchingObject<TType>(TType[] objects, TType targetObject, ObjectSearchComparer<TType> comparer);

        /// <summary>
        /// Get all objects that match targetObject within the objects array.
        /// </summary>
        /// <typeparam name="TType">The type of object to be searched.</typeparam>
        /// <param name="objects">The array of objects to search.</param>
        /// <param name="targetObject">The object to match against.</param>
        /// <param name="comparer">A delegate responsible for determining whether or not targetObject matches a particular object within the objects array.</param>
        /// <returns>An array containing all objects within the objects array that match targetObject, if any such objects exist.</returns>
        TType[] GetMatchingObjects<TType>(TType[] objects, TType targetObject, ObjectSearchComparer<TType> comparer);
    }
}
