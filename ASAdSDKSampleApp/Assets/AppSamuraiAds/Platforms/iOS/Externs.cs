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
        internal static extern void ASUInitialize(string key);
        [DllImport("__Internal")]
        internal static extern void ASURelease(IntPtr obj);
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
        internal static extern void ASURequestBannerAd(IntPtr bannerView);
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
        internal static extern void ASURequestInterstitial(IntPtr interstitial);
        [DllImport("__Internal")]
        internal static extern void ASUShowInterstitial(IntPtr interstitial);
        [DllImport("__Internal")]
        internal static extern bool ASUInterstitialReady(IntPtr interstitial);
#endregion

#region RewardBasedVideoAd externs
        [DllImport("__Internal")]
        internal static extern IntPtr ASUCreateRewardBasedVideoAd(IntPtr rewardBasedVideoAd);
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
        internal static extern void ASURequestRewardBasedVideoAd(IntPtr rewardBasedVideoAd, string adUnitID);
        [DllImport("__Internal")]
        internal static extern void ASUShowRewardBasedVideoAd(IntPtr rewardBasedVideoAd);
        [DllImport("__Internal")]
        internal static extern bool ASURewardBasedVideoAdReady(IntPtr rewardBasedVideoAd);
#endregion
    }
}

#endif
