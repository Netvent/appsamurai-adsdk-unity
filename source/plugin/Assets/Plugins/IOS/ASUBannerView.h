#import <Foundation/Foundation.h>

@import AppSamuraiAdSDK;

#import "ASUReferences.h"

@interface ASUBannerView : NSObject <ASBannerViewDelegate>

- (id)initWithReference:(ASUBannerClientReference *)bannerClient
               adUnitID:(NSString *)adUnitID;

- (void)loadAdWithAdRequest:(ASAdRequest *)adRequest;

- (void)hideBannerView;

- (void)showBannerView;

- (void)removeBannerView;

@property(nonatomic, strong) ASBannerView *asBannerView;

@property(nonatomic, assign) ASUBannerClientReference *bannerClient;

@property(nonatomic, assign) ASUAdViewDidReceiveAdCallback adReceivedCallback;

@property(nonatomic, assign) ASUAdViewDidFailToReceiveAdWithErrorCallback adFailedCallback;

@property(nonatomic, assign) ASUAdViewWillLeaveApplicationCallback willLeaveCallback;

@end
