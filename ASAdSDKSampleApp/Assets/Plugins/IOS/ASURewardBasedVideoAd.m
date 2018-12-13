//
//  ASURewardBasedVideoAd.m
//  AppSamuraiAdSDKUnityBridge
//
//  Created by Levent ORAL on 25.09.2018.
//  Copyright © 2018 Levent ORAL. All rights reserved.
//

#import "ASURewardBasedVideoAd.h"
#import "ASUPluginUtil.h"

@implementation ASURewardBasedVideoAd

- (id)initWithReference:(ASURewardBasedVideoAdClientReference *)rewardBasedVideoAdClient {
    self = [super init];
    NSLog(@"%s", __FUNCTION__);
    if (self) {
        [[ASRewardBasedVideoAd instance] setDelegate:self];
        _rewardBasedVideoAdClient = rewardBasedVideoAdClient;
    }
    return self;
}

- (void)loadAdWithAdUnitId:(NSString *)adUnitID {
    NSLog(@"%s %s %@", __FUNCTION__, "AdUnitID is", adUnitID);
    [[ASRewardBasedVideoAd instance] loadAdWithAdUnitID:adUnitID adRequest:[[ASAdRequest alloc] init]];
}

- (void)showRewardBasedVideoAd {
    ASRewardBasedVideoAd *rewardBasedVideoAd = [ASRewardBasedVideoAd instance];
    if (rewardBasedVideoAd.isReady) {
        [rewardBasedVideoAd presentWithRootViewController:[ASUPluginUtil unityGLViewController]];
    }
}

- (BOOL)isReady {
    ASRewardBasedVideoAd *rewardBasedVideoAd = [ASRewardBasedVideoAd instance];
    return [rewardBasedVideoAd isReady];
}

#pragma ASRewardBasedVideoAdDelegate functions
- (void)rewardBasedVideoAdDidReceive:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.adReceivedCallback ? "" : "Callback function has not set"));
    if (self.adReceivedCallback) {
        self.adReceivedCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdDidFailToReceiveAd:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd error:(ASAdRequestError * _Nonnull)error {
    NSLog(@"%s %s", __FUNCTION__, (self.adFailedCallback ? "" : "Callback function has not set"));
    if (self.adFailedCallback){
        self.adFailedCallback(self.rewardBasedVideoAdClient, [error.localizedDescription UTF8String]);
    }
}

- (void)rewardBasedVideoAdDidOpen:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.didOpenCallback ? "" : "Callback function has not set"));
    if (self.didOpenCallback) {
        self.didOpenCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdDidClose:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.didCloseCallback ? "" : "Callback function has not set"));
    if (self.didCloseCallback) {
        self.didCloseCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdStartPlaying:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.didStartCallback ? "" : "Callback function has not set"));
    if (self.didStartCallback) {
        self.didStartCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdCompletePlaying:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.didCompleteCallback ? "" : "Callback function has not set"));
    if (self.didCompleteCallback) {
        self.didCompleteCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdDidReward:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.didRewardCallback ? "" : "Callback function has not set"));
    if (self.didRewardCallback) {
        self.didRewardCallback(self.rewardBasedVideoAdClient);
    }
}

- (void)rewardBasedVideoAdWillLeaveApplication:(ASRewardBasedVideoAd * _Nonnull)asRewardBasedAd {
    NSLog(@"%s %s", __FUNCTION__, (self.willLeaveCallback ? "" : "Callback function has not set"));
    if (self.willLeaveCallback) {
        self.willLeaveCallback(self.rewardBasedVideoAdClient);
    }
}
@end
