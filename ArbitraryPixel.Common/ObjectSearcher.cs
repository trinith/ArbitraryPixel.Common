using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// An object responsible for searching an array of objects for a matching object, using the supplied delegate to determine if an object within the array is considered matching.
    /// </summary>
    public class ObjectSearcher : IObjectSearcher
    {
        /// <summary>
        /// Get the first object that matches targetObject within the objects array.
        /// </summary>
        /// <typeparam name="TType">The type of object to be searched.</typeparam>
        /// <param name="objects">The array of objects to search.</param>
        /// <param name="targetObject">The object to match against.</param>
        /// <param name="comparer">A delegate responsible for determining whether or not targetObject matches a particular object within the objects array.</param>
        /// <returns>The first entity in the array that matches. Null if no matching entity is found.</returns>
        public TType GetFirstMatchingObject<TType>(TType[] objects, TType targetObject, ObjectSearchComparer<TType> comparer)
        {
            var tObjects = objects ?? throw new ArgumentNullException();
            var tComparer = comparer ?? throw new ArgumentNullException();

            TType result = default(TType);

            foreach (TType obj in objects)
            {
                if (comparer(targetObject, obj))
                {
                    result = obj;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Get all objects that match targetObject within the objects array.
        /// </summary>
        /// <typeparam name="TType">The type of object to be searched.</typeparam>
        /// <param name="objects">The array of objects to search.</param>
        /// <param name="targetObject">The object to match against.</param>
        /// <param name="comparer">A delegate responsible for determining whether or not targetObject matches a particular object within the objects array.</param>
        /// <returns>An array containing all objects within the objects array that match targetObject, if any such objects exist.</returns>
        public TType[] GetMatchingObjects<TType>(TType[] objects, TType targetObject, ObjectSearchComparer<TType> comparer)
        {
            var tObjects = objects ?? throw new ArgumentNullException();
            var tComparer = comparer ?? throw new ArgumentNullException();

            List<TType> result = new List<TType>();

            foreach (TType obj in objects)
            {
                if (comparer(targetObject, obj))
                    result.Add(obj);
            }

            return result.ToArray();
        }
    }
}
