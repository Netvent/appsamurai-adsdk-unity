#import <Foundation/Foundation.h>

@import AppSamuraiAdSDK;

#import "ASUReferences.h"

@interface ASUInterstitial : NSObject <ASInterstitialDelegate>

- (id)initWithReference:(ASUInterstitialClientReference *)interstitialClient
               adUnitID:(NSString *)adUnitID;

- (void)loadAdWithAdRequest:(ASAdRequest *)adRequest;

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
