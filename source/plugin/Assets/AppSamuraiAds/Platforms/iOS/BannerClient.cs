#if UNITY_IOS

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using AppSamuraiAds.Api;
using AppSamuraiAds.Common;

using AOT;

namespace AppSamuraiAds.iOS
{
    public class BannerClient : IBannerClient, IDisposable
    {
        private IntPtr bannerViewPtr;

        private IntPtr bannerClientPtr;

#region Banner callback types

        internal delegate void ASUAdViewDidReceiveAdCallback(IntPtr bannerClient);

        internal delegate void ASUAdViewDidFailToReceiveAdWithErrorCallback(IntPtr bannerClient, string errorMessage);

        internal delegate void ASUAdViewWillLeaveApplicationCallback(IntPtr bannerClient);

#endregion

        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // This property should be used when setting the bannerViewPtr.
        private IntPtr BannerViewPtr
        {
            get
            {
                return this.bannerViewPtr;
            }

            set
            {
                Externs.ASURelease(this.bannerViewPtr);
                this.bannerViewPtr = value;
            }
        }

#region IBannerClient implementation

        // Creates a banner view.
        public void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            this.bannerClientPtr = (IntPtr)GCHandle.Alloc(this);
            this.BannerViewPtr = Externs.ASUCreateBannerView(this.bannerClientPtr, adUnitId);

            Externs.ASUSetBannerCallbacks(
                    this.BannerViewPtr,
                    AdViewDidReceiveAdCallback,
                    AdViewDidFailToReceiveAdWithErrorCallback,
                    AdViewWillLeaveApplicationCallback);
        }

        public void CreateBannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            this.bannerClientPtr = (IntPtr)GCHandle.Alloc(this);
            this.BannerViewPtr = Externs.ASUCreateBannerView(this.bannerClientPtr, adUnitId);

            Externs.ASUSetBannerCallbacks(
                    this.BannerViewPtr,
                    AdViewDidReceiveAdCallback,
                    AdViewDidFailToReceiveAdWithErrorCallback,
                    AdViewWillLeaveApplicationCallback);
        }

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            IntPtr requestPtr = AdRequestUtil.BuildAdRequest(request);
            Externs.ASULoadBannerAd(this.BannerViewPtr, requestPtr);
            Externs.ASURelease(requestPtr);
        }

        public void LoadAd()
        {
            IntPtr requestPtr = AdRequestUtil.BuildAdRequest();
            Externs.ASULoadBannerAd(this.BannerViewPtr, requestPtr);
            Externs.ASURelease(requestPtr);
        }

        // Displays the banner view on the screen.
        public void ShowBannerView()
        {
            Externs.ASUShowBannerView(this.BannerViewPtr);
        }

        // Hides the banner view from the screen.
        public void HideBannerView()
        {
            Externs.ASUHideBannerView(this.BannerViewPtr);
        }

        // Destroys the banner view.
        public void DestroyBannerView()
        {
            Externs.ASURemoveBannerView(this.BannerViewPtr);
            this.BannerViewPtr = IntPtr.Zero;
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            return 0;
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            return 0;
        }

        // Set the position of the banner view using standard position.
        public void SetPosition(AdPosition adPosition)
        {
        }

        // Set the position of the banner view using custom position.
        public void SetPosition(int x, int y)
        {
        }

        public void Dispose()
        {
            this.DestroyBannerView();
            ((GCHandle)this.bannerClientPtr).Free();
        }

        ~BannerClient()
        {
            this.Dispose();
        }

#endregion

#region Banner callback methods

        [MonoPInvokeCallback(typeof(ASUAdViewDidReceiveAdCallback))]
        private static void AdViewDidReceiveAdCallback(IntPtr bannerClient)
        {
            BannerClient client = IntPtrToBannerClient(bannerClient);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(ASUAdViewDidFailToReceiveAdWithErrorCallback))]
        private static void AdViewDidFailToReceiveAdWithErrorCallback(IntPtr bannerClient, string errorMessage)
        {
            BannerClient client = IntPtrToBannerClient(bannerClient);
            if (client.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorMessage
                };
                client.OnAdFailedToLoad(client, args);
            }
        }

        [MonoPInvokeCallback(typeof(ASUAdViewWillLeaveApplicationCallback))]
        private static void AdViewWillLeaveApplicationCallback(IntPtr bannerClient)
        {
            BannerClient client = IntPtrToBannerClient(bannerClient);
            if (client.OnAdLeavingApplication != null)
            {
                client.OnAdLeavingApplication(client, EventArgs.Empty);
            }
        }

        private static BannerClient IntPtrToBannerClient(IntPtr bannerClient)
        {
            GCHandle handle = (GCHandle)bannerClient;
            return handle.Target as BannerClient;
        }

#endregion
    }
}

#endif
