using System;

using AppSamuraiAds.Api;
using AppSamuraiAds.Common;
using UnityEngine;

namespace AppSamuraiAds.Android
{
    public class RewardBasedVideoAdClient : AndroidJavaProxy, IRewardBasedVideoAdClient
    {
        private AndroidJavaObject androidRewardBasedVideo;

        public event EventHandler<EventArgs> OnAdLoaded = delegate { };
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad = delegate { };
        public event EventHandler<EventArgs> OnAdOpening = delegate { };
        public event EventHandler<EventArgs> OnAdStarted = delegate { };
        public event EventHandler<EventArgs> OnAdClosed = delegate { };
        public event EventHandler<EventArgs> OnAdRewarded = delegate { };
        public event EventHandler<EventArgs> OnAdLeavingApplication = delegate { };
        public event EventHandler<EventArgs> OnAdCompleted = delegate { };

        public RewardBasedVideoAdClient(): base(Utils.UnityRewardBasedVideoAdListenerClassName)
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            androidRewardBasedVideo = new AndroidJavaObject(Utils.RewardBasedVideoClassName, activity, this);
        }

        public void CreateRewardBasedVideoAd(string adUnitId)
        {
            androidRewardBasedVideo.Call("create", adUnitId);
        }

        public void LoadAd(AdRequest request, string adUnitId)
        {
            androidRewardBasedVideo.Call("loadAd", Utils.GetAdRequestJavaObject(request), adUnitId);
        }

        public void LoadAd(string adUnitId)
        {
            androidRewardBasedVideo.Call("loadAd", adUnitId);
        }

        public void LoadAd()
        {
            androidRewardBasedVideo.Call("loadAd");
        }

        public bool IsLoaded()
        {
            return androidRewardBasedVideo.Call<bool>("isLoaded");
        }

        public void ShowRewardBasedVideoAd()
        {
            androidRewardBasedVideo.Call("show");
        }

        public void DestroyRewardBasedVideoAd()
        {
            androidRewardBasedVideo.Call("destroy");
        }

        void onAdLoaded()
        {
            if (this.OnAdLoaded != null)
            {
                this.OnAdLoaded(this, EventArgs.Empty);
            }
        }

        void onAdFailedToLoad(string errorReason)
        {
            if (this.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorReason
                };
                this.OnAdFailedToLoad(this, args);
            }
        }

        void onAdOpened()
        {
            if (this.OnAdOpening != null)
            {
                this.OnAdOpening(this, EventArgs.Empty);
            }
        }

        void onAdStarted()
        {
            if (this.OnAdStarted != null)
            {
                this.OnAdStarted(this, EventArgs.Empty);
            }
        }

        void onAdClosed()
        {
            if (this.OnAdClosed != null)
            {
                this.OnAdClosed(this, EventArgs.Empty);
            }
        }

        void onAdRewarded()
        {
            if (this.OnAdRewarded != null)
            {
                this.OnAdRewarded(this, EventArgs.Empty);
            }
        }

        void onAdLeftApplication()
        {
            if (this.OnAdLeavingApplication != null)
            {
                this.OnAdLeavingApplication(this, EventArgs.Empty);
            }
        }

        void onAdCompleted()
        {
            if (this.OnAdCompleted != null)
            {
                this.OnAdCompleted(this, EventArgs.Empty);
            }
        }
    }
}
