#import <Foundation/Foundation.h>

@import AppSamuraiAdSDK;

#import "ASUReferences.h"

@interface ASURewardBasedVideoAd : NSObject<ASRewardBasedVideoAdDelegate>

- (id)initWithReference:(ASURewardBasedVideoAdClientReference *)rewardBasedVideoAdClient
               adUnitID:(NSString *)adUnitID;

- (void)loadAdWithAdRequest:(ASAdRequest *)adRequest;

- (void)showRewardBasedVideoAd;

- (BOOL)isReady;

@property(nonatomic, strong) ASRewardBasedVideoAd *asRewardBasedVideoAd;

@property(nonatomic, assign) ASURewardBasedVideoAdClientReference *rewardBasedVideoAdClient;

@property(nonatomic, assign) ASURewardBasedVideoAdDidReceiveAdCallback adReceivedCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidFailToReceiveAdWithErrorCallback adFailedCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidOpenCallback didOpenCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidCloseCallback didCloseCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidStartPlayingCallback didStartCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidCompleteCallback didCompleteCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdDidRewardCallback didRewardCallback;

@property(nonatomic, assign) ASURewardBasedVideoAdWillLeaveApplicationCallback willLeaveCallback;

@end
