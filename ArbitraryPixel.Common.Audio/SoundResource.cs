using System;
using System.Collections.Generic;

namespace ArbitraryPixel.Common.Audio
{
    /// <summary>
    /// An implementation of ISoundResource that adds the ability to track instances created by a wrapped ISoundResource object.
    /// </summary>
    public class SoundResource : ISoundResource
    {
        private ISoundResource _baseResource;
        private List<ISound> _ownedInstances = new List<ISound>();

        /// <summary>
        /// Create a new instance.
        /// </summary>
        /// <param name="baseResource">An ISoundResource object that this object will track instances for.</param>
        public SoundResource(ISoundResource baseResource)
        {
            _baseResource = baseResource ?? throw new ArgumentNullException();
        }

        #region ISoundResource Implementation
        /// <summary>
        /// Whether or not ISound objects created and owned by this resource should audibly play sound. All instances created from this resource will have their Enabled values updated to the value set.
        /// </summary>
        public bool Enabled
        {
            get { return _baseResource.Enabled; }
            set
            {
                if (value != _baseResource.Enabled)
                {
                    _baseResource.Enabled = value;

                    foreach (ISound instance in _ownedInstances)
                        instance.Enabled = value;
                }
            }
        }

        /// <summary>
        /// Whether or not this object has been disposed.
        /// </summary>
        public bool IsDisposed
        {
            get => _baseResource.IsDisposed;
        }

        /// <summary>
        /// The master volume of all ISound objects created from this resource.
        /// </summary>
        public float MasterVolume
        {
            get => _baseResource.MasterVolume;
            set => _baseResource.MasterVolume = value;
        }

        /// <summary>
        /// An event that occurs when this sound has been disposed.
        /// </summary>
        public event EventHandler<EventArgs> Disposed;

        /// <summary>
        /// Create a new instance of a sound from this resource. This resource will track created instances and, when disposed, will remove them from tracking.
        /// </summary>
        /// <returns>The newly created sound instance.</returns>
        public ISound CreateInstance()
        {
            ISound newInstance = _baseResource.CreateInstance();
            newInstance.Enabled = this.Enabled;
            newInstance.Disposed += Handle_SoundInstanceDisposed;

            _ownedInstances.Add(newInstance);

            return newInstance;
        }

        /// <summary>
        /// Create a sound and play it automatically.
        /// </summary>
        public void Play()
        {
            if (this.Enabled)
                _baseResource.Play();
        }

        /// <summary>
        /// Stop all instances of sounds created from this resource.
        /// </summary>
        public void StopAll()
        {
            foreach (ISound instance in _ownedInstances)
                instance.Stop();
        }
        #endregion

        #region IDisposable Implementation
        /// <summary>
        /// Dispose of this resource. All instances created by this resource will also be disposed.
        /// </summary>
        public void Dispose()
        {
            if (!this.IsDisposed)
            {
                List<ISound> ownedSounds = new List<ISound>(_ownedInstances);
                foreach (ISound sound in ownedSounds)
                    sound.Dispose();

                _baseResource.Dispose();

                if (this.Disposed != null)
                    this.Disposed(this, new EventArgs());
            }
        }
        #endregion

        private void Handle_SoundInstanceDisposed(object sender, EventArgs e)
        {
            if (sender is ISound && _ownedInstances.Contains((ISound)sender))
                _ownedInstances.Remove((ISound)sender);
        }
    }
}
