using AppSamuraiAds.Common;

namespace AppSamuraiAds
{
    public class MobileAdsClientFactory
    {
        public static IMobileAdsClient MobileAdsInstance()
        {
            #if UNITY_ANDROID
                return AppSamuraiAds.Android.MobileAdsClient.Instance;
            #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return AppSamuraiAds.iOS.MobileAdsClient.Instance;
            #else
                return null;
            #endif
        }

        public static IBannerClient BuildBannerClient()
        {
            #if UNITY_ANDROID
                return new AppSamuraiAds.Android.BannerClient();
            #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return new AppSamuraiAds.iOS.BannerClient();
            #else
                return null;
            #endif
        }

        public static IInterstitialClient BuildInterstitialClient()
        {
            #if UNITY_ANDROID
                return new AppSamuraiAds.Android.InterstitialClient();
            #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return new AppSamuraiAds.iOS.InterstitialClient();
            #else
                return null;
            #endif
        }

        public static IRewardBasedVideoAdClient BuildRewardedVideoAdClient()
        {
            #if UNITY_ANDROID
                return new AppSamuraiAds.Android.RewardBasedVideoAdClient();
            #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
                return new AppSamuraiAds.iOS.RewardBasedVideoAdClient();
            #else
                    return null;
            #endif
        }
    }
}
