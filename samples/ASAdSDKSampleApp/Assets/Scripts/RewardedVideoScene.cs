using System;
using UnityEngine;

using AppSamuraiAds.Api;

public class RewardedVideoScene : MonoBehaviour {

    private RewardBasedVideoAd videoAd;

#if UNITY_ANDROID
    private string appId = "gJIwJ-T0Kst86Mw3JIk-1A";
    private string adUnitId = "nnrgOQwJmrRCuppxWA0Q_A";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string appId = "appsamurai-sample-ios-app-id";
    private string adUnitId = "appsamurai-sample-ios-rewardbasedvideo-ad-id";
#else
    private string appId = "unexpected_platform";
    private string adUnitId = "unexpected_platform";
#endif

    void Start()
    {
        Debug.Log("Initializing AppSamurai Ads SDK");
        // Initialize the AppSamurai Mobile Ads SDK with app id.
        MobileAds.Initialize(appId);
    }

    public void ReturnToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void CreateAd()
    {
        Debug.Log("Rewarded Video: Creating Ad");
        // Create an rewarded based video ad
        videoAd = new RewardBasedVideoAd(adUnitId);

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

    public void LoadAd()
    {
        if (videoAd != null)
        {
            Debug.Log("Rewarded Video: Loading Ad");
            // Send an ad request
            videoAd.LoadAd();
        }
        else
        {
            Debug.Log("First you should create an Ad Unit");
        }
    }

    public void ShowAd()
    {
        if (videoAd != null)
        {
            // Check whether the ad is loaded
            if (videoAd.IsLoaded())
            {
                Debug.Log("Rewarded Video: Showing Ad");
                // Start to show video ad
                videoAd.Show();
            }
            else
            {
                Debug.Log("Rewarded Video was not ready to be shown.");
            }
        }
        else
        {
            Debug.Log("First you should create an Ad Unit");
        }
    }

    public void HandleVideoAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Loaded");
    }

    public void HandleVideoAdRewarded(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Rewarded");
    }

    public void HandleVideoAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Closed");
    }

    public void HandleVideoAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Opening");
    }

    public void HandleVideoAdCompleted(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Completed");
    }

    public void HandleVideoAdStarted(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Started");
    }

    public void HandleVideoAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Rewarded Video: Ad Failed To Load " + args.Message);
    }

    public void HandleVideoAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("Rewarded Video: AdLeavingApplication");
    }
}
