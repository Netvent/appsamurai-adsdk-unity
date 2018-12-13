#if UNITY_IOS

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using AppSamuraiAds.Api;
using AppSamuraiAds.Common;

using AOT;

namespace AppSamuraiAds.iOS
{
    public class RewardBasedVideoAdClient : IRewardBasedVideoAdClient, IDisposable
    {
        private IntPtr rewardBasedVideoAdPtr;
        private IntPtr rewardBasedVideoAdClientPtr;

#region  RewardBasedVideoAd callback types
        internal delegate void ASURewardBasedVideoAdDidReceiveAdCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback(IntPtr rewardBasedVideoAdClient, string errorMessage);
        internal delegate void ASURewardBasedVideoAdDidPresentScreenCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdDidDismissScreenCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdDidVideoStartedCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdDidVideoCompletedCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdDidRewardReceivedCallback(IntPtr rewardBasedVideoAdClient);
        internal delegate void ASURewardBasedVideoAdWillLeaveApplicationCallback(IntPtr rewardBasedVideoAdClient);
#endregion

        public event EventHandler<EventArgs> OnAdLoaded;
        public event EventHandler<AdFailedToLoadEventArgs> OnAdFailedToLoad;
        public event EventHandler<EventArgs> OnAdOpening;
        public event EventHandler<EventArgs> OnAdStarted;
        public event EventHandler<EventArgs> OnAdRewarded;
        public event EventHandler<EventArgs> OnAdClosed;
        public event EventHandler<EventArgs> OnAdLeavingApplication;
        public event EventHandler<EventArgs> OnAdCompleted;

        private IntPtr RewardBasedVideoAdPtr
        {
            get { return this.rewardBasedVideoAdPtr; }

            set
            {
                Externs.ASURelease(this.rewardBasedVideoAdPtr);
                this.rewardBasedVideoAdPtr = value;
            }
        }

        public void CreateRewardBasedVideoAd()
        {
            this.rewardBasedVideoAdClientPtr = (IntPtr)GCHandle.Alloc(this);
            this.RewardBasedVideoAdPtr = Externs.ASUCreateRewardBasedVideoAd(this.rewardBasedVideoAdClientPtr);

            Externs.ASUSetRewardBasedVideoAdCallbacks(
                this.RewardBasedVideoAdPtr,
                RewardBasedVideoAdDidReceiveAdCallback,
                RewardBasedVideoAdDidFailToReceiveAdWithErrorCallback,
                RewardBasedVideoAdDidOpenCallback,
                RewardBasedVideoAdDidCloseCallback,
                RewardBasedVideoAdDidStartCallback,
                RewardBasedVideoAdDidCompleteCallback,
                RewardBasedVideoAdDidRewardUserCallback,
                RewardBasedVideoAdWillLeaveApplicationCallback);
        }

        public bool IsLoaded()
        {
            return Externs.ASURewardBasedVideoAdReady(this.RewardBasedVideoAdPtr);
        }

        public void LoadAd(AdRequest request, string adUnitId)
        {
            Externs.ASURequestRewardBasedVideoAd(this.RewardBasedVideoAdPtr, adUnitId);
        }

        public void LoadAd(string adUnitId)
        {
            Externs.ASURequestRewardBasedVideoAd(this.RewardBasedVideoAdPtr, adUnitId);
        }

        public void SetUserId(string userId)
        {
        }

        public void ShowRewardBasedVideoAd()
        {
            Externs.ASUShowRewardBasedVideoAd(this.RewardBasedVideoAdPtr);
        }

        private void DestroyRewardBasedVideoAd()
        {
            this.RewardBasedVideoAdPtr = IntPtr.Zero;
        }

        public void Dispose()
        {
            this.DestroyRewardBasedVideoAd();
            ((GCHandle)this.rewardBasedVideoAdClientPtr).Free();
        }

        ~RewardBasedVideoAdClient()
        {
            this.Dispose();
        }

#region  RewardBasedVideoAd callback methods
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidReceiveAdCallback))]
        private static void RewardBasedVideoAdDidReceiveAdCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdLoaded != null)
            {
                client.OnAdLoaded(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback))]
        private static void RewardBasedVideoAdDidFailToReceiveAdWithErrorCallback(IntPtr rewardBasedVideoAdClient, string errorMessage)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdFailedToLoad != null)
            {
                AdFailedToLoadEventArgs args = new AdFailedToLoadEventArgs()
                {
                    Message = errorMessage
                };
                client.OnAdFailedToLoad(client, args);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidPresentScreenCallback))]
        private static void RewardBasedVideoAdDidOpenCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdOpening != null)
            {
                client.OnAdOpening(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidDismissScreenCallback))]
        private static void RewardBasedVideoAdDidCloseCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdClosed != null)
            {
                client.OnAdClosed(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidVideoStartedCallback))]
        private static void RewardBasedVideoAdDidStartCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdStarted != null)
            {
                client.OnAdStarted(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidVideoCompletedCallback))]
        private static void RewardBasedVideoAdDidCompleteCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdCompleted != null)
            {
                client.OnAdCompleted(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdDidRewardReceivedCallback))]
        private static void RewardBasedVideoAdDidRewardUserCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdRewarded != null)
            {
                client.OnAdRewarded(client, EventArgs.Empty);
            }
        }
        [MonoPInvokeCallback(typeof(ASURewardBasedVideoAdWillLeaveApplicationCallback))]
        private static void RewardBasedVideoAdWillLeaveApplicationCallback(IntPtr rewardBasedVideoAdClient)
        {
            RewardBasedVideoAdClient client = IntPtrToRewardBasedVideoAdClient(rewardBasedVideoAdClient);
            if (client.OnAdLeavingApplication != null)
            {
                client.OnAdLeavingApplication(client, EventArgs.Empty);
            }
        }
        private static RewardBasedVideoAdClient IntPtrToRewardBasedVideoAdClient(IntPtr rewardBasedVideoAdClient)
        {
            GCHandle handle = (GCHandle)rewardBasedVideoAdClient;
            return handle.Target as RewardBasedVideoAdClient;
        }
#endregion
    }
}

#endif
