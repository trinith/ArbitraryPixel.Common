using System.Reflection;

namespace ArbitraryPixel.Common.Reflection
{
    /// <summary>
    /// Implements IAssembly via System.Reflection.Assembly.
    /// </summary>
    public class DotNetAssembly : WrapperBase<Assembly>, IAssembly
    {
        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="objectToWrap">The object that will be wrapped.</param>
        public DotNetAssembly(Assembly objectToWrap)
            : base(objectToWrap)
        {
        }

        #region IAssembly Implementation
        /// <summary>
        /// The title of this assembly.
        /// </summary>
        public string Title => this.WrappedObject.GetCustomAttribute<AssemblyTitleAttribute>().Title;

        /// <summary>
        /// The version of this assembly.
        /// </summary>
        public string Version => this.WrappedObject.GetName().Version.ToString();
        #endregion
    }
}
