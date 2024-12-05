using System;
using ArbitraryPixel.Common.Audio;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace ArbitraryPixel.Common.Audio_Tests
{
    [TestClass]
    public class SoundResource_Tests
    {
        private SoundResource _sut;
        private ISoundResource _mockBaseResource;

        [TestInitialize]
        public void Initialize()
        {
            _mockBaseResource = Substitute.For<ISoundResource>();
        }

        private void Construct()
        {
            _sut = new SoundResource(_mockBaseResource);
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_BaseResource()
        {
            _sut = new SoundResource(null);
        }
        #endregion

        #region Enabled Tests
        [TestMethod]
        public void EnabledShouldReturnBaseResourceValue()
        {
            Construct();
            _mockBaseResource.Enabled.Returns(true);

            Assert.IsTrue(_sut.Enabled);
        }

        [TestMethod]
        public void EnabledSetWithDifferentValueShouldUpdateBaseResourceValue()
        {
            Construct();
            _mockBaseResource.Enabled.Returns(false);

            _sut.Enabled = true;

            _mockBaseResource.Received(1).Enabled = true;
        }

        [TestMethod]
        public void EnabledSetWithSameValueShouldNotUpdateBaseResourceValue()
        {
            Construct();
            _mockBaseResource.Enabled.Returns(true);

            _sut.Enabled = true;

            _mockBaseResource.Received(0).Enabled = Arg.Any<bool>();
        }

        [TestMethod]
        public void EnabledSetWithDifferentValueAndOwnedInstancesShouldUpdateOwnedInstanceValues()
        {
            Construct();
            ISound mockSoundA = Substitute.For<ISound>();
            ISound mockSoundB = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockSoundA, mockSoundB, Substitute.For<ISound>());
            _sut.CreateInstance();
            _sut.CreateInstance();
            _mockBaseResource.Enabled.Returns(false);
            mockSoundA.ClearReceivedCalls();
            mockSoundB.ClearReceivedCalls();

            _sut.Enabled = true;

            Received.InOrder(
                () =>
                {
                    mockSoundA.Enabled = true;
                    mockSoundB.Enabled = true;
                }
            );
        }

        [TestMethod]
        public void EnabledSetWithSameValueShouldNotUpdateOwnedInstances()
        {
            Construct();
            ISound mockSoundA = Substitute.For<ISound>();
            ISound mockSoundB = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockSoundA, mockSoundB, Substitute.For<ISound>());
            _sut.CreateInstance();
            _sut.CreateInstance();
            _mockBaseResource.Enabled.Returns(true);
            mockSoundA.ClearReceivedCalls();
            mockSoundB.ClearReceivedCalls();

            _sut.Enabled = true;

            mockSoundA.DidNotReceive().Enabled = Arg.Any<bool>();
            mockSoundB.DidNotReceive().Enabled = Arg.Any<bool>();
        }
        #endregion

        #region CreateInstance Tests
        [TestMethod]
        public void CreateInstanceShouldCallBaseResourceCreateInstance()
        {
            Construct();

            _sut.CreateInstance();

            _mockBaseResource.Received(1).CreateInstance();
        }

        [TestMethod]
        public void CreateInstanceShouldSetEnabledOnCreatedInstance()
        {
            Construct();
            ISound mockInstance = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockInstance);
            _mockBaseResource.Enabled.Returns(false);

            _sut.CreateInstance();

            mockInstance.Received(1).Enabled = false;
        }

        [TestMethod]
        public void CreateInstanceShouldAttachEventHandlerToCreatedInstanceDisposed()
        {
            Construct();
            ISound mockInstance = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockInstance);
            _mockBaseResource.Enabled.Returns(false);

            _sut.CreateInstance();

            mockInstance.Received(1).Disposed += Arg.Any<EventHandler<EventArgs>>();
        }

        [TestMethod]
        public void CreateInstanceShouldReturnCreatedInstance()
        {
            Construct();
            ISound mockInstance = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockInstance);
            _mockBaseResource.Enabled.Returns(false);

            var createdInstance = _sut.CreateInstance();

            Assert.AreSame(mockInstance, createdInstance);
        }
        #endregion

        #region Play Tests
        [TestMethod]
        public void PlayWhenEnabledShouldCallBaseResourcePlay()
        {
            Construct();
            _mockBaseResource.Enabled.Returns(true);

            _sut.Play();

            _mockBaseResource.Received(1).Play();
        }

        [TestMethod]
        public void PlayWhenDisabledShouldNotCallBaseResourcePlay()
        {
            Construct();
            _mockBaseResource.Enabled.Returns(false);

            _sut.Play();

            _mockBaseResource.Received(0).Play();
        }
        #endregion

        #region StopAll Tests
        [TestMethod]
        public void StopAllShouldCallStopOnAllOwnedInstances()
        {
            Construct();
            ISound mockSoundA = Substitute.For<ISound>();
            ISound mockSoundB = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockSoundA, mockSoundB, Substitute.For<ISound>());
            _sut.CreateInstance();
            _sut.CreateInstance();
            mockSoundA.ClearReceivedCalls();
            mockSoundB.ClearReceivedCalls();

            _sut.StopAll();

            Received.InOrder(
                () =>
                {
                    mockSoundA.Stop();
                    mockSoundB.Stop();
                }
            );
        }
        #endregion

        #region Dispose Tests
        [TestMethod]
        public void DisposeWhenNotDisposedShouldCallDisposeOnOwnedInstances()
        {
            Construct();
            ISound mockSoundA = Substitute.For<ISound>();
            ISound mockSoundB = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockSoundA, mockSoundB, Substitute.For<ISound>());
            _sut.CreateInstance();
            _sut.CreateInstance();
            _mockBaseResource.IsDisposed.Returns(false);
            mockSoundA.ClearReceivedCalls();
            mockSoundB.ClearReceivedCalls();

            _sut.Dispose();

            Received.InOrder(
                () =>
                {
                    mockSoundA.Dispose();
                    mockSoundB.Dispose();
                }
            );
        }

        [TestMethod]
        public void DisposeWhenDisposedShouldNotCallDisposeOnOwnedInstances()
        {
            Construct();
            ISound mockSoundA = Substitute.For<ISound>();
            ISound mockSoundB = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockSoundA, mockSoundB, Substitute.For<ISound>());
            _sut.CreateInstance();
            _sut.CreateInstance();
            _mockBaseResource.IsDisposed.Returns(true);
            mockSoundA.ClearReceivedCalls();
            mockSoundB.ClearReceivedCalls();

            mockSoundA.DidNotReceive().Dispose();
            mockSoundB.DidNotReceive().Dispose();
        }

        [TestMethod]
        public void DisposeWhenNotDisposedShouldCallBaseResourceDispose()
        {
            Construct();
            _mockBaseResource.IsDisposed.Returns(false);

            _sut.Dispose();

            _mockBaseResource.Received(1).Dispose();
        }

        [TestMethod]
        public void DisposeWhenDisposedShouldNotcallBaseResourceDispose()
        {
            Construct();
            _mockBaseResource.IsDisposed.Returns(true);

            _sut.Dispose();

            _mockBaseResource.Received(0).Dispose();
        }

        [TestMethod]
        public void DisposeWhenNotDisposedShouldTriggerDisposedEvent()
        {
            Construct();
            _mockBaseResource.IsDisposed.Returns(false);
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.Disposed += subscriber;

            _sut.Dispose();

            subscriber.Received(1)(_sut, Arg.Any<EventArgs>());
        }

        [TestMethod]
        public void DisposeWhenDisposedShouldNotTriggerDisposedEvent()
        {
            Construct();
            _mockBaseResource.IsDisposed.Returns(false);
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.Disposed += subscriber;

            _sut.Dispose();

            subscriber.Received(1)(_sut, Arg.Any<EventArgs>());
        }
        #endregion

        #region Instance Dispose Tests
        [TestMethod]
        public void InstanceDisposeShouldRemoveInstanceFromTracking()
        {
            Construct();
            ISound mockInstance = Substitute.For<ISound>();
            _mockBaseResource.CreateInstance().Returns(mockInstance);
            _sut.CreateInstance();

            mockInstance.Disposed += Raise.Event<EventHandler<EventArgs>>(mockInstance, new EventArgs());

            _sut.MasterVolume = 0.123f;

            mockInstance.Received(0).Volume = Arg.Any<float>();
        }
        #endregion

        #region Pass-through Tests
        // Tests for anything that doesn't contain extra logic.
        [TestMethod]
        public void IsDisposedShouldReturnBaseResourceValue()
        {
            Construct();
            _mockBaseResource.IsDisposed.Returns(true);

            Assert.IsTrue(_sut.IsDisposed);
        }

        [TestMethod]
        public void MasterVolumeShouldReturnBaseResourceValue()
        {
            Construct();
            _mockBaseResource.MasterVolume.Returns(0.123f);

            Assert.AreEqual<float>(0.123f, _sut.MasterVolume);
        }

        [TestMethod]
        public void MasterVolumeSetShouldUpdateBaseResourceValue()
        {
            Construct();

            _sut.MasterVolume = 0.123f;

            _mockBaseResource.Received(1).MasterVolume = 0.123f;
        }
        #endregion
    }
}
