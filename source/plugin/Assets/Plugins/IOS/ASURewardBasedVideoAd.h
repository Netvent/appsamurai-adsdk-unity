//
//  ASURewardBasedVideoAd.h
//  AppSamuraiAdSDKUnityBridge
//
//  Created by Levent ORAL on 25.09.2018.
//  Copyright © 2018 Levent ORAL. All rights reserved.
//

#import <Foundation/Foundation.h>

// TODO: check AppSamuraiAdSDK/AppSamuraiAdSDK.h usage
#import "AppSamuraiAdSDK/AppSamuraiAdSDK-Swift.h"

#import "ASUReferences.h"

@interface ASURewardBasedVideoAd : NSObject <ASRewardBasedVideoAdDelegate>

- (id)initWithReference:(ASURewardBasedVideoAdClientReference *)rewardBasedVideoAdClient;

- (void)loadAdWithAdUnitId:(NSString *)adUnitID;

- (void)showRewardBasedVideoAd;

- (BOOL)isReady;

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
