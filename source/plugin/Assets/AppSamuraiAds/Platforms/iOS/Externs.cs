#if UNITY_IOS

using System;
using System.Runtime.InteropServices;

namespace AppSamuraiAds.iOS
{
    // Externs used by the iOS component.
    internal class Externs
    {
#region Common externs
        [DllImport("__Internal")]
        internal static extern void ASURelease(IntPtr obj);
#endregion

#region MobileAds externs
        [DllImport("__Internal")]
        internal static extern void ASUInitialize(string key);
        [DllImport("__Internal")]
        internal static extern string ASUGetSDKVersion();
        [DllImport("__Internal")]
        internal static extern void ASUSetLogEnabled(bool logEnabled);
#endregion

#region BannerView externs
        [DllImport("__Internal")]
        internal static extern IntPtr ASUCreateBannerView(IntPtr bannerClient, string adUnitId);
        [DllImport("__Internal")]
        internal static extern void ASUSetBannerCallbacks(
            IntPtr bannerView,
            BannerClient.ASUAdViewDidReceiveAdCallback adReceivedCallback,
            BannerClient.ASUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
            BannerClient.ASUAdViewWillLeaveApplicationCallback willLeaveCallback);
        [DllImport("__Internal")]
        internal static extern void ASULoadBannerAd(IntPtr bannerView, IntPtr adRequest);
        [DllImport("__Internal")]
        internal static extern void ASUHideBannerView(IntPtr bannerView);
        [DllImport("__Internal")]
        internal static extern void ASUShowBannerView(IntPtr bannerView);
        [DllImport("__Internal")]
        internal static extern void ASURemoveBannerView(IntPtr bannerView);
#endregion

#region Interstitial externs
        [DllImport("__Internal")]
        internal static extern IntPtr ASUCreateInterstitial(IntPtr interstitialClient, string adUnitId);
        [DllImport("__Internal")]
        internal static extern void ASUSetInterstitialCallbacks(
            IntPtr interstitial,
            InterstitialClient.ASUInterstitialDidReceiveAdCallback adReceivedCallback,
            InterstitialClient.ASUInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback,
            InterstitialClient.ASUInterstitialWillPresentScreenCallback willPresentCallback,
            InterstitialClient.ASUInterstitialDidDismissScreenCallback didDismissCallback,
            InterstitialClient.ASUInterstitialWillLeaveApplicationCallback willLeaveCallback);
        [DllImport("__Internal")]
        internal static extern void ASULoadInterstitial(IntPtr interstitial, IntPtr adRequest);
        [DllImport("__Internal")]
        internal static extern void ASUShowInterstitial(IntPtr interstitial);
        [DllImport("__Internal")]
        internal static extern bool ASUInterstitialReady(IntPtr interstitial);
#endregion

#region RewardBasedVideoAd externs
        [DllImport("__Internal")]
        internal static extern IntPtr ASUCreateRewardBasedVideoAd(IntPtr rewardBasedVideoAd, string adUnitID);
        [DllImport("__Internal")]
        internal static extern IntPtr ASUSetRewardBasedVideoAdCallbacks(
            IntPtr rewardBasedVideoAd,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidReceiveAdCallback adReceivedCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback adFailedCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidPresentScreenCallback didOpenCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidDismissScreenCallback didCloseCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidVideoStartedCallback didStartCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidVideoCompletedCallback didCompleteCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdDidRewardReceivedCallback didRewardCallback,
            RewardBasedVideoAdClient.ASURewardBasedVideoAdWillLeaveApplicationCallback willLeaveCallback);
        [DllImport("__Internal")]
        internal static extern void ASULoadRewardBasedVideoAd(IntPtr rewardBasedVideoAd, IntPtr adRequest);
        [DllImport("__Internal")]
        internal static extern void ASUShowRewardBasedVideoAd(IntPtr rewardBasedVideoAd);
        [DllImport("__Internal")]
        internal static extern bool ASURewardBasedVideoAdReady(IntPtr rewardBasedVideoAd);
#endregion

#region AdRequest externs
        [DllImport("__Internal")]
        internal static extern IntPtr ASUCreateAdRequest();
        [DllImport("__Internal")]
        internal static extern IntPtr ASUAddTestDevice(IntPtr adRequest, string testDevice);
        [DllImport("__Internal")]
        internal static extern IntPtr ASUAddSupportedFormat(IntPtr adRequest, string supportedFormat);
#endregion
    }
}

#endif
