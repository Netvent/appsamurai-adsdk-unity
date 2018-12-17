using System;
using System.Reflection;

using AppSamuraiAds.Common;

namespace AppSamuraiAds.Api
{
    public class MobileAds
    {
        private static readonly IMobileAdsClient client = GetMobileAdsClient();

        public static void Initialize(string appId)
        {
            client.Initialize(appId);
        }

        private static IMobileAdsClient GetMobileAdsClient()
        {
            Type mobileAdsClientFactory = Type.GetType("AppSamuraiAds.MobileAdsClientFactory,Assembly-CSharp");
            MethodInfo method = mobileAdsClientFactory.GetMethod("MobileAdsInstance",BindingFlags.Static | BindingFlags.Public);
            return (IMobileAdsClient)method.Invoke(null, null);
        }
        public static String getSDKVersion()
        {
            return client.getSDKVersion();
        }
    }
}
