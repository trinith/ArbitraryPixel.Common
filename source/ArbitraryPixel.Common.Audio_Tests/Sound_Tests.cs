using System;
using ArbitraryPixel.Common.Audio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ArbitraryPixel.Common.Audio_Tests
{
    [TestClass]
    public class Sound_Tests
    {
        private Sound _sut;
        private ISound _mockBaseSound;

        [TestInitialize]
        public void Initialize()
        {
            _mockBaseSound = Substitute.For<ISound>();
        }

        private void Construct()
        {
            _sut = new Sound(_mockBaseSound);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_BaseSound()
        {
            _sut = new Sound(null);
        }
        #endregion

        #region Enabled Tests
        [TestMethod]
        public void EnabledShouldReturnBaseSoundValue()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(true);

            Assert.IsTrue(_sut.Enabled);
        }

        [TestMethod]
        public void EnabledSetWithDifferentValueShouldSetBaseSoundValue()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(false);

            _sut.Enabled = true;

            _mockBaseSound.Received(1).Enabled = true;
        }

        [TestMethod]
        public void EnabledSetWithSameValueShouldNotSetBaseSoundValue()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(false);

            _sut.Enabled = false;

            _mockBaseSound.Received(0).Enabled = Arg.Any<bool>();
        }

        [TestMethod]
        public void EnabledSetFalseFromTrueWithNotStoppedSoundShouldCallBaseSoundStop()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(true);
            _mockBaseSound.State.Returns(SoundState.Playing);

            _sut.Enabled = false;

            _mockBaseSound.Received(1).Stop();
        }

        [TestMethod]
        public void EnabledSetFalseFromTrueWithStoppedSoundShouldNotCallBaseSoundStop()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(true);
            _mockBaseSound.State.Returns(SoundState.Stopped);

            _sut.Enabled = false;

            _mockBaseSound.Received(0).Stop();
        }
        #endregion

        #region Play Tests
        [TestMethod]
        public void PlayWithBaseSoundEnabledShouldCallBaseSoundPlay()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(true);

            _sut.Play();

            _mockBaseSound.Received(1).Play();
        }

        [TestMethod]
        public void PlayWithBaseSoundDisabledShouldNotCallBaseSoundPlay()
        {
            Construct();
            _mockBaseSound.Enabled.Returns(false);

            _sut.Play();

            _mockBaseSound.Received(0).Play();
        }
        #endregion

        #region Dispose Tests
        [TestMethod]
        public void DisposeWithBaseSoundNotDisposedShouldCallBaseSoundDispose()
        {
            Construct();
            _mockBaseSound.IsDisposed.Returns(false);

            _sut.Dispose();

            _mockBaseSound.Received(1).Dispose();
        }

        [TestMethod]
        public void DisposeWithBaseSoundDisposedShouldNotCallBaseSoundDispose()
        {
            Construct();
            _mockBaseSound.IsDisposed.Returns(true);

            _sut.Dispose();

            _mockBaseSound.Received(0).Dispose();
        }

        [TestMethod]
        public void DisposeWithBaseSoundNotDisposedShouldTriggerDisposedEvent()
        {
            Construct();
            _mockBaseSound.IsDisposed.Returns(false);
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.Disposed += subscriber;

            _sut.Dispose();

            subscriber.Received(1)(_sut, Arg.Any<EventArgs>());
        }

        [TestMethod]
        public void DisposeWithBaseSoundDisposedShouldNotTriggerDisposedEvent()
        {
            Construct();
            _mockBaseSound.IsDisposed.Returns(true);
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.Disposed += subscriber;

            _sut.Dispose();

            subscriber.Received(0)(_sut, Arg.Any<EventArgs>());
        }
        #endregion

        #region Pass-through Tests
        // Test any method/property that just passes through to the base object without doing any additional logic.
        [TestMethod]
        public void IsDisposedShouldReturnBaseSoundValue()
        {
            Construct();
            _mockBaseSound.IsDisposed.Returns(true);

            Assert.IsTrue(_sut.IsDisposed);
        }

        [TestMethod]
        public void StateShouldReturnBaseSoundValue()
        {
            Construct();
            _mockBaseSound.State.Returns(SoundState.Paused);

            Assert.AreEqual<SoundState>(SoundState.Paused, _sut.State);
        }

        [TestMethod]
        public void IsLoopedShouldReturnBaseSoundValue()
        {
            Construct();
            _mockBaseSound.IsLooped.Returns(true);

            Assert.IsTrue(_sut.IsLooped);
        }

        [TestMethod]
        public void IsLoopedSetShouldSetBaseSoundValue()
        {
            Construct();

            _sut.IsLooped = true;

            _mockBaseSound.Received(1).IsLooped = true;
        }

        [TestMethod]
        public void VolumeShouldReturnBaseSoundValue()
        {
            Construct();
            _mockBaseSound.Volume.Returns(0.123f);

            Assert.AreEqual<float>(0.123f, _sut.Volume);
        }

        [TestMethod]
        public void VolumeSetShouldSetBaseSoundValue()
        {
            Construct();

            _sut.Volume = 0.123f;

            _mockBaseSound.Received(1).Volume = 0.123f;
        }

        [TestMethod]
        public void StopShouldCallBaseSoundStop()
        {
            Construct();

            _sut.Stop();

            _mockBaseSound.Received(1).Stop();
        }
        #endregion
    }
}
