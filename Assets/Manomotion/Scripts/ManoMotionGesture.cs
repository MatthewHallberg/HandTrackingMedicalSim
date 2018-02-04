using UnityEngine;
using System.Runtime.InteropServices;
using System;
using System.Collections;
using System.Collections.Generic;

public struct ManomotionGesture
{
	public int frame;
	public int mano_class;
	public int mano_gesture_continuous;
	public int mano_gesture_trigger;
	public int hand;
	public int rotation;
	public int state;
	public float top_left_x;
	public float top_left_y;
	public float palm_center_x;
	public float palm_center_y;
	public int flag;
	public int background_mode;
	public float width;
	public float height;
	public float relative_depth;
	
	public int amount_of_contour_points;
	public int amount_of_palm_points;
	
    /*
	public float[] contour_points;
	public float[] inner_points;
    public float[] fingertips;
    public UnityEngine.Color32[] binary_hand;
    public UnityEngine.Color32[] full_binary;
    public UnityEngine.Color32[] cut_hand;
    public string flag_text;*/
}