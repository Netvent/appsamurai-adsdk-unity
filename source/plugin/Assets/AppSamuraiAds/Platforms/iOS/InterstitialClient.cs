#if UNITY_IOS

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using AppSamuraiAds.Api;
using AppSamuraiAds.Common;

using AOT;

namespace AppSamuraiAds.iOS
{

    public class InterstitialClient : IInterstitialClient, IDisposable
    {
        private IntPtr interstitialPtr;
        private IntPtr interstitialClientPtr;

#region Interstitial callback types
        internal delegate void ASUInterstitialDidReceiveAdCallback(IntPtr interstitialClient);
        internal delegate void ASUInterstitialDidFailToReceiveAdWithErrorCallback(IntPtr interstitialClient, string errorMessage);
        internal delegate void ASUInterstitialWillPresentScreenCallback(IntPtr interstitialClient);
        internal delegate void ASUInterstitialDidDismissScreenCallback(IntPtr interstitialClient);
        internal delegate void ASUInterstitialWillLeaveApplicationCallback(IntPtr interstitialClient);
#endregion

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<EventArgs> OnAdOpening;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // This property should be used when setting the interstitialPtr.
        private IntPtr InterstitialPtr
        {
            get
            {
                return this.interstitialPtr;
            }

            set
            {
                Externs.ASURelease(this.interstitialPtr);
                this.interstitialPtr = value;
            }
        }

        public void CreateInterstitialAd(string adUnitId)
        {
            this.interstitialClientPtr = (IntPtr)GCHandle.Alloc(this);
            this.InterstitialPtr = Externs.ASUCreateInterstitial(this.interstitialClientPtr, adUnitId);

            Externs.ASUSetInterstitialCallbacks(
                this.InterstitialPtr,
                InterstitialAdLoadedCallback,
                InterstitialAdFailedCallback,
                InterstitialWillPresentScreenCallback,
                InterstitialDidDismissScreenCallback,
                InterstitialWillLeaveApplicationCallback);
        }

        public bool IsLoaded()
        {
            return Externs.ASUInterstitialReady(this.InterstitialPtr);
        }

        public void ShowInterstitial()
        {
            Externs.ASUShowInterstitial(this.InterstitialPtr);
        }

        public void DestroyInterstitial()
        {
            this.InterstitialPtr = IntPtr.Zero;
        }

        public void LoadAd(AdRequest request)
        {
            IntPtr requestPtr = AdRequestUtil.BuildAdRequest(request);
            Externs.ASULoadInterstitial(this.InterstitialPtr, requestPtr);
            Externs.ASURelease(requestPtr);
        }

        public void LoadAd()
        {
            IntPtr requestPtr = AdRequestUtil.BuildAdRequest();
            Externs.ASULoadInterstitial(this.InterstitialPtr, requestPtr);
            Externs.ASURelease(requestPtr);
        }

        public void Dispose()
        {
            this.DestroyInterstitial();
            ((GCHandle)this.interstitialClientPtr).Free();
        }

        ~InterstitialClient()
        {
            this.Dispose();
        }

#region Interstitial callback methods
        [MonoPInvokeCallback(typeof(ASUInterstitialDidReceiveAdCallback))]
        private static void InterstitialAdLoadedCallback(IntPtr interstitialClient)
        {
            InterstitialClient client = IntPtrToInterstitialClient(interstitialClient);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASUInterstitialDidFailToReceiveAdWithErrorCallback))]
        private static void InterstitialAdFailedCallback(IntPtr interstitialClient, string errorMessage)
        {
            InterstitialClient client = IntPtrToInterstitialClient(interstitialClient);
            if (client.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorMessage
                };
                client.OnAdFailedToLoad(client, args);
            }
        }
        [MonoPInvokeCallback(typeof(ASUInterstitialWillPresentScreenCallback))]
        private static void InterstitialWillPresentScreenCallback(IntPtr interstitialClient)
        {
            InterstitialClient client = IntPtrToInterstitialClient(interstitialClient);
            if (client.OnAdOpening != null)
            {
                client.OnAdOpening(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASUInterstitialDidDismissScreenCallback))]
        private static void InterstitialDidDismissScreenCallback(IntPtr interstitialClient)
        {
            InterstitialClient client = IntPtrToInterstitialClient(interstitialClient);
            if (client.OnAdClosed != null)
            {
                client.OnAdClosed(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASUInterstitialWillLeaveApplicationCallback))]
        private static void InterstitialWillLeaveApplicationCallback(IntPtr interstitialClient)
        {
            InterstitialClient client = IntPtrToInterstitialClient(interstitialClient);
            if (client.OnAdLeavingApplication != null)
            {
                client.OnAdLeavingApplication(client, EventArgs.Empty);
            }
        }
        private static InterstitialClient IntPtrToInterstitialClient(IntPtr interstitialClient)
        {
            GCHandle handle = (GCHandle)interstitialClient;
            return handle.Target as InterstitialClient;
        }
#endregion
    }
}

#endif
