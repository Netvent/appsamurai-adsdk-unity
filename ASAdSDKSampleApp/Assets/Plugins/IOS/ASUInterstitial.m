#import "ASUInterstitial.h"
#import "ASUPluginUtil.h"

@implementation ASUInterstitial

- (id)initWithReference:(ASUInterstitialClientReference *)interstitialClient
               adUnitID:(NSString *)adUnitID
{
    self = [super init];
    NSLog(@"%s %s %@", __FUNCTION__, "AdUnitID is", adUnitID);
    if (self)
    {
        _asInterstitial = [[ASInterstitial alloc] initWithAdUnitID:adUnitID];
        _asInterstitial.delegate = self;
        _interstitialClient = interstitialClient;
    }
    return self;
}

- (void)loadAd
{
    NSLog(@"%s", __FUNCTION__);
    [self.asInterstitial loadAdWithAdRequest:[[ASAdRequest alloc] init]];
}

- (void)showInterstitial
{
    NSLog(@"%s %s", __FUNCTION__, (self.asInterstitial.isReady ? "" : "Interstitial ad is not ready"));
    if (self.asInterstitial.isReady) {
        [self.asInterstitial presentWithRootViewController:[ASUPluginUtil unityGLViewController]];
    }
}

- (BOOL)isReady
{
    return self.asInterstitial.isReady;
}

#pragma ASInterstitialDelegate functions
- (void)interstitialDidReceiveAd:(ASInterstitial *_Nonnull)asInterstitial
{
    NSLog(@"%s %s", __FUNCTION__, (self.adReceivedCallback ? "" : "Callback function has not set"));
    if (self.adReceivedCallback)
    {
        self.adReceivedCallback(self.interstitialClient);
    }
}

- (void)interstitialDidFailToReceiveAd:(ASInterstitial *_Nonnull)asInterstitial error:(ASAdRequestError *_Nonnull)error
{
    NSLog(@"%s %s", __FUNCTION__, (self.adFailedCallback ? "" : "Callback function has not set"));
    if (self.adFailedCallback)
    {
        self.adFailedCallback(self.interstitialClient, [error.localizedDescription UTF8String]);
    }
}

- (void)interstitialWillPresentScreen:(ASInterstitial *_Nonnull)asInterstitial
{
    NSLog(@"%s %s", __FUNCTION__, (self.willPresentCallback ? "" : "Callback function has not set"));
    if (self.willPresentCallback)
    {
        self.willPresentCallback(self.interstitialClient);
    }
}

- (void)interstitialWillDismissScreen:(ASInterstitial *_Nonnull)asInterstitial
{
}

- (void)interstitialDidDismissScreen:(ASInterstitial *_Nonnull)asInterstitial
{
    NSLog(@"%s %s", __FUNCTION__, (self.didDismissCallback ? "" : "Callback function has not set"));
    if (self.didDismissCallback)
    {
        self.didDismissCallback(self.interstitialClient);
    }
}

- (void)interstitialWillLeaveApplication:(ASInterstitial *_Nonnull)asInterstitial
{
    NSLog(@"%s %s", __FUNCTION__, (self.willLeaveCallback ? "" : "Callback function has not set"));
    if (self.willLeaveCallback)
    {
        self.willLeaveCallback(self.interstitialClient);
    }
}
@end
