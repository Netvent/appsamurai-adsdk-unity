/// Base type representing an ASU* pointer.
typedef const void *ASUReference;

/// Type representing an ASUBannerView.
typedef const void *ASUBannerViewReference;

/// Type representing a Unity banner client.
typedef const void *ASUBannerClientReference;

typedef void (*ASUAdViewDidReceiveAdCallback)(ASUBannerClientReference *bannerClient);

typedef void (*ASUAdViewDidFailToReceiveAdWithErrorCallback)(ASUBannerClientReference *bannerClient, const char *errorMessage);

typedef void (*ASUAdViewWillLeaveApplicationCallback)(ASUBannerClientReference *bannerClient);

/// Type representing an ASUInterstitial.
typedef const void *ASUInterstitialReference;

/// Type representing a Unity interstitial client.
typedef const void *ASUInterstitialClientReference;

typedef void (*ASUInterstitialDidReceiveAdCallback)(ASUInterstitialReference *interstitialClient);

typedef void (*ASUInterstitialDidFailToReceiveAdWithErrorCallback)(ASUInterstitialReference *interstitialClient, const char *errorMessage);

typedef void (*ASUInterstitialWillPresentScreenCallback)(ASUInterstitialReference *interstitialClient);

typedef void (*ASUInterstitialDidDismissScreenCallback)(ASUInterstitialReference *interstitialClient);

typedef void (*ASUInterstitialWillLeaveApplicationCallback)(ASUInterstitialReference *interstitialClient);

/// Type representing an ASURewardBasedVideoAd.
typedef const void *ASURewardBasedVideoAdReference;

/// Type representing a Unity rewarded video ad client.
typedef const void *ASURewardBasedVideoAdClientReference;

typedef void (*ASURewardBasedVideoAdDidReceiveAdCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient, const char *errorMessage);

typedef void (*ASURewardBasedVideoAdDidOpenCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdDidCloseCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdDidStartPlayingCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdDidCompleteCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdDidRewardCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

typedef void (*ASURewardBasedVideoAdWillLeaveApplicationCallback)(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient);

/// Type representing an ASURewardBasedVideoAd.
typedef const void *ASUAdRequestReference;
