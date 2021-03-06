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
    //セッション作成
    AVCaptureSession * captureSession = [[AVCaptureSession alloc]init];
    captureSession.sessionPreset = AVCaptureSessionPresetHigh;

    NSError *error=nil;
    AVCaptureDevice * captureDevice;
    captureDevice = [AVCaptureDevice defaultDeviceWithMediaType:AVMediaTypeVideo];
    AVCaptureDeviceInput *input;
    input = [AVCaptureDeviceInput deviceInputWithDevice:captureDevice error:&error];
    [captureSession addInput:input];

    UIWindow *win = [[UIApplication sharedApplication] keyWindow];

    //カメラ映像を表示するCALayer設定
    AVCaptureVideoPreviewLayer * previewLayer;
    previewLayer = [AVCaptureVideoPreviewLayer layerWithSession:captureSession];
    previewLayer.videoGravity = AVLayerVideoGravityResizeAspectFill;
    previewLayer.frame = win.bounds;

    //カメラ映像を表示するCALayerを最背面に
    [win.layer insertSublayer:previewLayer atIndex:0];

    //カメラセッションスタート
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
    
    //何故か端末の画面回転でglLayer.opaqueがYESに切り替わってしまい暗転するため、ここで無理やりNOにする
    glLayer.opaque = NO;
}

//テスト用
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

    glLayer.opaque = NO;
}

