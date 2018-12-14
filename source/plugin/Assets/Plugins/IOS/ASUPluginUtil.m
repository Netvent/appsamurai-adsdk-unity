#import "ASUPluginUtil.h"

// #import “UnityAppController.h”

@implementation ASUPluginUtil

+(UIViewController *)unityGLViewController {
    // return ((UnityAppController *)[UIApplication sharedApplication].delegate).rootViewController;
    return [[[UIApplication sharedApplication] delegate] window].rootViewController;
}

@end
