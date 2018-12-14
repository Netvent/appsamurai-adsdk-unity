#import "ASUBannerView.h"
#import "ASUPluginUtil.h"

@implementation ASUBannerView

-(id)initWithReference:(ASUBannerClientReference *)bannerClient
              adUnitID:(NSString *)adUnitID {
    self = [super init];
    NSLog(@"%s %s %@", __FUNCTION__, "AdUnitID is", adUnitID);
    if (self) {
        _asBannerView = [[ASBannerView alloc] initWithAdSize: ASAdSize.asAdSizeBanner];
        _asBannerView.adUnitID = adUnitID;
        _asBannerView.rootViewController = [ASUPluginUtil unityGLViewController];
        _asBannerView.delegate = self;
        _bannerClient = bannerClient;
    }
    return self;
}

-(void)loadAd {
    NSLog(@"%s", __FUNCTION__);
    [self.asBannerView loadAdWithAdRequest:[[ASAdRequest alloc] init]];
}

-(void)hideBannerView {
    NSLog(@"%s %s", __FUNCTION__, (self.asBannerView ? "" : "ASBannerView has not created"));
    if (!self.asBannerView) {
        return;
    }
    self.asBannerView.hidden = YES;
}

-(void)showBannerView {
    NSLog(@"%s %s", __FUNCTION__, (self.asBannerView ? "" : "ASBannerView has not created"));
    if (!self.asBannerView) {
        return;
    }
    self.asBannerView.hidden = NO;
}

-(void)removeBannerView {
    NSLog(@"%s %s", __FUNCTION__, (self.asBannerView ? "" : "ASBannerView has not created"));
    if (!self.asBannerView) {
        return;
    }
    [self.asBannerView removeFromSuperview];
}

-(void)addBannerView {
    UIView *unityView = [ASUPluginUtil unityGLViewController].view;
    [unityView addSubview:self.asBannerView];

    [self.asBannerView.centerXAnchor constraintEqualToAnchor:unityView.centerXAnchor].active = YES;
    [self.asBannerView.bottomAnchor constraintEqualToAnchor:unityView.bottomAnchor constant:0].active = YES;
}

- (void)adViewDidReceiveAd:(ASBannerView * _Nonnull)asBannerView {
    NSLog(@"%s %s", __FUNCTION__, (self.adReceivedCallback ? "" : "Callback function has not set"));
    [self removeBannerView];

    self.asBannerView = asBannerView;

    [self addBannerView];
    if (self.adReceivedCallback) {
        self.adReceivedCallback(self.bannerClient);
    }
}

- (void)adViewDidFailToReceiveAd:(ASBannerView * _Nonnull)asBannerView error:(ASAdRequestError * _Nonnull)error {
    NSLog(@"%s %s", __FUNCTION__, (self.adFailedCallback ? "" : "Callback function has not set"));
    if (self.adFailedCallback){
        self.adFailedCallback(self.bannerClient, [error.localizedDescription UTF8String]);
    }
}

- (void)adViewWillLeaveApplication:(ASBannerView * _Nonnull)asBannerView {
    NSLog(@"%s %s", __FUNCTION__, (self.willLeaveCallback ? "" : "Callback function has not set"));
    if (self.willLeaveCallback){
        self.willLeaveCallback(self.bannerClient);
    }
}

@end
