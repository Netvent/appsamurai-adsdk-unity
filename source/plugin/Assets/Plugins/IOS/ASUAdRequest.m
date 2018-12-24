#import "ASUAdRequest.h"

@implementation ASUAdRequest

- (id)init {
    self = [super init];
    if (self) {
        _testDevices = [[NSMutableArray alloc] init];
        _supportedFormats = [[NSMutableArray alloc] init];
    }
    return self;
}

- (void)addTestDevice:(NSString *)deviceID {
    [self.testDevices addObject:deviceID];
}

- (void)addSupportedFormat:(NSString *)format {
    if ([format isEqualToString:@"HTML"]) {
        [self.supportedFormats addObject:ASAdFormat.html];
    }
    else if ([format isEqualToString:@"VIDEO"]) {
        [self.supportedFormats addObject:ASAdFormat.video];
    }
    else if ([format isEqualToString:@"PLAYABLE"]) {
        [self.supportedFormats addObject:ASAdFormat.playable];
    }
}

- (ASAdRequest *)asAdRequest {
    ASAdRequest *asAdRequest = [[ASAdRequest alloc] init];
    asAdRequest.testDevices = self.testDevices;
    asAdRequest.supportedFormats = self.supportedFormats;
    return asAdRequest;
}

@end
