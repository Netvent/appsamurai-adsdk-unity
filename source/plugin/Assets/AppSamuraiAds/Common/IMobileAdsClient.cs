namespace AppSamuraiAds.Common
{
    public interface IMobileAdsClient
    {
        // Initialize the Mobile Ads SDK.
        void Initialize(string appId);

        string getSDKVersion();

        void setLogEnabled(bool logEnabled);
    }}
