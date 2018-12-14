using System;
using AppSamuraiAds.Api;

namespace AppSamuraiAds.Common
{
    public interface IInterstitialClient
    {
        // Ad event fired when the interstitial ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;

        // Ad event fired when the interstitial ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        // Ad event fired when the interstitial ad is opened.
        event EventHandler<EventArgs> OnAdOpening;

        // Ad event fired when the interstitial ad is closed.
        event EventHandler<EventArgs> OnAdClosed;

        // Ad event fired when the interstitial ad is leaving the application.
        event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates an InterstitialAd.
        void CreateInterstitialAd(string adUnitId);

        // Loads a new interstitial request.
        void LoadAd(AdRequest request);

        // Loads a new interstitial request.
        void LoadAd();

        // Determines whether the interstitial has loaded.
        bool IsLoaded();

        // Shows the InterstitialAd.
        void ShowInterstitial();

        // Destroys an InterstitialAd.
        void DestroyInterstitial();
    }
}
