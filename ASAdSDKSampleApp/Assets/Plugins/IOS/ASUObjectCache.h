#import <Foundation/Foundation.h>

@interface ASUObjectCache : NSObject

+(instancetype)sharedInstance;

@property(nonatomic, strong) NSMutableDictionary *references;

@end

@interface NSObject (ASUOwnershipAdditions)

- (NSString *)asu_referenceKey;

@end
