# App Samurai Ads Unity Plugin

[![alt text](https://appsamurai.com/wp-content/uploads/2018/10/as_dark_logotype-8.png "AppSamurai")](https://www.appsamurai.com)

# Easy And Effective App Monetization

The App Samurai Ads Unity plugin enables Unity developers to easily serve App Samurai Ads on Android and iOS apps without having to write Java or Objective-C (and/or Swift) code. The plugin provides a C# interface for requesting ads that is used by C# scripts in your Unity project. 

## Sample Projects
Check **samples** directory for sample projects. 

## Download
Please check out our **[releases](//github.com/Netvent/appsamurai-adsdk-unity/releases)** for the latest official version of the plugin.

### Import the Mobile Ads Unity plugin
Open your project in the Unity editor. Select **Assets > Import Package > Custom Package** and find the AppSamuraiAdsPlugin.unitypackage file you downloaded.

[![alt text](https://i.ibb.co/dJCbQDP/importing-package-1.png "AppSamurai")](https://www.appsamurai.com)

Make sure all of the files are selected and click **Import**.

[![alt text](https://i.ibb.co/SrpLHT6/importing-package-2.png "AppSamurai")](https://www.appsamurai.com)

Make sure all of the releated files imported.

[![alt text](https://i.ibb.co/cT8zSrn/assets.png "AppSamurai")](https://www.appsamurai.com)

## Initialization
### SDK Initialization
```csharp
...
using AppSamuraiAds.Api;
...
public class AppSamuraiAdsDemoScript : MonoBehaviour
{
    public void Start()
    {
        #if UNITY_ANDROID
            private string appId = "gJIwJ-T0Kst86Mw3JIk-1A";
        #elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
            private string appId = "gJUwJuTuP-t1wsM1DolK_A";
        #else
            private string appId = "unexpected_platform";
        #endif
        // Initialize the AppSamurai Mobile Ads SDK with app id.
        MobileAds.Initialize(appId);
    }
}
```

## Adding test devices
If you want to test your SDK integration without using live app id and ad unit ids, you can add your device as test device.

To see your device ID check the logcat output for a message that looks like this
```
D/AppSamurai: Use AdRequest.Builder.addTestDevice("YXBwc20tEzGiNDU5YzVlZWM3NzA4Zg==") to get test ads on this device.
```

Modify your code to call AdRequest.Builder.addTestDevice() with your test device ID. This method can be called multiple times for multiple devices.
```csharp
private AdRequest CreateAdRequest()
{
    return new AdRequest.Builder()
        .AddTestDevice("YXBwc20tNzliNDU5YzVlZWM3NzA4Zg==")
        .Build();
}
```

If you properly set your device as test device, at logcat you will seee a message that looks like this
```
D/AppSamurai: This request will be sent from a test device.
```

***Note*** : Android emulators are automatically configured as test devices.

## Banner Integration
### Create a BannerView
```csharp
...
using AppSamuraiAds.Api;
...
public class AppSamuraiAdsDemoScript : MonoBehaviour
{
    private BannerView bannerView;

#if UNITY_ANDROID
    private string adUnitId = "nnrgOQ4JmLRCuphTYTkRvg";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string adUnitId = "nn3gP0JF1PkMm593dmIB5Q";
#else
    private string adUnitId = "unexpected_platform";
#endif
    
    public void CreateAd () {
        // Create an banner view
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomCenter);
        ...
    }
}
```
### Load an ad
```csharp
private AdRequest CreateAdRequest()
{
    return new AdRequest.Builder().Build();
}

public void LoadAd()
{
    if (bannerView != null)
    {
        // Send an ad request
        // Banner will be shown automatically when the ad is loaded
        bannerView.LoadAd(CreateAdRequest());
    }
}
```
### Ad events
```csharp
public void CreateAd () {
    ...
    // Called when an ad request has successfully loaded.
    bannerView.OnAdLoaded += HandleAdLoaded;
    // Called when an ad request failed to load.
    bannerView.OnAdFailedToLoad += HandleAdFailedToLoad;
    // Called when an ad is opening.
    bannerView.OnAdOpening += HandleAdOpening;
    // Called when the user returned to the app after opening an ad.
    bannerView.OnAdClosed += HandleAdClosed;
    // Called when the ad click caused the user to leave the application.
    bannerView.OnAdLeavingApplication += HandleAdLeavingApplication;
}
```

#### Supported Banner Sizes
So far the only supported banner size is 320 x 50. 

### Interstitial Integration
#### Create an interstitial ad
```csharp
...
using AppSamuraiAds.Api;
...
public class AppSamuraiAdsDemoScript : MonoBehaviour
{
    private InterstitialAd interstitial;

#if UNITY_ANDROID
    private string adUnitId = "nnrgOQ8JmbRCupYRQyNQwg";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string adUnitId = "nn3gMEJE1PkMnJQKXxkL7Q";
#else
    private string adUnitId = "unexpected_platform";
#endif

    public void CreateAd () {
        // Create an interstitial
        interstitial = new InterstitialAd(adUnitId);
        ...
    }
}
```
#### Load an ad
```csharp
private AdRequest CreateAdRequest()
{
    return new AdRequest.Builder().Build();
}

public void LoadAd()
{
    if (interstitial != null)
    {
        // Send an ad request
        interstitial.LoadAd(CreateAdRequest());
    }
}
```
#### Show the ad
```csharp
public void ShowAd()
{
    if (interstitial != null)
    {
        // Check whether the ad is loaded
        if (interstitial.IsLoaded())
        {
            // Start to show interstitial ad
            interstitial.Show();
        }
    }
}
```
#### Ad events
```csharp
public void CreateAd () {
    ...
    // Called when an ad request has successfully loaded.
    interstitial.OnAdLoaded += HandleInterstitialLoaded;
    // Called when an ad request failed to load.
    interstitial.OnAdFailedToLoad += HandleInterstitialFailedToLoad;
    // Called when an ad is opening.
    interstitial.OnAdOpening += HandleInterstitialOpening;
    // Called when the user returned to the app after opening an ad.
    interstitial.OnAdClosed += HandleInterstitialClosed;
    // Called when the ad click caused the user to leave the application.
    interstitial.OnAdLeavingApplication += HandleInterstitialAdLeavingApplication;
}
```

#### Supported Media Formats
Interstial ad type supports both HTML and video ad formats. But AdListener methods are identical for both HTML and video. If you just want to show some of the ad formats you can specify while creating AdRequest.
```csharp
private AdRequest CreateAdRequest()
{
    return new AdRequest.Builder()
        .AddAdFormat(AdFormat.HTML)
        .AddAdFormat(AdFormat.VIDEO)
        .AddAdFormat(AdFormat.PLAYABLE)
        .Build();
}
```

### Rewarded Video Integration
#### Create an rewarded video ad
```csharp
...
using AppSamuraiAds.Api;
...
public class AppSamuraiAdsDemoScript : MonoBehaviour
{
    private RewardBasedVideoAd videoAd;

#if UNITY_ANDROID
    private string adUnitId = "nnrgOQwJmrRCuppxWA0Q_A";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string adUnitId = "nn3gMUJH1PkMnqQJcAxStg";
#else
    private string adUnitId = "unexpected_platform";
#endif

    public void CreateAd()
    {
        // Create an rewarded based video ad
        videoAd = new RewardBasedVideoAd(adUnitId);
        ...
    }
}
```
#### Load an ad
```csharp
public void LoadAd()
{
    if (videoAd != null)
    {
        // Send an ad request
        videoAd.LoadAd();
    }
}
```
#### Show the ad
```csharp
public void ShowAd()
{
    if (videoAd != null)
    {
        // Check whether the ad is loaded
        if (videoAd.IsLoaded())
        {
            // Start to show video ad
            videoAd.Show();
        }
    }
}
```
#### Ad events
```csharp
public void CreateAd()
{
    ...
    // Called when an ad request has successfully loaded.
    videoAd.OnAdLoaded += HandleVideoAdLoaded;
    // Called when an ad request failed to load.
    videoAd.OnAdFailedToLoad += HandleVideoAdFailedToLoad;
    // Called when a video is shown.
    videoAd.OnAdOpening += HandleVideoAdOpening;
    // Called when the video starts to play.
    videoAd.OnAdStarted += HandleVideoAdStarted;
    // Called when the user should be rewarded for watching the video.
    videoAd.OnAdRewarded += HandleVideoAdRewarded;
    // Called when the video is completed.
    videoAd.OnAdCompleted += HandleVideoAdCompleted;
    // Called when the ad click caused the user to leave the application.
    videoAd.OnAdLeavingApplication += HandleVideoAdLeavingApplication;
    // Called when the ad is closed.
    videoAd.OnAdClosed += HandleVideoAdClosed;
}
```


[![alt text](https://appsamurai.com/wp-content/uploads/2014/12/web_home_cta_2.png "AppSamurai")](https://www.appsamurai.com)
