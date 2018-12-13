using System;

using AppSamuraiAds.Api;

namespace AppSamuraiAds.Common
{
    public interface IBannerClient
    {
        // Ad event fired when the banner ad has been received.
        event EventHandler<EventArgs> OnAdLoaded;

        // Ad event fired when the banner ad has failed to load.
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        // Ad event fired when the banner ad is opened.
        event EventHandler<EventArgs> OnAdOpening;

        // Ad event fired when the banner ad is closed.
        event EventHandler<EventArgs> OnAdClosed;

        // Ad event fired when the banner ad is leaving the application.
        event EventHandler<EventArgs> OnAdLeavingApplication;

        // Creates a banner view and adds it to the view hierarchy.
        void CreateBannerView(string adUnitId, AdSize adSize, AdPosition position);

        // Creates a banner view and adds it to the view hierarchy with a custom position.
        void CreateBannerView(string adUnitId, AdSize adSize, int x, int y);

        // Requests a new ad for the banner view.
        void LoadAd(AdRequest request);

        // Requests a new ad for the banner view.
        void LoadAd();

        // Shows the banner view on the screen.
        void ShowBannerView();

        // Hides the banner view from the screen.
        void HideBannerView();

        // Destroys a banner view.
        void DestroyBannerView();

        // Returns the height of the BannerView in pixels.
        float GetHeightInPixels();

        // Returns the width of the BannerView in pixels.
        float GetWidthInPixels();

        // Set the position of the banner view using standard position.
        void SetPosition(AdPosition adPosition);

        // Set the position of the banner view using custom position.
        void SetPosition(int x, int y);
    }
}