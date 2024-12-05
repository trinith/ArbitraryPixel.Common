namespace ArbitraryPixel.Common.Reflection
{
    /// <summary>
    /// Represents an object responsible for providing information about an assembly.
    /// </summary>
    public interface IAssembly
    {
        /// <summary>
        /// The title of this assembly.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// The version of this assembly.
        /// </summary>
        string Version { get; }
    }
}
