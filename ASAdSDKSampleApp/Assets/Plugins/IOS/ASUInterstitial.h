#import <Foundation/Foundation.h>

// TODO: check AppSamuraiAdSDK/AppSamuraiAdSDK.h usage
#import "AppSamuraiAdSDK/AppSamuraiAdSDK-Swift.h"

#import "ASUReferences.h"

@interface ASUInterstitial : NSObject <ASInterstitialDelegate>

- (id)initWithReference:(ASUInterstitialClientReference *)interstitialClient
               adUnitID:(NSString *)adUnitID;

- (void)loadAd;

- (void)showInterstitial;

- (BOOL)isReady;

@property(nonatomic, strong) ASInterstitial *asInterstitial;

@property(nonatomic, assign) ASUInterstitialClientReference *interstitialClient;

@property(nonatomic, assign) ASUInterstitialDidReceiveAdCallback adReceivedCallback;

@property(nonatomic, assign) ASUInterstitialDidFailToReceiveAdWithErrorCallback adFailedCallback;

@property(nonatomic, assign) ASUInterstitialWillPresentScreenCallback willPresentCallback;

@property(nonatomic, assign) ASUInterstitialDidDismissScreenCallback didDismissCallback;

@property(nonatomic, assign) ASUInterstitialWillLeaveApplicationCallback willLeaveCallback;

@end
