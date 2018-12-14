namespace AppSamuraiAds.Common
{
    public interface IMobileAdsClient
    {
        // Initialize the Mobile Ads SDK.
        void Initialize(string appId);

        // The application’s audio volume. Affects audio volumes of all ads relative
        // to other audio output. Valid ad volume values range from 0.0 (silent) to 1.0
        // (current device volume). Use this method only if your application has its own
        // volume controls (e.g., custom music or sound effect volumes). Defaults to 1.0.
        void SetApplicationVolume(float volume);

        // Indicates if the application’s audio is muted. Affects initial mute state for
        // all ads. Use this method only if your application has its own volume controls
        // (e.g., custom music or sound effect muting). Defaults to false.
        void SetApplicationMuted(bool muted);

        // Set whether an iOS app should pause when a full screen ad is displayed.
        void SetiOSAppPauseOnBackground(bool pause);
    }}
