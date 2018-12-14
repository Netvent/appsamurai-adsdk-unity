#import <Foundation/Foundation.h>

// TODO: check AppSamuraiAdSDK/AppSamuraiAdSDK.h usage
#import "AppSamuraiAdSDK/AppSamuraiAdSDK-Swift.h"

#import "ASUReferences.h"

@interface ASUBannerView : NSObject <ASBannerViewDelegate>

- (id)initWithReference:(ASUBannerClientReference *)bannerClient
               adUnitID:(NSString *)adUnitID;

- (void)loadAd;

- (void)hideBannerView;

- (void)showBannerView;

- (void)removeBannerView;

@property(nonatomic, strong) ASBannerView *asBannerView;

@property(nonatomic, assign) ASUBannerClientReference *bannerClient;

@property(nonatomic, assign) ASUAdViewDidReceiveAdCallback adReceivedCallback;

@property(nonatomic, assign) ASUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback;

@property(nonatomic, assign) ASUAdViewWillLeaveApplicationCallback willLeaveCallback;

@end
