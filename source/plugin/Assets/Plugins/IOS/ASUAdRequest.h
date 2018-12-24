#import <Foundation/Foundation.h>

@import AppSamuraiAdSDK;

NS_ASSUME_NONNULL_BEGIN

@interface ASUAdRequest : NSObject

- (id)init;

- (void)addTestDevice:(NSString *)deviceID;

- (void)addSupportedFormat:(NSString *)format;

- (ASAdRequest *)asAdRequest;

@property(nonatomic, strong) NSMutableArray *testDevices;

@property(nonatomic, strong) NSMutableArray *supportedFormats;

@end

NS_ASSUME_NONNULL_END
