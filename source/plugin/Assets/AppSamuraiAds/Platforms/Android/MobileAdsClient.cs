#if UNITY_ANDROID

using UnityEngine;

using AppSamuraiAds.Common;

namespace AppSamuraiAds.Android
{
    public class MobileAdsClient : IMobileAdsClient
    {
        private static MobileAdsClient instance = new MobileAdsClient();

        private MobileAdsClient() { }

        public static MobileAdsClient Instance
        {
            get
            {
                return instance;
            }
        }

        public void Initialize(string appId)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity =playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            AndroidJavaClass mobileAdsClass = new AndroidJavaClass(Utils.MobileAdsClassName);
            mobileAdsClass.CallStatic("initialize", activity, appId);
        }

        public void SetApplicationVolume(float volume)
        {
            AndroidJavaClass mobileAdsClass = new AndroidJavaClass(Utils.MobileAdsClassName);
            mobileAdsClass.CallStatic("setAppVolume", volume);
        }

        public void SetApplicationMuted(bool muted)
        {
            AndroidJavaClass mobileAdsClass = new AndroidJavaClass(Utils.MobileAdsClassName);
            mobileAdsClass.CallStatic("setAppMuted", muted);
        }

        public void SetiOSAppPauseOnBackground(bool pause)
        {
            // Do nothing on Android. Default behavior is to pause when app is backgrounded.
        }
    }
}

#endif
