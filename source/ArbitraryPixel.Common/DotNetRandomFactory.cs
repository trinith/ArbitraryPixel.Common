using System;

#pragma warning disable 1591

namespace ArbitraryPixel.Common
{
    public class DotNetRandomFactory : IRandomFactory
    {
        public IRandom Create()
        {
            return new DotNetRandom();
        }

        public IRandom Create(int seed)
        {
            return new DotNetRandom(seed);
        }
    }
}
