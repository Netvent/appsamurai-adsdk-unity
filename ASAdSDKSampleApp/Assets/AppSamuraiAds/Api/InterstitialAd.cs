using System;

using AppSamuraiAds.Common;

namespace AppSamuraiAds.Api
{
    public class InterstitialAd
    {
        private IInterstitialClient client;

        // Creates an InterstitialAd.
        public InterstitialAd(string adUnitId)
        {
            this.client = MobileAdsClientFactory.BuildInterstitialClient();
            client.CreateInterstitialAd(adUnitId);

            ConfigureInterstitialEvents();
        }

        // These are the ad callback events that can be hooked into.
        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Loads an InterstitialAd.
        public void LoadAd(AdRequest request)
        {
            client.LoadAd(request);
        }

        // Loads an InterstitialAd.
        public void LoadAd()
        {
            client.LoadAd();
        }

        // Determines whether the InterstitialAd has loaded.
        public bool IsLoaded()
        {
            return client.IsLoaded();
        }

        // Displays the InterstitialAd.
        public void Show()
        {
            client.ShowInterstitial();
        }

        // Destroys the InterstitialAd.
        public void Destroy()
        {
            client.DestroyInterstitial();
        }

        private void ConfigureInterstitialEvents()
        {
            this.client.OnAdLoaded += (sender, args) =>
            {
                if (this.OnAdLoaded != null)
                {
                    this.OnAdLoaded(this, args);
                }
            };

            this.client.OnAdFailedToLoad += (sender, args) =>
            {
                if (this.OnAdFailedToLoad != null)
                {
                    this.OnAdFailedToLoad(this, args);
                }
            };

            this.client.OnAdOpening += (sender, args) =>
            {
                if (this.OnAdOpening != null)
                {
                    this.OnAdOpening(this, args);
                }
            };

            this.client.OnAdClosed += (sender, args) =>
            {
                if (this.OnAdClosed != null)
                {
                    this.OnAdClosed(this, args);
                }
            };

            this.client.OnAdLeavingApplication += (sender, args) =>
            {
                if (this.OnAdLeavingApplication != null)
                {
                    this.OnAdLeavingApplication(this, args);
                }
            };
        }
    }
}
