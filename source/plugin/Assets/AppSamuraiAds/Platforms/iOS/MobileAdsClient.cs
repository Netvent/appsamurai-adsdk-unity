﻿#if UNITY_IOS

using UnityEngine;

using AppSamuraiAds.Common;

namespace AppSamuraiAds.iOS
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
            Externs.ASUInitialize(appId);
        }

        public string getSDKVersion()
        {
            return Externs.ASUGetSDKVersion();
        }

        public void setLogEnabled(bool logEnabled)
        {
            Externs.ASUSetLogEnabled(logEnabled);
        }
    }
}

#endif
