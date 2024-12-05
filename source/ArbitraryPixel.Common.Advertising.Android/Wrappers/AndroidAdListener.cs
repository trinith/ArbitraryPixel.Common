using Android.Gms.Ads;
using System;

namespace ArbitraryPixel.Common.Advertising.Android.Wrappers
{
    public class AndroidAdListener : WrapperBase<AdListener>, IAdListener
    {
        /// <summary>
        /// An event that occurs when an ad is loaded.
        /// </summary>
        public event EventHandler<EventArgs> AdLoaded;

        /// <summary>
        /// An event that occurs when an ad is closed.
        /// </summary>
        public event EventHandler<EventArgs> AdClosed;

        /// <summary>
        /// Create a new object.
        /// </summary>
        public AndroidAdListener(AdListener objectToWrap) : base(objectToWrap)
        {
            // Hook up event pass throughs to our wrapped object.
            AdListenerImpl impl = this.GetWrappedObject<AdListenerImpl>();
            if (impl != null)
            {
                impl.AdLoaded += (sender, e) => OnAdLoaded(e);
                impl.AdClosed += (sender, e) => OnAdClosed(e);
            }
        }

        /// <summary>
        /// Dispose of this object and it's wrapped components.
        /// </summary>
        public void Dispose()
        {
            this.WrappedObject.Dispose();
        }

        /// <summary>
        /// Triggers an AdLoaded event with the specified event arguments.
        /// </summary>
        /// <param name="e">The arguments for this event.</param>
        protected virtual void OnAdLoaded(EventArgs e)
        {
            if (this.AdLoaded != null)
                this.AdLoaded(this, e);
        }

        /// <summary>
        /// Triggers an AdClosed event with the specified event arguments.
        /// </summary>
        /// <param name="e">The arguments for this event.</param>
        protected virtual void OnAdClosed(EventArgs e)
        {
            if (this.AdClosed != null)
                this.AdClosed(this, e);
        }
    }
}