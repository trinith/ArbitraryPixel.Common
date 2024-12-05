using System;

namespace ArbitraryPixel.Common
{
    /// <summary>
    /// An implementation of IDateTimeFactory using System.DateTime.
    /// </summary>
    public class DotNetDateTimeFactory : IDateTimeFactory
    {
        /// <summary>
        /// Gets a IDateTime object that is set to the current date and time on this computer, expressed as the local time.
        /// </summary>
        public IDateTime Now
        {
            get { return new DotNetDateTime(DateTime.Now); }
        }
    }
}
