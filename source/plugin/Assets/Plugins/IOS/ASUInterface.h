#import "ASUReferences.h"

void ASURelease(ASUReference refence);

void ASUInitialize(const char* applicationId);

const char* ASUGetSDKVersion(void);

void ASUSetLogEnabled(BOOL logEnabled);

ASUBannerViewReference ASUCreateBannerView(ASUBannerClientReference *bannerClient,
                                           const char *adUnitID);

void ASUSetBannerCallbacks(ASUBannerViewReference banner,
                           ASUAdViewDidReceiveAdCallback adReceivedCallback,
                           ASUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
                           ASUAdViewWillLeaveApplicationCallback willLeaveCallback);

void ASULoadBannerAd(ASUBannerViewReference banner, ASUAdRequestReference adRequest);

void ASUHideBannerView(ASUBannerViewReference banner);

void ASUShowBannerView(ASUBannerViewReference banner);

void ASURemoveBannerView(ASUBannerViewReference banner);

ASUInterstitialReference ASUCreateInterstitial(ASUInterstitialClientReference *interstitialClient,
                                               const char *adUnitID);

void ASUSetInterstitialCallbacks(ASUInterstitialReference interstitial,
                                 ASUInterstitialDidReceiveAdCallback adReceivedCallback,
                                 ASUInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                 ASUInterstitialWillPresentScreenCallback willPresentCallback,
                                 ASUInterstitialDidDismissScreenCallback didDismissCallback,
                                 ASUInterstitialWillLeaveApplicationCallback willLeaveCallback);

void ASULoadInterstitial(ASUInterstitialReference interstitial, ASUAdRequestReference adRequest);

void ASUShowInterstitial(ASUInterstitialReference interstitial);

ASURewardBasedVideoAdReference ASUCreateRewardBasedVideoAd(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient,
                                                           const char *adUnitID);

void ASUSetRewardBasedVideoAdCallbacks(ASURewardBasedVideoAdReference rewardBasedVideoAd,
                                       ASURewardBasedVideoAdDidReceiveAdCallback adReceivedCallback,
                                       ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                       ASURewardBasedVideoAdDidOpenCallback didOpenCallback,
                                       ASURewardBasedVideoAdDidCloseCallback didCloseCallback,
                                       ASURewardBasedVideoAdDidStartPlayingCallback didStartCallback,
                                       ASURewardBasedVideoAdDidCompleteCallback didCompleteCallback,
                                       ASURewardBasedVideoAdDidRewardCallback didRewardCallback,
                                       ASURewardBasedVideoAdWillLeaveApplicationCallback willLeaveCallback);

void ASULoadRewardBasedVideoAd(ASURewardBasedVideoAdReference rewardBasedVideoAd, ASUAdRequestReference adRequest);

void ASUShowRewardBasedVideoAd(ASURewardBasedVideoAdReference rewardBasedVideoAd);

ASUAdRequestReference ASUCreateAdRequest(void);

void ASUAddTestDevice(ASUAdRequestReference adRequest,
                      const char *testDevice);

void ASUAddSupportedFormat(ASUAdRequestReference adRequest,
                           const char *supportedFormat);
