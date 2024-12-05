namespace ArbitraryPixel.Common
{
    /// <summary>
    /// Describes a method that will compare two objects to determine if they match.
    /// </summary>
    /// <typeparam name="TType">The type of objects the method will work with.</typeparam>
    /// <param name="targetObject">The object we are matching against.</param>
    /// <param name="compareObject">An object to compare against targetObject.</param>
    /// <returns>True if compareObject matches targetObject, False otherwise.</returns>
    public delegate bool ObjectSearchComparer<TType>(TType targetObject, TType compareObject);
}
