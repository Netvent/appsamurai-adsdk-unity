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

        public string getSDKVersion()
        {
            AndroidJavaClass mobileAdsClass = new AndroidJavaClass(Utils.MobileAdsClassName);
            return mobileAdsClass.CallStatic<string>("getSDKVersion");
        }

        public void setLogEnabled(bool logEnabled)
        {
            AndroidJavaClass mobileAdsClass = new AndroidJavaClass(Utils.MobileAdsClassName);
            mobileAdsClass.CallStatic("setLogEnabled", logEnabled);
        }
    }
}

#endif
