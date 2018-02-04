//
//  ManoProcessor.h
//  ManoSDK
//
//  Created by Mhretab on 26/04/16.
//  Copyright © 2016 ManoMotion. All rights reserved.
//

#ifndef ManoProcessor_h
#define ManoProcessor_h

#define WEAK_IMPORT __attribute__((weak))
#define EXTERN __declspec(dllexport)
#define MAX_CONTOUR_POINTS 200
#define RGB_FORMAT 0
#define VUFORIA_FORMAT 2
#define PORTRAIT_ORIENTATION 1
#define INV_PORTRAIT_ORIENTATION 3
#define LANDSCAPE_ORIENTATION 2
#define INV_LANDSCAPE_ORIENTATION 0
#include "opencv2/opencv.hpp"
#include <string>
#include "OpenCVProcessor.hpp"
//#import <UIKit/UIKit.h>

#include "ManoMotion_iOS.h"

using namespace std;

/*
 * This dataset collects all the useful information to be provided to the developer,
 *  It contains not only the data retrived from the the database but also the dynamic gesture, roi size and position and binary
 */
struct ManomotionUnityGesture {
    /*
     * This dataset collects all the useful information to be provided to the developer,
     *  It contains not only the data retrived from the the database but also the dynamic gesture, roi size and position and binary
     */
    int frame;
    int mano_class;
    int mano_gesture_continuous;
    int mano_gesture_trigger;
    int hand;
    int rotation;
    int state;
    float top_left_x;
    float top_left_y;
    float palm_center_x;
    float palm_center_y;
    int flag;
    int background_mode;
    float width;
    float height;
    float relative_depth;
    int amount_of_contour_points;
    int amount_of_palm_points;
    
};
#define ENTRY_POINT __attribute__ ((visibility ("default")))
#define PROTECTED __attribute__ ((visibility ("protected")))
#define INTERNAL __attribute__ ((visibility ("internal")))
#define HIDDEN __attribute__ ((visibility ("hidden")))

extern "C"  {
#ifdef _LOG_MEASUREMENT_ON_
    vector<int> pre_process_values;
    vector<int> return_info_values;
    vector<int> whole_process_frame_values;
#endif
    /*
     * This method must be always called before anything in order to initialize all the necessary vbles
     */
    
    ENTRY_POINT int init(char * serial_key);
    
    ENTRY_POINT ManomotionUnityGesture processFrame();
    
    ENTRY_POINT void calibrate();
#ifdef _LOG_MEASUREMENT_ON_
    ENTRY_POINT void stop();
#endif
    
    ENTRY_POINT int getVersion();
    
    ENTRY_POINT void setBackgroundMode(int mode);
    
    ENTRY_POINT void  setHand(int hand);
    
    ENTRY_POINT void  setOrientation(int orientation);
    
    ENTRY_POINT void  setFrameFormat(int frame_format);
    
    ENTRY_POINT void  setFrameArray (void * frame);
    
    ENTRY_POINT void  setMRFrameArray (int * frame);
    
    ENTRY_POINT void  setResolution(int width, int height);
    
    ENTRY_POINT void  setImageBinaries(int * full_binary, int * scaled_binary, int * hand);
    
    ENTRY_POINT void  setPointArrays(float * contour_points,float * inner_points, float * finter_tips);
    
    
    
}
#endif /* ManoProcessor_h */
