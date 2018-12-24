#import "ASUBannerView.h"
#import "ASUInterstitial.h"
#import "ASURewardBasedVideoAd.h"
#import "ASUAdRequest.h"
#import "ASUObjectCache.h"

void ASURelease(ASUReference refence) {
    NSLog(@"%s", __FUNCTION__);
    if (refence) {
        ASUObjectCache *cache = [ASUObjectCache sharedInstance];
        [cache.references removeObjectForKey:[(__bridge NSObject *)refence asu_referenceKey]];
    }
}

void ASUInitialize(const char* applicationId) {
    NSLog(@"%s %s %s", __FUNCTION__, "ApplicationId is", applicationId);
    [ASMobileAds initialize: [[NSString alloc] initWithUTF8String:applicationId]];
}

const char* ASUGetSDKVersion(void) {
    NSLog(@"%s", __FUNCTION__);
    return [[ASMobileAds getSDKVersion] UTF8String];
}

void ASUSetLogEnabled(BOOL logEnabled) {
    NSLog(@"%s %s", __FUNCTION__, (logEnabled ? "True" : "False"));
    if (logEnabled) {
        [ASMobileAds setLogLevelWithLogLevel:ASLogLevelDebug];
    } else {
        [ASMobileAds setLogLevelWithLogLevel:ASLogLevelOff];
    }
}

ASUBannerViewReference ASUCreateBannerView(ASUBannerClientReference *bannerClient,
                                           const char *adUnitID) {
    NSLog(@"%s %s %s", __FUNCTION__, "AdUnitID is", adUnitID);
    ASUBannerView *bannerView = [[ASUBannerView alloc] initWithReference:bannerClient adUnitID:[[NSString alloc] initWithUTF8String:adUnitID]];
    ASUObjectCache *cache = [ASUObjectCache sharedInstance];
    [cache.references setObject:bannerView forKey:[bannerView asu_referenceKey]];
    return (__bridge ASUBannerViewReference)bannerView;
}

void ASUSetBannerCallbacks(ASUBannerViewReference banner,
                           ASUAdViewDidReceiveAdCallback adReceivedCallback,
                           ASUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback,
                           ASUAdViewWillLeaveApplicationCallback willLeaveCallback) {
    NSLog(@"%s", __FUNCTION__);
    ASUBannerView *internalBanner = (__bridge ASUBannerView *)banner;
    internalBanner.adReceivedCallback = adReceivedCallback;
    internalBanner.adFailedCallback = adFailedCallback;
    internalBanner.willLeaveCallback = willLeaveCallback;
}

void ASULoadBannerAd(ASUBannerViewReference banner, ASUAdRequestReference adRequest) {
    NSLog(@"%s", __FUNCTION__);
    ASUBannerView *internalBanner = (__bridge ASUBannerView *)banner;
    ASUAdRequest *internalAdRequest = (__bridge ASUAdRequest *)adRequest;
    [internalBanner loadAdWithAdRequest:[internalAdRequest asAdRequest]];
}

void ASUHideBannerView(ASUBannerViewReference banner) {
    NSLog(@"%s", __FUNCTION__);
    ASUBannerView *internalBanner = (__bridge ASUBannerView *)banner;
    [internalBanner hideBannerView];
}

void ASUShowBannerView(ASUBannerViewReference banner) {
    NSLog(@"%s", __FUNCTION__);
    ASUBannerView *internalBanner = (__bridge ASUBannerView *)banner;
    [internalBanner showBannerView];
}

void ASURemoveBannerView(ASUBannerViewReference banner) {
    NSLog(@"%s", __FUNCTION__);
    ASUBannerView *internalBanner = (__bridge ASUBannerView *)banner;
    [internalBanner removeBannerView];
}

ASUInterstitialReference ASUCreateInterstitial(ASUInterstitialClientReference *interstitialClient,
                           const char *adUnitID) {
    NSLog(@"%s %s %s", __FUNCTION__, "AdUnitID is", adUnitID);
    ASUInterstitial *interstitial = [[ASUInterstitial alloc] initWithReference:interstitialClient adUnitID:[[NSString alloc] initWithUTF8String:adUnitID]];
    ASUObjectCache *cache = [ASUObjectCache sharedInstance];
    [cache.references setObject:interstitial forKey:[interstitial asu_referenceKey]];
    return (__bridge ASUInterstitialReference)interstitial;
}

void ASUSetInterstitialCallbacks(ASUInterstitialReference interstitial,
                                 ASUInterstitialDidReceiveAdCallback adReceivedCallback,
                                 ASUInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                 ASUInterstitialWillPresentScreenCallback willPresentCallback,
                                 ASUInterstitialDidDismissScreenCallback didDismissCallback,
                                 ASUInterstitialWillLeaveApplicationCallback willLeaveCallback) {
    NSLog(@"%s", __FUNCTION__);
    ASUInterstitial *internalInterstitial = (__bridge ASUInterstitial *)interstitial;
    internalInterstitial.adReceivedCallback = adReceivedCallback;
    internalInterstitial.adFailedCallback = adFailedCallback;
    internalInterstitial.willPresentCallback = willPresentCallback;
    internalInterstitial.didDismissCallback = didDismissCallback;
    internalInterstitial.willLeaveCallback = willLeaveCallback;
}

void ASULoadInterstitial(ASUInterstitialReference interstitial, ASUAdRequestReference adRequest){
    NSLog(@"%s", __FUNCTION__);
    ASUInterstitial *internalInterstitial = (__bridge ASUInterstitial *)interstitial;
    ASUAdRequest *internalAdRequest = (__bridge ASUAdRequest *)adRequest;
    [internalInterstitial loadAdWithAdRequest:[internalAdRequest asAdRequest]];
}

void ASUShowInterstitial(ASUInterstitialReference interstitial) {
    NSLog(@"%s", __FUNCTION__);
    ASUInterstitial *internalInterstitial = (__bridge ASUInterstitial *)interstitial;
    [internalInterstitial showInterstitial];
}

BOOL ASUInterstitialReady(ASUInterstitialReference interstitial) {
    NSLog(@"%s", __FUNCTION__);
    ASUInterstitial *internalInterstitial = (__bridge ASUInterstitial *)interstitial;
    return [internalInterstitial isReady];
}

ASURewardBasedVideoAdReference ASUCreateRewardBasedVideoAd(ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient,
                                                           const char *adUnitID) {
    NSLog(@"%s %s %s", __FUNCTION__, "AdUnitID is", adUnitID);
    ASURewardBasedVideoAd *rewardBasedVideoAd = [[ASURewardBasedVideoAd alloc] initWithReference:rewardBasedVideoAdClient
                                                                                        adUnitID:[[NSString alloc] initWithUTF8String:adUnitID]];
    ASUObjectCache *cache = [ASUObjectCache sharedInstance];
    [cache.references setObject:rewardBasedVideoAd forKey:[rewardBasedVideoAd asu_referenceKey]];
    return (__bridge ASURewardBasedVideoAdReference)rewardBasedVideoAd;
}

void ASUSetRewardBasedVideoAdCallbacks(ASURewardBasedVideoAdReference rewardBasedVideoAd,
                                    ASURewardBasedVideoAdDidReceiveAdCallback adReceivedCallback,
                                    ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback adFailedCallback,
                                    ASURewardBasedVideoAdDidOpenCallback didOpenCallback,
                                    ASURewardBasedVideoAdDidCloseCallback didCloseCallback,
                                    ASURewardBasedVideoAdDidStartPlayingCallback didStartCallback,
                                    ASURewardBasedVideoAdDidCompleteCallback didCompleteCallback,
                                    ASURewardBasedVideoAdDidRewardCallback didRewardCallback,
                                    ASURewardBasedVideoAdWillLeaveApplicationCallback willLeaveCallback) {
    NSLog(@"%s", __FUNCTION__);
    ASURewardBasedVideoAd *internalRewardBasedVideoAd =(__bridge ASURewardBasedVideoAd *)rewardBasedVideoAd;
    internalRewardBasedVideoAd.adReceivedCallback = adReceivedCallback;
    internalRewardBasedVideoAd.adFailedCallback = adFailedCallback;
    internalRewardBasedVideoAd.didOpenCallback = didOpenCallback;
    internalRewardBasedVideoAd.didCloseCallback = didCloseCallback;
    internalRewardBasedVideoAd.didStartCallback = didStartCallback;
    internalRewardBasedVideoAd.didCompleteCallback = didCompleteCallback;
    internalRewardBasedVideoAd.didRewardCallback = didRewardCallback;
    internalRewardBasedVideoAd.willLeaveCallback = willLeaveCallback;
}

void ASULoadRewardBasedVideoAd(ASURewardBasedVideoAdReference rewardBasedVideoAd, ASUAdRequestReference adRequest) {
    NSLog(@"%s", __FUNCTION__);
    ASURewardBasedVideoAd *internalRewardBasedVideoAd = (__bridge ASURewardBasedVideoAd *)rewardBasedVideoAd;
    ASUAdRequest *internalAdRequest = (__bridge ASUAdRequest *)adRequest;
    [internalRewardBasedVideoAd loadAdWithAdRequest:[internalAdRequest asAdRequest]];
}

void ASUShowRewardBasedVideoAd(ASURewardBasedVideoAdReference rewardBasedVideoAd) {
    NSLog(@"%s", __FUNCTION__);
    ASURewardBasedVideoAd *internalRewardBasedVideoAd =(__bridge ASURewardBasedVideoAd *)rewardBasedVideoAd;
    [internalRewardBasedVideoAd showRewardBasedVideoAd];
}

BOOL ASURewardBasedVideoAdReady(ASURewardBasedVideoAdReference rewardBasedVideoAd) {
    NSLog(@"%s", __FUNCTION__);
    ASURewardBasedVideoAd *internalRewardBasedVideoAd = (__bridge ASURewardBasedVideoAd *)rewardBasedVideoAd;
    return [internalRewardBasedVideoAd isReady];
}

ASUAdRequestReference ASUCreateAdRequest(void) {
    NSLog(@"%s", __FUNCTION__);
    ASUAdRequest *adRequest = [[ASUAdRequest alloc] init];
    ASUObjectCache *cache = [ASUObjectCache sharedInstance];
    [cache.references setObject:adRequest forKey:[adRequest asu_referenceKey]];
    return (__bridge ASUAdRequestReference)adRequest;
}

void ASUAddTestDevice(ASUAdRequestReference adRequest,
                      const char *testDevice) {
    NSLog(@"%s %s %s", __FUNCTION__, "TestDevice is", testDevice);
    ASUAdRequest *internalAdRequest = (__bridge ASUAdRequest *)adRequest;
    [internalAdRequest addTestDevice:[[NSString alloc] initWithUTF8String:testDevice]];
}

void ASUAddSupportedFormat(ASUAdRequestReference adRequest,
                           const char *supportedFormat) {
    NSLog(@"%s %s %s", __FUNCTION__, "SupportedFormat is", supportedFormat);
    ASUAdRequest *internalAdRequest = (__bridge ASUAdRequest *)adRequest;
    [internalAdRequest addTestDevice:[[NSString alloc] initWithUTF8String:supportedFormat]];
}
