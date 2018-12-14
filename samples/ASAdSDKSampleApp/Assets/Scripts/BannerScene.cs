using System;
using UnityEngine;

using AppSamuraiAds.Api;

public class BannerScene : MonoBehaviour {

    private BannerView bannerView;

#if UNITY_ANDROID
    private string appId = "gJIwJ-T0Kst86Mw3JIk-1A";
    private string adUnitId = "nnrgOQ4JmLRCuphTYTkRvg";
#elif (UNITY_5 && UNITY_IOS) || UNITY_IPHONE
    private string appId = "gJUwJuTuP-t1wsM1DolK_A";
    private string adUnitId = "nn3gP0JF1PkMm593dmIB5Q";
#else
    private string appId = "unexpected_platform";
    private string adUnitId = "unexpected_platform";
#endif

    void Start () {
        Debug.Log("Initializing AppSamurai Ads SDK");
        // Initialize the AppSamurai Mobile Ads SDK with app id.
        MobileAds.Initialize(appId);
    }

    void OnDestroy()
    {
        if (bannerView != null)
        {
            Debug.Log("Destroying banner view");
            // Destroy banner view when you are with it
            bannerView.Destroy();
        }
    }

    public void ReturnToMainMenu () {
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainScene");
    }

    public void CreateAd () {
        Debug.Log("Banner: Creating Ad");

        // Clean up banner ad before creating a new one.
        if (bannerView != null)
        {
            Debug.Log("Destroying banner view");
            bannerView.Destroy();
        }

        // Create an banner view
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.BottomCenter);

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

    private AdRequest CreateAdRequest()
    {
        return new AdRequest.Builder()
            .AddTestDevice("YXBwc20tNzliNDU5YzVlZWM3NzA4Zg==")
            .Build();
    }

    public void LoadAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Banner: Loading Ad");
            // Send an ad request
            // Banner will be shown automatically when the ad is loaded
            bannerView.LoadAd(CreateAdRequest());
        }
        else
        {
            Debug.Log("First you should create a banner view");
        }
    }

    public void ShowAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Banner: Showing Ad");
            bannerView.Show();
        }
        else
        {
            Debug.Log("First you should create a banner view");
        }
    }

    public void HideAd()
    {
        if (bannerView != null)
        {
            Debug.Log("Banner: Hiding Ad");
            bannerView.Hide();
        }
        else
        {
            Debug.Log("First you should create a banner view");
        }
    }

    void HandleAdLoaded(object sender, EventArgs args)
    {
        Debug.Log("Banner: Ad Loaded");
    }

    void HandleAdOpening(object sender, EventArgs args)
    {
        Debug.Log("Banner: Ad Opening");
    }

    void HandleAdClosed(object sender, EventArgs args)
    {
        Debug.Log("Banner: Ad Closed");
    }

    void HandleAdLeavingApplication(object sender, EventArgs args)
    {
        Debug.Log("Banner: Ad Leaving Application");
    }

    void HandleAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        Debug.Log("Banner: Ad Failed To Load " + args.Message);
    }
}
