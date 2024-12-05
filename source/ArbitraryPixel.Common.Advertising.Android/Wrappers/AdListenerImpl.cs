using Android.Gms.Ads;
using System;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    /// <summary>
    /// AdListener is an abstract class so we need to implement an Android version of it.
    /// </summary>
    internal class AdListenerImpl : AdListener
    {
        public event EventHandler<EventArgs> AdLoaded;
        public event EventHandler<EventArgs> AdClosed;

        public override void OnAdLoaded()
        {
            base.OnAdLoaded();

            if (this.AdLoaded != null)
                this.AdLoaded(this, new EventArgs());
        }

        public override void OnAdClosed()
        {
            base.OnAdClosed();

            if (this.AdClosed != null)
                this.AdClosed(this, new EventArgs());
        }
    }
}