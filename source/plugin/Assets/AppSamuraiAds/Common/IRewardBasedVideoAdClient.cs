using System;
using AppSamuraiAds.Api;

namespace AppSamuraiAds.Common
{
    public interface IRewardBasedVideoAdClient
    {
        // Ad event fired when the reward based video ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;
        // Ad event fired when the reward based video ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        // Ad event fired when the reward based video ad is opened.
        event EventHandler<EventArgs> OnAdOpening;
        // Ad event fired when the reward based video ad has started playing.
        event EventHandler<EventArgs> OnAdStarted;
        // Ad event fired when the reward based video ad has rewarded the user.
        event EventHandler<EventArgs> OnAdRewarded;
        // Ad event fired when the reward based video ad is closed.
        event EventHandler<EventArgs> OnAdClosed;
        // Ad event fired when the reward based video ad is leaving the application.
        event EventHandler<EventArgs> OnAdLeavingApplication;
        // Ad event fired when the reward based video ad completes playing.
        event EventHandler<EventArgs> OnAdCompleted;

        // Creates a reward based video ad and adds it to the view hierarchy.
        void CreateRewardBasedVideoAd(string adUnitId);

        // Requests a new ad for the reward based video ad.
        void LoadAd(AdRequest request);

        // Requests a new ad for the reward based video ad.
        void LoadAd();

        // Determines whether the reward based video has loaded.
        bool IsLoaded();

        // Shows the reward based video ad on the screen.
        void ShowRewardBasedVideoAd();
    }
}
