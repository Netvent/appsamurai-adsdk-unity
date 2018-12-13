using UnityEngine;
using System;
using System.Collections.Generic;

using AppSamuraiAds.Api;

namespace AppSamuraiAds.Android
{
    public class Utils
    {
        #region Fully-qualified class names

        #region AppSamura Mobile Ads SDK class names

        public const string AdListenerClassName = "com.appsamurai.ads.common.AdListener";

        public const string AdRequestClassName = "com.appsamurai.ads.common.AdRequest";

        public const string AdRequestBuilderClassName = "com.appsamurai.ads.common.AdRequest$Builder";

        public const string AdSizeClassName = "com.appsamurai.ads.common.AdSize";

        public const string MobileAdsClassName = "com.appsamurai.ads.common.MobileAds";

        #endregion

        #region AppSamurai Mobile Ads Unity Plugin class names

        public const string BannerViewClassName = "com.appsamurai.unity.ads.Banner";

        public const string InterstitialClassName = "com.appsamurai.unity.ads.Interstitial";

        public const string RewardBasedVideoClassName = "com.appsamurai.unity.ads.RewardBasedVideo";

        public const string UnityAdListenerClassName = "com.appsamurai.unity.ads.UnityAdListener";

        public const string UnityRewardBasedVideoAdListenerClassName = "com.appsamurai.unity.ads.UnityRewardBasedVideoAdListener";

        #endregion

        #region Unity class names

        public const string UnityActivityClassName = "com.unity3d.player.UnityPlayer";

        #endregion

        #region Android SDK class names

        public const string BundleClassName = "android.os.Bundle";
        public const string DateClassName = "java.util.Date";

        #endregion

        #endregion

        #region JavaObject creators

        public static AndroidJavaObject GetAdSizeJavaObject(AdSize adSize)
        {
            if (adSize.IsSmartBanner)
            {
                return new AndroidJavaClass(AdSizeClassName)
                        .GetStatic<AndroidJavaObject>("SMART_BANNER");
            }
            else
            {
                return new AndroidJavaObject(AdSizeClassName, adSize.Width, adSize.Height);
            }
        }

        public static AndroidJavaObject GetAdRequestJavaObject(AdRequest request)
        {
            AndroidJavaObject adRequestBuilder = new AndroidJavaObject(AdRequestBuilderClassName);
            // Denote that the request is coming from this Unity plugin.
            adRequestBuilder.Call<AndroidJavaObject>(
                    "setRequestAgent",
                    "unity-beta");
            AndroidJavaObject bundle = new AndroidJavaObject(BundleClassName);
            bundle.Call("putString", "is_unity", "1");

            return adRequestBuilder.Call<AndroidJavaObject>("build");
        }
        #endregion
    }
}
