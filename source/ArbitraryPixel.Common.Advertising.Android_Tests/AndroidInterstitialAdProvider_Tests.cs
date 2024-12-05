using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ArbitraryPixel.Common.Advertising.Android;
using ArbitraryPixel.Common.Advertising.Android.Wrappers;
using NSubstitute;

namespace ArbitraryPixel.Common.Advertising.Android_Tests
{
    [TestClass]
    public class AndroidInterstitialAdProvider_Tests
    {
        private AndroidInterstitialAdProvider _sut;

        private IAdObjectFactory _mockAdObjectFactory;
        private IAdContext _mockAdContext;

        [TestInitialize]
        public void Initialize()
        {
            _mockAdObjectFactory = Substitute.For<IAdObjectFactory>();
            _mockAdContext = Substitute.For<IAdContext>();
        }

        private void Construct()
        {
            _sut = new AndroidInterstitialAdProvider(_mockAdObjectFactory, _mockAdContext, "1234");
        }

        #region Constructor Tests
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_AdObjectFactory()
        {
            _sut = new AndroidInterstitialAdProvider(null, _mockAdContext, "1234");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructWithNullParameterShouldThrowException_AdContext()
        {
            _sut = new AndroidInterstitialAdProvider(_mockAdObjectFactory, null, "1234");
        }
        #endregion

        #region Property Tests
        [TestMethod]
        public void AdReadyShouldDefaultFalse()
        {
            Construct();
            Assert.IsFalse(_sut.AdReady);
        }

        [TestMethod]
        public void AdsEnabledShouldDefaultTrue()
        {
            Construct();
            Assert.IsTrue(_sut.AdsEnabled);
        }

        [TestMethod]
        public void TestDeviceIdsShouldStoreValuesPutIn()
        {
            Construct();
            _sut.TestDeviceIds.Add("abcd");
            Assert.IsTrue(_sut.TestDeviceIds.Contains("abcd"));
        }
        #endregion

        #region InitialieAds Tests
        [TestMethod]
        public void InitializeAdsShouldCallAdObjectFactoryCreateIntersitialAd()
        {
            Construct();

            _sut.InitializeAds();

            _mockAdObjectFactory.Received(1).CreateInterstitialAd(_mockAdContext);
        }

        [TestMethod]
        public void InitializeAdsAfterInitializedShouldDisposeOfObjects()
        {
            Construct();

            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd, Substitute.For<IInterstitialAd>());
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener, Substitute.For<IAdListener>());

            _sut.InitializeAds();
            _sut.InitializeAds();

            Received.InOrder(
                () =>
                {
                    mockListener.Dispose();
                    mockAd.AdListener = null;
                    mockAd.Dispose();
                }
            );
        }

        [TestMethod]
        public void IntializeAdsShouldSetAdUnitIdOnInterstitialAd()
        {
            Construct();

            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);

            _sut.InitializeAds();

            mockAd.Received(1).AdUnitId = "1234";
        }

        [TestMethod]
        public void InitializeAdsShouldCallAdObjectFactoryCreateAdListener()
        {
            Construct();

            _sut.InitializeAds();

            _mockAdObjectFactory.Received(1).CreateAdListener();
        }

        [TestMethod]
        public void InitializeAdsShouldAddEventHandlerToAdListenerAdLoadedEvent()
        {
            Construct();

            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);

            _sut.InitializeAds();

            mockListener.AdLoaded += Arg.Any<EventHandler<EventArgs>>();
        }

        [TestMethod]
        public void InitializeAdsShouldAddEventHandlerToAdListenerAdClosedEvent()
        {
            Construct();

            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);

            _sut.InitializeAds();

            mockListener.AdClosed += Arg.Any<EventHandler<EventArgs>>();
        }

        [TestMethod]
        public void InitializeAdsShouldSetAdListenerOnInterstitialAd()
        {
            Construct();

            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);

            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);

            _sut.InitializeAds();

            mockAd.Received(1).AdListener = mockListener;
        }
        #endregion

        #region Event Tests
        [TestMethod]
        public void ListenerAdLoadedShouldSetAdReadyTrue()
        {
            Construct();
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);
            _sut.InitializeAds();

            mockListener.AdLoaded += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            Assert.IsTrue(_sut.AdReady);
        }

        [TestMethod]
        public void ListenerAdLoadedShouldFireAdLoadedEvent()
        {
            Construct();
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.AdLoaded += subscriber;
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);
            _sut.InitializeAds();

            mockListener.AdLoaded += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            subscriber.Received(1)(_sut, Arg.Any<EventArgs>());
        }

        [TestMethod]
        public void ListenerAdClosedShouldSetAdReadyToFalse()
        {
            Construct();
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);
            _sut.InitializeAds();
            mockListener.AdLoaded += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            mockListener.AdClosed += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            Assert.IsFalse(_sut.AdReady);
        }

        [TestMethod]
        public void ListenerAdClosedShouldFireAdClosedEvent()
        {
            Construct();
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.AdClosed += subscriber;
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);
            _sut.InitializeAds();

            mockListener.AdClosed += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            subscriber.Received(1)(_sut, Arg.Any<EventArgs>());
        }

        [TestMethod]
        public void ListenerAdClosedShouldRequestNewAd()
        {
            Construct();
            EventHandler<EventArgs> subscriber = Substitute.For<EventHandler<EventArgs>>();
            _sut.AdClosed += subscriber;

            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);

            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);

            _sut.InitializeAds();

            _sut.TestDeviceIds.Add("abcd");
            _sut.TestDeviceIds.Add("1234");

            IAdRequestBuilder mockBuilder = Substitute.For<IAdRequestBuilder>();
            _mockAdObjectFactory.CreateAdRequestBuilder().Returns(mockBuilder);

            IAdRequest mockRequest = Substitute.For<IAdRequest>();
            mockBuilder.Build().Returns(mockRequest);

            _mockAdObjectFactory.ClearReceivedCalls();

            mockListener.AdClosed += Raise.Event<EventHandler<EventArgs>>(mockListener, new EventArgs());

            Received.InOrder(
                () =>
                {
                    _mockAdObjectFactory.CreateAdRequestBuilder();
                    mockBuilder.AddTestDevice("abcd");
                    mockBuilder.AddTestDevice("1234");

                    mockBuilder.Build();

                    mockAd.LoadAd(mockRequest);
                }
            );
        }
        #endregion

        #region Dispose Tests
        [TestMethod]
        public void DisposeShouldCallAdListenerDispose()
        {
            Construct();
            IAdListener mockListener = Substitute.For<IAdListener>();
            _mockAdObjectFactory.CreateAdListener().Returns(mockListener);
            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);
            _sut.InitializeAds();

            _sut.Dispose();

            Received.InOrder(
                () =>
                {
                    mockListener.Dispose();
                    mockAd.AdListener = null;
                }
            );
        }

        [TestMethod]
        public void DisposeShouldCallAdDispose()
        {
            Construct();
            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);
            _sut.InitializeAds();

            _sut.Dispose();

            mockAd.Received(1).Dispose();
        }
        #endregion

        #region ShowAd Tests
        [TestMethod]
        [ExpectedException(typeof(AdProviderNotInitializedException))]
        public void ShowAdWithoutInitializeShouldThrowException()
        {
            Construct();
            _sut.ShowAd();
        }

        [TestMethod]
        [ExpectedException(typeof(AdsNotLoadedException))]
        public void ShowAdWithoutAdLoadedShouldThrowException()
        {
            Construct();
            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);
            _sut.InitializeAds();
            mockAd.IsLoaded.Returns(false);

            _sut.ShowAd();
        }

        [TestMethod]
        public void ShowAdShouldCallShowOnInterstitialAd()
        {
            Construct();
            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);
            _sut.InitializeAds();
            mockAd.IsLoaded.Returns(true);

            _sut.ShowAd();

            mockAd.Received(1).Show();
        }
        #endregion

        #region RequestAd Tests
        [TestMethod]
        [ExpectedException(typeof(AdProviderNotInitializedException))]
        public void RequestAdWhenNotInitializedShouldThrowException()
        {
            Construct();

            _sut.RequestAd();
        }

        [TestMethod]
        public void RequestAdShouldCallAdObjectFactoryCreateAdRequestBuilder()
        {
            Construct();

            _sut.InitializeAds();
            _sut.RequestAd();

            _mockAdObjectFactory.Received(1).CreateAdRequestBuilder();
        }

        [TestMethod]
        public void RequestAdShouldSetTestDeviceIdsOnAdRequestBuilder_TestA()
        {
            Construct();
            _sut.TestDeviceIds.Add("1234");
            _sut.TestDeviceIds.Add("abcd");

            IAdRequestBuilder mockBuilder = Substitute.For<IAdRequestBuilder>();
            _mockAdObjectFactory.CreateAdRequestBuilder().Returns(mockBuilder);

            _sut.InitializeAds();
            _sut.RequestAd();

            Received.InOrder(
                () =>
                {
                    mockBuilder.AddTestDevice("1234");
                    mockBuilder.AddTestDevice("abcd");
                }
            );
        }

        [TestMethod]
        public void RequestAdShouldSetTestDeviceIdsOnAdRequestBuilder_TestB()
        {
            Construct();
            _sut.TestDeviceIds.Add("haha");
            _sut.TestDeviceIds.Add("whee");

            IAdRequestBuilder mockBuilder = Substitute.For<IAdRequestBuilder>();
            _mockAdObjectFactory.CreateAdRequestBuilder().Returns(mockBuilder);

            _sut.InitializeAds();
            _sut.RequestAd();

            Received.InOrder(
                () =>
                {
                    mockBuilder.AddTestDevice("haha");
                    mockBuilder.AddTestDevice("whee");
                }
            );
        }

        [TestMethod]
        public void RequestAdShouldCallRequestBuilderBuild()
        {
            Construct();

            IAdRequestBuilder mockBuilder = Substitute.For<IAdRequestBuilder>();
            _mockAdObjectFactory.CreateAdRequestBuilder().Returns(mockBuilder);

            _sut.InitializeAds();
            _sut.RequestAd();

            mockBuilder.Received(1).Build();
        }

        [TestMethod]
        public void RequestAdShouldCallLoadAdOnInterstitialAd()
        {
            Construct();

            IInterstitialAd mockAd = Substitute.For<IInterstitialAd>();
            _mockAdObjectFactory.CreateInterstitialAd(Arg.Any<IAdContext>()).Returns(mockAd);

            IAdRequestBuilder mockBuilder = Substitute.For<IAdRequestBuilder>();
            _mockAdObjectFactory.CreateAdRequestBuilder().Returns(mockBuilder);

            IAdRequest mockRequest = Substitute.For<IAdRequest>();
            mockBuilder.Build().Returns(mockRequest);

            _sut.InitializeAds();
            _sut.RequestAd();

            mockAd.Received(1).LoadAd(mockRequest);
        }
        #endregion
    }
}
