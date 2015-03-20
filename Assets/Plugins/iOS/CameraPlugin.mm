#import "cameraPlugin.h"
#import <AVFoundation/AVFoundation.h>
#import <OpenGLES/EAGL.h>
#import <OpenGLES/ES2/gl.h>
#import <OpenGLES/ES2/glext.h>


extern "C" {
    void _startCamera();

    void _touchObject();
    
    void _checkQpaque();
}
void _startCamera() {
    AVCaptureSession * captureSession = [[AVCaptureSession alloc]init];
    captureSession.sessionPreset = AVCaptureSessionPresetHigh;

    NSError *error=nil;
    AVCaptureDevice * captureDevice;
    captureDevice = [AVCaptureDevice defaultDeviceWithMediaType:AVMediaTypeVideo];
    AVCaptureDeviceInput *input;
    input = [AVCaptureDeviceInput deviceInputWithDevice:captureDevice error:&error];
    [captureSession addInput:input];

    UIWindow *win = [[UIApplication sharedApplication] keyWindow];
    //UIWindow *win = [[UIApplication sharedApplication].windows objectAtIndex:0];

    AVCaptureVideoPreviewLayer * previewLayer;
    previewLayer = [AVCaptureVideoPreviewLayer layerWithSession:captureSession];
    previewLayer.videoGravity = AVLayerVideoGravityResizeAspectFill;
    previewLayer.frame = win.bounds;

    [win.layer insertSublayer:previewLayer atIndex:0];
    [captureSession startRunning];
	
    //EAGLLayerを透過
    NSArray *layers = win.layer.sublayers;
    CAEAGLLayer *glLayer=nil;
    for(int i=0;i<[layers count];i++){
        CALayer *layer = [layers objectAtIndex:i];
        if([layer isKindOfClass:[CAEAGLLayer class]]){
            glLayer = (CAEAGLLayer *)layer;
            NSLog(@"layer %d is GLlayer",i);
        }
    }
        
    //背景透過
    win.backgroundColor = [UIColor colorWithWhite:0.0f alpha:0.0f];
    glLayer.opaque = NO;
    glClearColor(0, 0, 0, 0);
    glLayer.drawableProperties = [NSDictionary dictionaryWithObjectsAndKeys:
                                    [NSNumber numberWithBool:FALSE],
                                    kEAGLDrawablePropertyRetainedBacking,
                                    kEAGLColorFormatRGBA8, kEAGLDrawablePropertyColorFormat,
                                    nil];
    
    EAGLContext * glContext = [EAGLContext currentContext];
    [glContext renderbufferStorage:GL_RENDERBUFFER fromDrawable:glLayer];
}

void _touchObject() {
	UIWindow *win = [[UIApplication sharedApplication] keyWindow];
	NSArray *layers = win.layer.sublayers;
    CAEAGLLayer *glLayer=nil;
    for(int i=0;i<[layers count];i++){
        CALayer *layer = [layers objectAtIndex:i];
        if([layer isKindOfClass:[CAEAGLLayer class]]){
            glLayer = (CAEAGLLayer *)layer;
        }
    }

	NSLog(@"qpaque=%hhd",glLayer.opaque);//ここで透過フラグとかのログを出す
    glLayer.opaque = NO;
}

void _checkQpaque() {
    UIWindow *win = [[UIApplication sharedApplication] keyWindow];
    NSArray *layers = win.layer.sublayers;
    CAEAGLLayer *glLayer=nil;
    for(int i=0;i<[layers count];i++){
        CALayer *layer = [layers objectAtIndex:i];
        if([layer isKindOfClass:[CAEAGLLayer class]]){
            glLayer = (CAEAGLLayer *)layer;
        }
    }
    
    NSLog(@"qpaque=%hhd",glLayer.opaque);//ここで透過フラグとかのログを出す
    glLayer.opaque = NO;
}