using System;

namespace ArbitraryPixel.Common.Advertising
{
    /// <summary>
    /// An exception that is thrown when an operation is requested on an AdProvider but it has not yet been initialized.
    /// </summary>
    public class AdProviderNotInitializedException : Exception { }

    /// <summary>
    /// An exception that is thrown when an ad is asked to show but has not yet been loaded.
    /// </summary>
    public class AdsNotLoadedException : Exception { }
}
