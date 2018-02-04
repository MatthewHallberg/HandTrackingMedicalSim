
using UnityEngine;

#if UNITY_IOS
using UnityEngine.iOS;
#endif

using System.Runtime.InteropServices;
using System;




public class HandTrackerManager : MonoBehaviour
{
	#region imports

	#if UNITY_IOS
	const string library = "__Internal";
	#else
    const string library = "manomotion";
#endif
	[DllImport (library)]
	private static extern int init (string serial_key);

	[DllImport (library)]
	private static extern ManomotionGesture processFrame ();

	[DllImport (library)]
	private static extern void calibrate ();

	//[DllImport (library)]
	//private static extern void stop ();

	[DllImport (library)]
	private static extern int getVersion ();

	[DllImport (library)]
	private static extern void setBackgroundMode (int mode);

	[DllImport (library)]
	private static extern void setHand (int hand);

	[DllImport (library)]
	private static extern void setOrientation (int orientation);

	[DllImport (library)]
	private static extern void setFrameFormat (int frame_format);

	[DllImport (library)]
	private static extern void setFrameArray (Color32[] frame);

	[DllImport (library)]
	private static extern void setMRFrameArray (Color32[] frame);

	[DllImport (library)]
	private static extern void setResolution (int width, int height);

	[DllImport (library)]
	private static extern void setImageBinaries (int[] full_binary, int[] scaled_binary, int[] hand);

	[DllImport (library)]
	private static extern void setPointArrays (float[] contour_points, float[] inner_points, float[] finger_tips);

	#endregion

	#region consts
    
	public enum ManoClass
	{
		NO_HAND = -1,
		GRAB_BACK_GESTURE_FAMILY = 0,
		GRAB_FRONT_GESTURE_FAMILY = 1,
		PINCH_GESTURE_FAMILY = 2,
		POINTER_GESTURE_FAMILY = 3}
	;

	public enum ManoGestureTrigger
	{
		NO_GESTURE = -1,
		CLICK_GESTURE = 1,
		SWIPE_LEFT_GESTURE = 5,
		SWIPE_RIGHT_GESTURE = 6,
		GRAB_GESTURE = 4,
		TAP_POINTING_GESTURE = 2,
		RELEASE_PINCH = 8,
		GRAB_PINCH = 7,
		RELEASE_GESTURE = 3}
	;

	public enum ManoGestureContinuous
	{
		NO_GESTURE = -1,
		HOLD_GESTURE = 1,
		OPEN_HAND_GESTURE = 2,
		OPEN_PINCH_GESTURE = 3,
		CLOSED_HAND_GESTURE = 4,
		POINTER_GESTURE = 5,
		PUSH_POINTING_GESTURE = 6}
	;

	public enum Flags
	{
		FLAG_NOTHING = 0,
		FLAG_WARNING_HAND_NOT_FOUND = 1,
		FLAG_WARNING_CANT_DIFFERENTIATE_BACKGROUND = 2,
		FLAG_WARNING_APPROACHING_LOWER_EDGE = 3,
		FLAG_WARNING_APPROACHING_UPPER_EDGE = 4,
		FLAG_WARNING_APPROACHING_LEFT_EDGE = 5,
		FLAG_WARNING_APPROACHING_RIGHT_EDGE = 6,
		FLAG_WARNING_HAND_TOO_CLOSE = 7,
        FLAG_NOISE =8,


        FLAG_CALIBRATING = 20,
		FLAG_CALIBRATION_SUCCESS = 21,
		FLAG_CALIBRATION_FAIL = 22,

		FLAG_LICENSE_OK = 30,
		FLAG_LICENSE_KEY_NOT_FOUND = 31,
		FLAG_LICENSE_EXPIRED_WARNING = 32,
		FLAG_LICENSE_INVALID_PLAN = 33,
		FLAG_LICENSE_KEY_BLOCKED = 34,
		FLAG_INVALID_ACCESS_TOKEN = 35,
		FLAG_LICENSE_ACCESS_DENIED = 36,
		FLAG_LICENSE_MAX_NUM_DEVICES = 37,
		FLAG_UNKNOWN_SERVER_REPLY = 38,
		FLAG_LICENSE_PRODUCT_NOT_FOUND = 39,
		FLAG_LICENSE_INCORRECT_INPUT_PARAMETER = 40,
		FLAG_LICENSE_INTERNET_REQUIRED = 41,
		FLAG_BOUNDLE_ID_DOESENT_MATCH = 42}
	;

	public enum Backgrounds
	{
		BACKGROUND_NORMAL = 0,
		BACKGROUND_RED	= 1,
		BACKGROUND_YELLOW = 2,
		BACKGROUND_BROWN_DARKRED = 3,
		BACKGROUND_AUTO	= 4}
	;
    const int IOS_WIDTH = 352;
    const int IOS_HEIGHT = 288;
    const int ANDROID_WIDTH = 320;
    const int ANDROID_HEIGHT = 240;
    const int AR_WIDTH = 640;
    const int AR_HEIGHT = 360;

    #endregion

    #region variables

    protected bool _initialized = false;
	protected WebCamTexture _mCamera = null;
	protected ManomotionGesture _gestureDetected;
	protected Texture2D _binaryTexture;
	protected Texture2D _binaryHandTexture;
	protected Texture2D _frameTexture;
	protected Texture2D _background2D;
	protected Texture2D _handLayer2D;

	private float fpsCooldown = 0;
	private int frameCount = 0;
	private int _fps = 0;
	protected int Width, Height;

	protected Vector3[] fingerTips = new Vector3[5];
	protected Vector3[] _bound_points = new Vector3[200];
	protected Vector3[] _palm_points = new Vector3[200];
	private Vector3 pointer_position;
	private int pointer_index;
	private Vector3 palmCenter;


	protected int[] _binary_frame_100 = new int[10000];
	protected int[] _binary_frame_320 = new int[10000];
	protected int[] _binary_hand = new int[10000];
	protected float[] _contour_points = new float[400];
	protected float[] _inner_points = new float[400];
	protected float[] _finger_tips = new float[10];

	string toastMessage = "";
	float toastTime;

	float cooldownDeveloperPanel;

	private int current_background_mode;

	private bool _simulateClick, _simulateGrab, _simulateTap, _simulateRelease, _simulateSwipeRight, _simulateSwipeLeft;
	protected Color32[] _pixels, _MRPixels;
    [Tooltip("Insert the key gotten from the webpage here www.manomotion.com")]
    [SerializeField]
	private string serial_key;
    
	[SerializeField]
	private MeshRenderer _hand;
    [SerializeField]
    private MeshRenderer _binary;
    [SerializeField]
    protected MeshRenderer _background;
    [SerializeField]
    protected MeshRenderer _hand_layer;
    [SerializeField]
    private RectTransform recommendCalibrationPanel;

    public Vector3 PalmCenter {
		get {
			return palmCenter;
		}
	}

	public Vector3[] FingerTips {
		get {
			return fingerTips;
		}
	}

	public Vector3[] Bound_points {
		get {
			return _bound_points;
		}
	}

	public Vector3 Pointer_position {
		get {
			return pointer_position;
		}
	}

	public int Pointer_index {
		get {
			return pointer_index;
		}
	}

	public Vector3[] Palm_points {
		get {
			return _palm_points;
		}
	}

    [Tooltip("activate the layered hand representation that interacts with depth")]
    public bool _layering_enabled = false;
    [Tooltip("enable toast messages for debug purpuses")]
    public bool _toast_enabled = false;
    [Tooltip("enable the AR background of the camera feed")]
    public bool _show_background = true;
	private adjustToScreen _layer_adjust;
	private GUIStyle style;

	#endregion

	public void Start ()
	{

		StartCamera ();

		SetBackgroundTexture ();
		SetUnityConditions ();
		_initialized = true;
	}

	protected void StartCamera ()
	{
#if UNITY_ANDROID
        Width = ANDROID_WIDTH;
        Height = ANDROID_HEIGHT;
#else
        Width = IOS_WIDTH;
        Height = IOS_HEIGHT;
#endif
#if UNITY_EDITOR_WIN
        Width = 640;
        Height = 480;
#endif
#if UNITY_EDITOR_OSX
        Width = 1280;
        Height = 720;
#endif
        _mCamera = new WebCamTexture (WebCamTexture.devices [0].name, Width, Height);
		_mCamera.requestedFPS = 120;
		_mCamera.Play ();
        PickResolution(Width, Height);

	}
    protected void PickResolution(int width, int height)
    {
        Debug.Log("Changed from " + Width + "x" + Height + " to " + width + "x" + height);
        Width = width;
        Height = height;
        InitiateTextures();
        InitiateLibrary();
    }
	protected void SetBackgroundTexture ()
	{
		_background.material.mainTexture = _mCamera;
	}


	protected void InitiateTextures ()
	{
		_binary_frame_320 = new int[Width * Height];
		_layer_adjust = _hand_layer.gameObject.GetComponent<adjustToScreen> ();

		_binaryTexture = new Texture2D (100, 100);
		_binaryHandTexture = new Texture2D (100, 100);
		_frameTexture = new Texture2D (Width, Height);
		_background2D = new Texture2D (Width, Height);
		_handLayer2D = new Texture2D (Width, Height);
	}

	protected void SetUnityConditions ()
	{
		Application.targetFrameRate = 300;
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
	}

	protected void InitiateLibrary ()
	{

		ForcePermissionRequest ();
       
		Debug.Log ("Init:" + Init (serial_key));
		SetPointArrays ();
        
		SetImageBinaries (); 
		int orientation = 0;
		SetOrientation (orientation);
		int frame_format = 0;
		SetFrameFormat (frame_format);
		SetResolution (Width, Height);
		_pixels = new Color32[Width * Height];
		_MRPixels = new Color32[Width * Height];
		SetFrameArray (_pixels); 
		SetMRFrameArray (_MRPixels);
	}

	void ForcePermissionRequest ()
	{
#if UNITY_ANDROID
#if !UNITY_EDITOR
         //Force permissions request from java
        AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
        AndroidJavaObject activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
        AndroidJavaClass unity_bridge_class = new AndroidJavaClass("com.manomotion.unitymanager.UnityBridge");
        if (unity_bridge_class != null)
        {
            unity_bridge_class.CallStatic("setActivity", activity);
            unity_bridge_class.CallStatic("requestPermissions");
        }
        else
        {
        }

#endif
#endif
	}

#region init_wrappers

	protected float Init (string serial_key)
	{
#if !UNITY_EDITOR
        return init(serial_key);
#endif

		return 0;
	}

	protected void SetPointArrays ()
	{
#if !UNITY_EDITOR
        setPointArrays(_contour_points, _inner_points, _finger_tips);
#endif
	}

	protected void SetImageBinaries ()
	{
#if !UNITY_EDITOR
        setImageBinaries(_binary_frame_320, _binary_frame_100, _binary_hand);
#endif
	}

	protected void SetResolution (int width, int height)
	{
#if !UNITY_EDITOR
        setResolution(width, height);
#endif
	}

	protected void SetFrameFormat (int frame_format)
	{
#if !UNITY_EDITOR
        setFrameFormat(frame_format);
#endif
	}

	protected void SetOrientation (int orientation)
	{
#if !UNITY_EDITOR
        setOrientation(orientation);
#endif
	}

	protected void SetFrameArray (Color32[] pixels)
	{
#if !UNITY_EDITOR
        setFrameArray(pixels);
#endif
	}

	protected void SetMRFrameArray (Color32[] pixels)
	{
#if !UNITY_EDITOR
        setMRFrameArray(pixels);
#endif
	}

#endregion

	void OnGUI ()
	{
#if UNITY_EDITOR
		UnityEngine.Rect _clickButton = new UnityEngine.Rect (Screen.width * 0.1f, Screen.height * 0.1f, Screen.width * 0.2f, Screen.height * 0.1f);
		UnityEngine.Rect _grabButton = new UnityEngine.Rect (Screen.width * 0.1f, Screen.height * 0.3f, Screen.width * 0.2f, Screen.height * 0.1f);
		UnityEngine.Rect _releaseButton = new UnityEngine.Rect (Screen.width * 0.1f, Screen.height * 0.5f, Screen.width * 0.2f, Screen.height * 0.1f);
		UnityEngine.Rect _tapButton = new UnityEngine.Rect (Screen.width * 0.1f, Screen.height * 0.7f, Screen.width * 0.2f, Screen.height * 0.1f);
		UnityEngine.Rect _SwipeLeftButton = new UnityEngine.Rect (Screen.width * 0.1f, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f);
		UnityEngine.Rect _SwipeRightButton = new UnityEngine.Rect (Screen.width * 0.7f, Screen.height * 0.9f, Screen.width * 0.2f, Screen.height * 0.1f);

		if (GUI.Button (_clickButton, "click")) {
			_simulateClick = true;
		}
		if (GUI.Button (_grabButton, "grab")) {
			_simulateGrab = true;
		}
		if (GUI.Button (_releaseButton, "release")) {
			_simulateRelease = true;
		}
		if (GUI.Button (_tapButton, "tap")) {
			_simulateTap = true;
		}
		if (GUI.Button (_SwipeRightButton, "SwipeRight")) {
			_simulateSwipeRight = true;
		}
		if (GUI.Button (_SwipeLeftButton, "SwipeLeft")) {
			_simulateSwipeLeft = true;
		}

		if (toastTime > 0) {
			toastTime -= Time.deltaTime / 5;
			float xPos = Camera.main.pixelWidth * 0.3f;
			float yPos = Camera.main.pixelHeight * Math.Max ((0.5f + ((Math.Abs (toastTime - .5f)))), 0.7f);
			float width = Camera.main.pixelWidth * 0.4f;
			float height = Camera.main.pixelHeight * 0.1f;

			UnityEngine.Rect toast = new UnityEngine.Rect (xPos, yPos, width, height);
			GUI.Box (toast, toastMessage, style);
		}
#endif
    }

    void Update ()
	{
        if (_initialized)
        {
            
            if (!_mCamera.isPlaying)
            {
                _mCamera.Play();
            }
            CalculateFPS();
            TouchScreenMenu();
            CheckFlags();
            RefreshManoMotionData();
            Layering();
        }
    }

    protected void CalculateFPS ()
	{
		fpsCooldown += Time.deltaTime;
		frameCount++;
		if (fpsCooldown >= 1) {
			_fps = frameCount;
			frameCount = 0;
			fpsCooldown -= 1;
		}
	}

	protected void TouchScreenMenu ()
	{
		cooldownDeveloperPanel -= Time.deltaTime;
		if (Input.touches.Length == 2) {
			Calibrate ();
		}
		if (Input.touches.Length == 3 && cooldownDeveloperPanel < 0) {
			cooldownDeveloperPanel = .5f;
			ToggleBackground ();
		}
	}
    int noise_flags_in_the_last_10_frames=0;

    protected bool CheckFlags ()
	{
		bool is_tracking_related = _gestureDetected.flag == (int)Flags.FLAG_WARNING_APPROACHING_LOWER_EDGE || _gestureDetected.flag == (int)Flags.FLAG_WARNING_APPROACHING_UPPER_EDGE || _gestureDetected.flag == (int)Flags.FLAG_WARNING_APPROACHING_LEFT_EDGE || _gestureDetected.flag == (int)Flags.FLAG_WARNING_APPROACHING_RIGHT_EDGE;
		bool res = false;
		switch (_gestureDetected.flag) {
		case (int)Flags.FLAG_CALIBRATION_SUCCESS:
			Toast ("Calibration succeded");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_BOUNDLE_ID_DOESENT_MATCH:
			Toast ("Boundle ID doesent match");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_CALIBRATION_FAIL:
			Toast ("Calibration failed");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_INVALID_ACCESS_TOKEN:
			Toast ("Invalid Access Token");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_ACCESS_DENIED:
			Toast ("License access denied");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_EXPIRED_WARNING:
			Toast ("License expired");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_INCORRECT_INPUT_PARAMETER:
			Toast ("License Incorrect Input Parameter");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_INTERNET_REQUIRED:
			Toast ("No internet access");// _gestureDetected.flag_text);
			break;

		case (int)Flags.FLAG_LICENSE_INVALID_PLAN:
			Toast ("Invalid Plan");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_KEY_BLOCKED:
			Toast ("Key Blocked");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_KEY_NOT_FOUND:
			Toast ("Key Not found");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_MAX_NUM_DEVICES:
			Toast ("max number of devices reached");// _gestureDetected.flag_text);
			break;
		case (int)Flags.FLAG_LICENSE_PRODUCT_NOT_FOUND:
			Toast ("License product not found");// _gestureDetected.flag_text);
			break;
            
		default:
			res = true;
			break;
		}

        if (_gestureDetected.flag == (int)Flags.FLAG_NOISE)
        {
            noise_flags_in_the_last_10_frames = Mathf.Min(noise_flags_in_the_last_10_frames+2,10); ;
        }
        noise_flags_in_the_last_10_frames = Mathf.Max(noise_flags_in_the_last_10_frames-1,0);
        if(noise_flags_in_the_last_10_frames>4)
            recommendCalibrationPanel.gameObject.SetActive(true);
        else
            recommendCalibrationPanel.gameObject.SetActive(false);

        return res;
	}
	protected void RefreshManoMotionData ()
	{
		Color32[] camera_pixels = _mCamera.GetPixels32 ();

        if (camera_pixels.Length != Width * Height)
        {
            PickResolution(_mCamera.width, _mCamera.height);
        }

		camera_pixels.CopyTo (_pixels, 0);
        if (camera_pixels.Length == Width * Height)
        {
            _background2D.SetPixels32(_pixels);
			try
            {
                _gestureDetected = ProcessFrame();

            }
            catch (System.Exception ex)
            {
            }
				
            setImageInformation();
            setDataFromGesture();
		}
        else
        {
            Debug.Log("camera size doesent match: " +camera_pixels.Length + " != " + Width * Height);
        }
	}

	protected ManomotionGesture ProcessFrame ()
	{
#if !UNITY_EDITOR
        return processFrame();
#endif
		ManomotionGesture simulatedGesture = new ManomotionGesture ();
		simulatedGesture.amount_of_contour_points = 13;
		simulatedGesture.amount_of_palm_points = 13;
		simulatedGesture.background_mode = (int)Backgrounds.BACKGROUND_AUTO;
		simulatedGesture.flag = (int)Flags.FLAG_LICENSE_OK;
		simulatedGesture.frame = 0;
		simulatedGesture.hand = 1;
		simulatedGesture.mano_class = (int)ManoClass.GRAB_BACK_GESTURE_FAMILY;
		simulatedGesture.mano_gesture_continuous = (int)ManoGestureContinuous.OPEN_HAND_GESTURE;
		simulatedGesture.palm_center_x = Input.mousePosition.x / Camera.main.pixelWidth;
		simulatedGesture.palm_center_y = 1 - Input.mousePosition.y / Camera.main.pixelHeight;
		simulatedGesture.relative_depth = .5f;
		simulatedGesture.rotation = 0;
		simulatedGesture.state = 0;
		simulatedGesture.top_left_x = Input.mousePosition.x / Camera.main.pixelWidth;
		simulatedGesture.top_left_y = 1 - Input.mousePosition.y / Camera.main.pixelHeight;
		simulatedGesture.width = 10;
		simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.NO_GESTURE;

        if (Input.GetKey(KeyCode.B))
        {
            simulatedGesture.flag = (int)Flags.FLAG_NOISE;
        }
        if (_simulateClick) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.CLICK_GESTURE;
			_simulateClick = false;
		}
		if (_simulateGrab) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.GRAB_GESTURE;
			_simulateGrab = false;
		}
		if (_simulateRelease) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.RELEASE_GESTURE;
			_simulateRelease = false;
		}
		if (_simulateTap) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.TAP_POINTING_GESTURE;
			_simulateTap = false;
		}
		if (_simulateSwipeLeft) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.SWIPE_LEFT_GESTURE;
			_simulateSwipeLeft = false;
		}
		if (_simulateSwipeRight) {
			simulatedGesture.mano_gesture_trigger = (int)ManoGestureTrigger.SWIPE_RIGHT_GESTURE;
			_simulateSwipeRight = false;
		}
        
#region fingers
		Vector3[] fingers = new Vector3[5];
		palmCenter = Input.mousePosition;
		palmCenter.Scale (new Vector2 (1 / Camera.main.pixelWidth, 1 / Camera.main.pixelHeight));
		fingers [0] = new Vector3 (.2f, 0.2f);
		fingers [1] = new Vector3 (-0.23f, 0.05f);
		fingers [2] = new Vector3 (-0.1f, 0.2f);
		fingers [3] = new Vector3 (0f, 0.2f);
		fingers [4] = new Vector3 (.1f, 0.2f);
		for (int i = 0; i < fingers.Length; i++) {
			_finger_tips [2 * i] = fingers [i].x + simulatedGesture.palm_center_x;
			_finger_tips [2 * i + 1] = -fingers [i].y + simulatedGesture.palm_center_y;
		}
#endregion
#region contour 
		_bound_points = new Vector3[13];
		_bound_points [0] = palmCenter + Vector3.down * .1f;
		;
		_bound_points [1] = palmCenter + Vector3.left * .05f;
		_bound_points [2] = fingers [1];
		_bound_points [3] = (fingers [1] + fingers [2] + palmCenter * 2) / 4;
		_bound_points [4] = fingers [2];
		_bound_points [5] = (fingers [3] + fingers [2] + palmCenter * 2) / 4;
		_bound_points [6] = fingers [3];
		_bound_points [7] = (fingers [3] + fingers [4] + palmCenter * 2) / 4;
		_bound_points [8] = fingers [4];
		_bound_points [9] = (fingers [4] + fingers [0] + palmCenter * 2) / 4;
		_bound_points [10] = fingers [0];
		_bound_points [11] = palmCenter + Vector3.right * .05f;
		_bound_points [12] = _bound_points [0];

		for (int i = 0; i < _bound_points.Length; i++) {
			_contour_points [2 * i] = _bound_points [i].x + simulatedGesture.palm_center_x;
			_contour_points [2 * i + 1] = -_bound_points [i].y + simulatedGesture.palm_center_y;
		}

#endregion
#region inner
		_palm_points = new Vector3[13];

		for (int i = 0; i < _palm_points.Length; i++) {
			if (i % 3 == 0) {
				_palm_points [i] = (_bound_points [i] + palmCenter * 2) / 3;
				_inner_points [2 * i] = (_contour_points [2 * i] + simulatedGesture.palm_center_x * 2) / 3;
				_inner_points [2 * i + 1] = (_contour_points [2 * i + 1] + simulatedGesture.palm_center_y * 2) / 3;
			} else {
				_palm_points [i] = (_bound_points [i] * 2 + palmCenter) / 3;
				_inner_points [2 * i] = (_contour_points [2 * i] * 2 + simulatedGesture.palm_center_x) / 3;
				_inner_points [2 * i + 1] = (_contour_points [2 * i + 1] * 2 + simulatedGesture.palm_center_y) / 3;
			}
            
		}
#endregion
#region binarys
		for (int i = 0; i < _binary_frame_320.Length; i++) {
			if ((i % 40 < 20) == (i / Width % 40 < 20) && i < Width * Height / 2)
				_binary_frame_320 [i] = 255;
			else
				_binary_frame_320 [i] = 0;
		}
		for (int i = 0; i < _binary_frame_100.Length; i++) {
			if ((i % 20 < 10) == (i / Width % 20 < 10) && i < 5000)
				_binary_frame_100 [i] = 255;
			else
				_binary_frame_100 [i] = 0;
		}
		for (int i = 0; i < _binary_hand.Length; i++) {
			if ((i % 20 < 10) == (i / Width % 20 < 10) && i < 5000)
				_binary_hand [i] = 255;
			else
				_binary_hand [i] = 0;
		}
		for (int i = 0; i < _MRPixels.Length; i++) {
			if ((i % 20 < 10) == (i / Width % 20 < 10))
				_MRPixels [i] = new Color32 (0, 0, 0, 0);
			else
				_MRPixels [i] = new Color32 ((byte)(i / Width), (byte)(i / Height), (byte)(i % Width), 255);
		}
#endregion
		return simulatedGesture;
	}

	protected void setImageInformation ()
	{
		Color32[] frame = new Color32[1];
		Color32[] only_hand = new Color32[1];

		intArraytoColor32Array (ref only_hand, ref frame);

		_binaryTexture.SetPixels32 (frame);
		_binaryHandTexture.SetPixels32 (only_hand);

		_binaryTexture.Apply ();
		_binaryHandTexture.Apply ();

		if (_binary) {
			_binary.material.mainTexture = _binaryTexture as Texture;
		}
		if (_hand) {
			_hand.material.mainTexture = _binaryHandTexture as Texture;
		}
		ShowBackgroundTexture ();
		
	}

	void intArraytoColor32Array (ref UnityEngine.Color32[] binary_32, ref UnityEngine.Color32[] cut_binary_32)
	{
		binary_32 = new Color32[_binary_frame_100.Length];
		cut_binary_32 = new Color32[_binary_hand.Length];
		if (_binary_frame_100.Length == _binary_hand.Length) {
			for (int i = 0; i < _binary_frame_100.Length; i++) {
				binary_32 [i].r = (byte)(_binary_frame_100 [i]);
				binary_32 [i].g = (byte)(_binary_frame_100 [i]); //& 0xFF00);
				binary_32 [i].b = (byte)(_binary_frame_100 [i]);  //& 0xFF0000);
				binary_32 [i].a = 255;  //& 0xFF000000);

				cut_binary_32 [i].r = (byte)(_binary_hand [i]);
				cut_binary_32 [i].g = (byte)(_binary_hand [i]); //& 0xFF00);
				cut_binary_32 [i].b = (byte)(_binary_hand [i]);  //& 0xFF0000);
				cut_binary_32 [i].a = 255;  //& 0xFF000000);
			}
		}
	}

	void ShowBackgroundTexture ()
	{
		if (_show_background) {
			_background.material.mainTexture = _mCamera;
			_background.gameObject.SetActive (true);

		} else {
			_background.gameObject.SetActive (false);

		}
		if (_layering_enabled) {
			SetHandLayerImage ();
		}
		
	}

	protected void SetHandLayerImage ()
	{
		Color32[] bin320;// = new Color32[binary.Length];
		bin320 = _MRPixels;

		_handLayer2D.SetPixels32 (bin320);
		_handLayer2D.Apply ();
		_hand_layer.material.mainTexture = _handLayer2D as Texture;
	}

	protected void setDataFromGesture ()
	{
		float[] out_points = new float[_gestureDetected.amount_of_contour_points * 2];
		float[] in_points = new float[_gestureDetected.amount_of_palm_points * 2];
		for (int i = 0; i < Math.Min (out_points.Length, _contour_points.Length); i++) {
			out_points [i] = _contour_points [i];
		}

		for (int i = 0; i < Math.Min (in_points.Length, _inner_points.Length); i++) {
			in_points [i] = _inner_points [i];
		}

		_bound_points = new Vector3[out_points.Length / 2];
		_palm_points = new Vector3[in_points.Length / 2];

		pointer_index = 0;
		float farthest_distance = 0;
		//contour_points = out_points;
		//inner_points = in_points;

		Vector3[] fingers = new Vector3[5];

		for (int i = 0; i < fingers.Length; i++) {
			int dx = (int)(_finger_tips [2 * i] * Camera.main.pixelWidth);
			int dy = (int)((1.0f - (_finger_tips [2 * i + 1])) * Camera.main.pixelHeight);
			fingers [i] = new Vector3 (dx, dy);
		}

		fingerTips = fingers;
		for (int i = 0; i < 200; i++) {
			if (i < _palm_points.Length) {

				float d_x = ((float)in_points [2 * i]) * Camera.main.pixelWidth;
				float d_y = (1 - (float)in_points [2 * i + 1]) * Camera.main.pixelHeight;

				_palm_points [i] = new Vector2 (d_x, d_y);
			}
			if (i < _bound_points.Length) {

				float d_x = ((float)out_points [2 * i]) * Camera.main.pixelWidth;
				float d_y = (1 - (float)out_points [2 * i + 1]) * Camera.main.pixelHeight;

				_bound_points [i] = new Vector2 (d_x, d_y);
			}
		}

		if (fingers [3].x > -1) {
			pointer_position = fingers [3];
		}
		int px = (int)(((float)_gestureDetected.palm_center_x * Camera.main.pixelWidth));
		int py = (int)((1 - (_gestureDetected.palm_center_y)) * Camera.main.pixelHeight);
		palmCenter = new Vector3 (px, py);
	}

	protected void Layering ()
	{
		_hand_layer.gameObject.SetActive (_layering_enabled);

		if (_hand_layer) {
			_hand_layer.transform.localPosition = new Vector3 (0, 0, _gestureDetected.relative_depth);
			_layer_adjust.AdjustSize ();
		}
	}

#region getters

	public ManomotionGesture GetManomotionGesture ()
	{
		return _gestureDetected;
	}

	public WebCamTexture GetCamera ()
	{
		return _mCamera;
	}

	public Texture2D GetBinary ()
	{
		return (Texture2D)_binary.material.mainTexture;
	}

	public Texture2D GetBackground ()
	{
		return (Texture2D)_background2D;
	}

	public Texture2D getBinaryHand ()
	{
		return (Texture2D)_hand.material.mainTexture;
	}

	public int GetFPS ()
	{
		return _fps;
	}

#endregion

#region native_wrappers

	public void Calibrate ()
	{
        recommendCalibrationPanel.gameObject.SetActive(false);
#if !UNITY_EDITOR
		calibrate();
#endif

	}


	public void ChangeBackgroundMode (int mode)
	{
#if !UNITY_EDITOR

			setBackgroundMode(mode);
#endif
	}

	public void SetHand (int hand)
	{
#if !UNITY_EDITOR

        setHand(hand);
#endif
	}


    #endregion

	public void ToggleBackground()
	{
		_show_background = !_show_background;
	}
	public void ToggleLayering()
	{
		_layering_enabled = !_layering_enabled;
	}
	void Toast (string message)
	{
		if (toastTime <= 0 && _toast_enabled) {
			toastTime = 1;
			toastMessage = message;
		}
	}

	void CheckBackgroundModeChanges ()
	{
		if (_gestureDetected.background_mode != current_background_mode) {
			String bg_mode = "";
			switch (_gestureDetected.background_mode) {
			case (int)Backgrounds.BACKGROUND_NORMAL:
				bg_mode = "Normal";
				break;
			case (int)Backgrounds.BACKGROUND_RED:
				bg_mode = "Red";
				break;
			case (int)Backgrounds.BACKGROUND_YELLOW:
				bg_mode = "Yellow";
				break;
			case (int)Backgrounds.BACKGROUND_BROWN_DARKRED:
				bg_mode = "Brown";
				break;
			case (int)Backgrounds.BACKGROUND_AUTO:
				bg_mode = "Auto";
				break;
			}

			Toast ("Background Mode has changed to " + bg_mode);
			current_background_mode = _gestureDetected.background_mode;
		}
	}

}