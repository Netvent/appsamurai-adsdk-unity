#if UNITY_IOS

using System;

using AppSamuraiAds.Api;

namespace AppSamuraiAds.iOS
{
    public class AdRequestUtil
    {
        public static IntPtr BuildAdRequest()
        {
            return Externs.ASUCreateAdRequest();
        }

        public static IntPtr BuildAdRequest(AdRequest request)
        {
            IntPtr requestPtr = Externs.ASUCreateAdRequest();

            foreach (string testDevice in request.TestDevices)
            {
                Externs.ASUAddTestDevice(requestPtr, testDevice);
            }

            foreach (string supportedFormat in request.AdFormats)
            {
                Externs.ASUAddSupportedFormat(requestPtr, supportedFormat);
            }

            return requestPtr;
        }
    }
}

#endif
