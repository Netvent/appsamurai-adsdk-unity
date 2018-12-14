using System;

using AppSamuraiAds.Api;

namespace AppSamuraiAds.Common
{
    public interface IAdLoaderClient
    {
        event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;

        void LoadAd(AdRequest request);
    }
}
