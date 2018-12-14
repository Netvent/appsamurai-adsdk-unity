using System;

using AppSamuraiAds.Api;
using AppSamuraiAds.Common;
using UnityEngine;

namespace AppSamuraiAds.Android
{
    public class InterstitialClient : AndroidJavaProxy, IInterstitialClient
    {
        private AndroidJavaObject interstitial;

        public InterstitialClient() : base(Utils.UnityAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =
                    playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            this.interstitial = new AndroidJavaObject(
                Utils.InterstitialClassName, activity, this);
        }

        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates an interstitial ad.
        public void CreateInterstitialAd(string adUnitId)
        {
            this.interstitial.Call("create", adUnitId);
        }

        // Loads an ad.
        public void LoadAd(AdRequest request)
        {
            this.interstitial.Call("loadAd", Utils.GetAdRequestJavaObject(request));
        }

        // Loads an ad.
        public void LoadAd()
        {
            this.interstitial.Call("loadAd");
        }

        // Checks if interstitial has loaded.
        public bool IsLoaded()
        {
            return this.interstitial.Call<bool>("isLoaded");
        }

        // Presents the interstitial ad on the screen.
        public void ShowInterstitial()
        {
            this.interstitial.Call("show");
        }

        // Destroys the interstitial ad.
        public void DestroyInterstitial()
        {
            this.interstitial.Call("destroy");
        }

        public void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        public void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        public void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        public void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        public void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }
    }
}
