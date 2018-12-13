using System;
using System.Reflection;

using AppSamuraiAds.Common;

namespace AppSamuraiAds.Api
{
    public class BannerView
    {
        private IBannerClient client;

        // Creates a BannerView and adds it to the view hierarchy.
        public BannerView(string adUnitId, AdSize adSize, AdPosition position)
        {
            Type mobileAdsClientFactory = Type.GetType("AppSamuraiAds.MobileAdsClientFactory,Assembly-CSharp");
            MethodInfo method = mobileAdsClientFactory.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
            client =  (IBannerClient)method.Invoke(null, null);

            client.CreateBannerView(adUnitId, adSize, position);
            ConfigureBannerEvents();
        }

        // Creates a BannerView with a custom position.
        public BannerView(string adUnitId, AdSize adSize, int x, int y)
        {
            Type mobileAdsClientFactory = Type.GetType("AppSamuraiAds.MobileAdsClientFactory,Assembly-CSharp");
            MethodInfo method = mobileAdsClientFactory.GetMethod("BuildBannerClient", BindingFlags.Static | BindingFlags.Public);
            client = (IBannerClient)method.Invoke(null, null);

            client.CreateBannerView(adUnitId, adSize, x, y);
            ConfigureBannerEvents();
        }

        // These are the ad callback events that can be hooked into.
        public event EventHandler<EventArgs> OnAdLoaded;

        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        public event EventHandler<EventArgs> OnAdOpening;

        public event EventHandler<EventArgs> OnAdClosed;

        public event EventHandler<EventArgs> OnAdLeavingApplication;

        // Loads an ad into the BannerView.
        public void LoadAd(AdRequest request)
        {
            client.LoadAd(request);
        }

        public void LoadAd()
        {
            client.LoadAd();
        }

        // Hides the BannerView from the screen.
        public void Hide()
        {
            client.HideBannerView();
        }

        // Shows the BannerView on the screen.
        public void Show()
        {
            client.ShowBannerView();
        }

        // Destroys the BannerView.
        public void Destroy()
        {
            client.DestroyBannerView();
        }

        // Returns the height of the BannerView in pixels.
        public float GetHeightInPixels()
        {
            return client.GetHeightInPixels();
        }

        // Returns the width of the BannerView in pixels.
        public float GetWidthInPixels()
        {
            return client.GetWidthInPixels();
        }

        // Set the position of the BannerView using standard position.
        public void SetPosition(AdPosition adPosition)
        {
            client.SetPosition(adPosition);
        }

        // Set the position of the BannerView using custom position.
        public void SetPosition(int x, int y)
        {
            client.SetPosition(x, y);
        }

        private void ConfigureBannerEvents()
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
