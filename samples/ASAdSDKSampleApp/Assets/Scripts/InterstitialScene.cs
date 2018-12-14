using System;
using UnityEngine;

using AppSamuraiAds.Api;

public class InterstitialScene : MonoBehaviour {

    private InterstitialAd interstitial;

#if UNITY_ANDROID
    private string appId = "gJIwJ-T0Kst86Mw3JIk-1A";
    private string adUnitId = "nnrgOQ8JmbRCupYRQyNQwg";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string appId = "gJUwJuTuP-t1wsM1DolK_A";
    private string adUnitId = "nn3gMEJE1PkMnJQKXxkL7Q";
#else
    private string appId = "unexpected_platform";
    private string adUnitId = "unexpected_platform";
#endif

    void Start () {
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
        Debug.Log("Interstitial: Creating Ad");
        // Create an interstitial
        interstitial = new InterstitialAd(adUnitId);

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

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice("YXBwc20tNzliNDU5YzVlZWM3NzA4Zg==")
            .AddAdFormat(AdFormat.HTML)
            .AddAdFormat(AdFormat.VIDEO)
            .AddAdFormat(AdFormat.PLAYABLE)
            .Build();
    }

    public void LoadAd()
    {
        if (interstitial != null)
        {
            Debug.Log("Interstitial: Loading Ad");
            // Send an ad request
            interstitial.LoadAd(CreateAdRequest());
        }
        else
        {
            Debug.Log("First you should create an Ad Unit");
        }
    }

    public void ShowAd()
    {
        if (interstitial != null)
        {
            // Check whether the ad is loaded
            if (interstitial.IsLoaded())
            {
                Debug.Log("Interstitial: Showing Ad");
                // Start to show interstitial ad
                interstitial.Show();
            }
            else
            {
                Debug.Log("Interstitial was not ready to be shown.");
            }
        }
        else
        {
            Debug.Log("First you should create an Ad Unit");
        }
    }

    public void HandleInterstitialLoaded(object sender, EventArgs args)
    {
        Debug.Log("Interstitial: Ad Loaded");
    }

    public void HandleInterstitialOpening(object sender, EventArgs args)
    {
        Debug.Log("Interstitial: Ad Opening");
    }

    public void HandleInterstitialClosed(object sender, EventArgs args)
    {
        Debug.Log("Interstitial: Ad Closed");
    }

    public void HandleInterstitialAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("Interstitial: Ad Leaving Application");
    }

    public void HandleInterstitialFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Interstitial: Ad Failed To Load " + args.Message);
    }
}
