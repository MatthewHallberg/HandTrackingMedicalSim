#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <cstring>
#include <string.h>
#include <stdio.h>
#include <cmath>
#include <limits>
#include <assert.h>
#include <stdint.h>

#include "il2cpp-class-internals.h"
#include "codegen/il2cpp-codegen.h"
#include "il2cpp-object-internals.h"


// System.Char[]
struct CharU5BU5D_t3528271667;
// System.Void
struct Void_t1185182177;
// UnityEngine.GameObject
struct GameObject_t1113636619;
// HandTrackerManager
struct HandTrackerManager_t4164054413;
// UnityEngine.UI.Image
struct Image_t2670269651;




#ifndef RUNTIMEOBJECT_H
#define RUNTIMEOBJECT_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Object

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // RUNTIMEOBJECT_H
#ifndef VALUETYPE_T3640485471_H
#define VALUETYPE_T3640485471_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.ValueType
struct  ValueType_t3640485471  : public RuntimeObject
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.ValueType
struct ValueType_t3640485471_marshaled_com
{
};
#endif // VALUETYPE_T3640485471_H
#ifndef ENUM_T4135868527_H
#define ENUM_T4135868527_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Enum
struct  Enum_t4135868527  : public ValueType_t3640485471
{
public:

public:
};

struct Enum_t4135868527_StaticFields
{
public:
	// System.Char[] System.Enum::split_char
	CharU5BU5D_t3528271667* ___split_char_0;

public:
	inline static int32_t get_offset_of_split_char_0() { return static_cast<int32_t>(offsetof(Enum_t4135868527_StaticFields, ___split_char_0)); }
	inline CharU5BU5D_t3528271667* get_split_char_0() const { return ___split_char_0; }
	inline CharU5BU5D_t3528271667** get_address_of_split_char_0() { return &___split_char_0; }
	inline void set_split_char_0(CharU5BU5D_t3528271667* value)
	{
		___split_char_0 = value;
		Il2CppCodeGenWriteBarrier((&___split_char_0), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Enum
struct Enum_t4135868527_marshaled_pinvoke
{
};
// Native definition for COM marshalling of System.Enum
struct Enum_t4135868527_marshaled_com
{
};
#endif // ENUM_T4135868527_H
#ifndef INTPTR_T_H
#define INTPTR_T_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.IntPtr
struct  IntPtr_t 
{
public:
	// System.Void* System.IntPtr::m_value
	void* ___m_value_0;

public:
	inline static int32_t get_offset_of_m_value_0() { return static_cast<int32_t>(offsetof(IntPtr_t, ___m_value_0)); }
	inline void* get_m_value_0() const { return ___m_value_0; }
	inline void** get_address_of_m_value_0() { return &___m_value_0; }
	inline void set_m_value_0(void* value)
	{
		___m_value_0 = value;
	}
};

struct IntPtr_t_StaticFields
{
public:
	// System.IntPtr System.IntPtr::Zero
	intptr_t ___Zero_1;

public:
	inline static int32_t get_offset_of_Zero_1() { return static_cast<int32_t>(offsetof(IntPtr_t_StaticFields, ___Zero_1)); }
	inline intptr_t get_Zero_1() const { return ___Zero_1; }
	inline intptr_t* get_address_of_Zero_1() { return &___Zero_1; }
	inline void set_Zero_1(intptr_t value)
	{
		___Zero_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // INTPTR_T_H
#ifndef MANOMOTIONGESTURE_T2403666322_H
#define MANOMOTIONGESTURE_T2403666322_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ManomotionGesture
struct  ManomotionGesture_t2403666322 
{
public:
	// System.Int32 ManomotionGesture::frame
	int32_t ___frame_0;
	// System.Int32 ManomotionGesture::mano_class
	int32_t ___mano_class_1;
	// System.Int32 ManomotionGesture::mano_gesture_continuous
	int32_t ___mano_gesture_continuous_2;
	// System.Int32 ManomotionGesture::mano_gesture_trigger
	int32_t ___mano_gesture_trigger_3;
	// System.Int32 ManomotionGesture::hand
	int32_t ___hand_4;
	// System.Int32 ManomotionGesture::rotation
	int32_t ___rotation_5;
	// System.Int32 ManomotionGesture::state
	int32_t ___state_6;
	// System.Single ManomotionGesture::top_left_x
	float ___top_left_x_7;
	// System.Single ManomotionGesture::top_left_y
	float ___top_left_y_8;
	// System.Single ManomotionGesture::palm_center_x
	float ___palm_center_x_9;
	// System.Single ManomotionGesture::palm_center_y
	float ___palm_center_y_10;
	// System.Int32 ManomotionGesture::flag
	int32_t ___flag_11;
	// System.Int32 ManomotionGesture::background_mode
	int32_t ___background_mode_12;
	// System.Single ManomotionGesture::width
	float ___width_13;
	// System.Single ManomotionGesture::height
	float ___height_14;
	// System.Single ManomotionGesture::relative_depth
	float ___relative_depth_15;
	// System.Int32 ManomotionGesture::amount_of_contour_points
	int32_t ___amount_of_contour_points_16;
	// System.Int32 ManomotionGesture::amount_of_palm_points
	int32_t ___amount_of_palm_points_17;

public:
	inline static int32_t get_offset_of_frame_0() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___frame_0)); }
	inline int32_t get_frame_0() const { return ___frame_0; }
	inline int32_t* get_address_of_frame_0() { return &___frame_0; }
	inline void set_frame_0(int32_t value)
	{
		___frame_0 = value;
	}

	inline static int32_t get_offset_of_mano_class_1() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___mano_class_1)); }
	inline int32_t get_mano_class_1() const { return ___mano_class_1; }
	inline int32_t* get_address_of_mano_class_1() { return &___mano_class_1; }
	inline void set_mano_class_1(int32_t value)
	{
		___mano_class_1 = value;
	}

	inline static int32_t get_offset_of_mano_gesture_continuous_2() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___mano_gesture_continuous_2)); }
	inline int32_t get_mano_gesture_continuous_2() const { return ___mano_gesture_continuous_2; }
	inline int32_t* get_address_of_mano_gesture_continuous_2() { return &___mano_gesture_continuous_2; }
	inline void set_mano_gesture_continuous_2(int32_t value)
	{
		___mano_gesture_continuous_2 = value;
	}

	inline static int32_t get_offset_of_mano_gesture_trigger_3() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___mano_gesture_trigger_3)); }
	inline int32_t get_mano_gesture_trigger_3() const { return ___mano_gesture_trigger_3; }
	inline int32_t* get_address_of_mano_gesture_trigger_3() { return &___mano_gesture_trigger_3; }
	inline void set_mano_gesture_trigger_3(int32_t value)
	{
		___mano_gesture_trigger_3 = value;
	}

	inline static int32_t get_offset_of_hand_4() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___hand_4)); }
	inline int32_t get_hand_4() const { return ___hand_4; }
	inline int32_t* get_address_of_hand_4() { return &___hand_4; }
	inline void set_hand_4(int32_t value)
	{
		___hand_4 = value;
	}

	inline static int32_t get_offset_of_rotation_5() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___rotation_5)); }
	inline int32_t get_rotation_5() const { return ___rotation_5; }
	inline int32_t* get_address_of_rotation_5() { return &___rotation_5; }
	inline void set_rotation_5(int32_t value)
	{
		___rotation_5 = value;
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___state_6)); }
	inline int32_t get_state_6() const { return ___state_6; }
	inline int32_t* get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(int32_t value)
	{
		___state_6 = value;
	}

	inline static int32_t get_offset_of_top_left_x_7() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___top_left_x_7)); }
	inline float get_top_left_x_7() const { return ___top_left_x_7; }
	inline float* get_address_of_top_left_x_7() { return &___top_left_x_7; }
	inline void set_top_left_x_7(float value)
	{
		___top_left_x_7 = value;
	}

	inline static int32_t get_offset_of_top_left_y_8() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___top_left_y_8)); }
	inline float get_top_left_y_8() const { return ___top_left_y_8; }
	inline float* get_address_of_top_left_y_8() { return &___top_left_y_8; }
	inline void set_top_left_y_8(float value)
	{
		___top_left_y_8 = value;
	}

	inline static int32_t get_offset_of_palm_center_x_9() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___palm_center_x_9)); }
	inline float get_palm_center_x_9() const { return ___palm_center_x_9; }
	inline float* get_address_of_palm_center_x_9() { return &___palm_center_x_9; }
	inline void set_palm_center_x_9(float value)
	{
		___palm_center_x_9 = value;
	}

	inline static int32_t get_offset_of_palm_center_y_10() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___palm_center_y_10)); }
	inline float get_palm_center_y_10() const { return ___palm_center_y_10; }
	inline float* get_address_of_palm_center_y_10() { return &___palm_center_y_10; }
	inline void set_palm_center_y_10(float value)
	{
		___palm_center_y_10 = value;
	}

	inline static int32_t get_offset_of_flag_11() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___flag_11)); }
	inline int32_t get_flag_11() const { return ___flag_11; }
	inline int32_t* get_address_of_flag_11() { return &___flag_11; }
	inline void set_flag_11(int32_t value)
	{
		___flag_11 = value;
	}

	inline static int32_t get_offset_of_background_mode_12() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___background_mode_12)); }
	inline int32_t get_background_mode_12() const { return ___background_mode_12; }
	inline int32_t* get_address_of_background_mode_12() { return &___background_mode_12; }
	inline void set_background_mode_12(int32_t value)
	{
		___background_mode_12 = value;
	}

	inline static int32_t get_offset_of_width_13() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___width_13)); }
	inline float get_width_13() const { return ___width_13; }
	inline float* get_address_of_width_13() { return &___width_13; }
	inline void set_width_13(float value)
	{
		___width_13 = value;
	}

	inline static int32_t get_offset_of_height_14() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___height_14)); }
	inline float get_height_14() const { return ___height_14; }
	inline float* get_address_of_height_14() { return &___height_14; }
	inline void set_height_14(float value)
	{
		___height_14 = value;
	}

	inline static int32_t get_offset_of_relative_depth_15() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___relative_depth_15)); }
	inline float get_relative_depth_15() const { return ___relative_depth_15; }
	inline float* get_address_of_relative_depth_15() { return &___relative_depth_15; }
	inline void set_relative_depth_15(float value)
	{
		___relative_depth_15 = value;
	}

	inline static int32_t get_offset_of_amount_of_contour_points_16() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___amount_of_contour_points_16)); }
	inline int32_t get_amount_of_contour_points_16() const { return ___amount_of_contour_points_16; }
	inline int32_t* get_address_of_amount_of_contour_points_16() { return &___amount_of_contour_points_16; }
	inline void set_amount_of_contour_points_16(int32_t value)
	{
		___amount_of_contour_points_16 = value;
	}

	inline static int32_t get_offset_of_amount_of_palm_points_17() { return static_cast<int32_t>(offsetof(ManomotionGesture_t2403666322, ___amount_of_palm_points_17)); }
	inline int32_t get_amount_of_palm_points_17() const { return ___amount_of_palm_points_17; }
	inline int32_t* get_address_of_amount_of_palm_points_17() { return &___amount_of_palm_points_17; }
	inline void set_amount_of_palm_points_17(int32_t value)
	{
		___amount_of_palm_points_17 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MANOMOTIONGESTURE_T2403666322_H
#ifndef OBJECT_T631007953_H
#define OBJECT_T631007953_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Object
struct  Object_t631007953  : public RuntimeObject
{
public:
	// System.IntPtr UnityEngine.Object::m_CachedPtr
	intptr_t ___m_CachedPtr_0;

public:
	inline static int32_t get_offset_of_m_CachedPtr_0() { return static_cast<int32_t>(offsetof(Object_t631007953, ___m_CachedPtr_0)); }
	inline intptr_t get_m_CachedPtr_0() const { return ___m_CachedPtr_0; }
	inline intptr_t* get_address_of_m_CachedPtr_0() { return &___m_CachedPtr_0; }
	inline void set_m_CachedPtr_0(intptr_t value)
	{
		___m_CachedPtr_0 = value;
	}
};

struct Object_t631007953_StaticFields
{
public:
	// System.Int32 UnityEngine.Object::OffsetOfInstanceIDInCPlusPlusObject
	int32_t ___OffsetOfInstanceIDInCPlusPlusObject_1;

public:
	inline static int32_t get_offset_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return static_cast<int32_t>(offsetof(Object_t631007953_StaticFields, ___OffsetOfInstanceIDInCPlusPlusObject_1)); }
	inline int32_t get_OffsetOfInstanceIDInCPlusPlusObject_1() const { return ___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline int32_t* get_address_of_OffsetOfInstanceIDInCPlusPlusObject_1() { return &___OffsetOfInstanceIDInCPlusPlusObject_1; }
	inline void set_OffsetOfInstanceIDInCPlusPlusObject_1(int32_t value)
	{
		___OffsetOfInstanceIDInCPlusPlusObject_1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_pinvoke
{
	intptr_t ___m_CachedPtr_0;
};
// Native definition for COM marshalling of UnityEngine.Object
struct Object_t631007953_marshaled_com
{
	intptr_t ___m_CachedPtr_0;
};
#endif // OBJECT_T631007953_H
#ifndef FLAGS_T624286006_H
#define FLAGS_T624286006_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HandTrackerManager/Flags
struct  Flags_t624286006 
{
public:
	// System.Int32 HandTrackerManager/Flags::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(Flags_t624286006, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // FLAGS_T624286006_H
#ifndef BACKGROUNDS_T4242298689_H
#define BACKGROUNDS_T4242298689_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HandTrackerManager/Backgrounds
struct  Backgrounds_t4242298689 
{
public:
	// System.Int32 HandTrackerManager/Backgrounds::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(Backgrounds_t4242298689, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BACKGROUNDS_T4242298689_H
#ifndef MANOGESTURECONTINUOUS_T3081313876_H
#define MANOGESTURECONTINUOUS_T3081313876_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// HandTrackerManager/ManoGestureContinuous
struct  ManoGestureContinuous_t3081313876 
{
public:
	// System.Int32 HandTrackerManager/ManoGestureContinuous::value__
	int32_t ___value___1;

public:
	inline static int32_t get_offset_of_value___1() { return static_cast<int32_t>(offsetof(ManoGestureContinuous_t3081313876, ___value___1)); }
	inline int32_t get_value___1() const { return ___value___1; }
	inline int32_t* get_address_of_value___1() { return &___value___1; }
	inline void set_value___1(int32_t value)
	{
		___value___1 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MANOGESTURECONTINUOUS_T3081313876_H
#ifndef COMPONENT_T1923634451_H
#define COMPONENT_T1923634451_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Component
struct  Component_t1923634451  : public Object_t631007953
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // COMPONENT_T1923634451_H
#ifndef BEHAVIOUR_T1437897464_H
#define BEHAVIOUR_T1437897464_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Behaviour
struct  Behaviour_t1437897464  : public Component_t1923634451
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // BEHAVIOUR_T1437897464_H
#ifndef MONOBEHAVIOUR_T3962482529_H
#define MONOBEHAVIOUR_T3962482529_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.MonoBehaviour
struct  MonoBehaviour_t3962482529  : public Behaviour_t1437897464
{
public:

public:
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MONOBEHAVIOUR_T3962482529_H
#ifndef MANOBUTTONBEHAVIOR_T3117567429_H
#define MANOBUTTONBEHAVIOR_T3117567429_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// ManoButtonBehavior
struct  ManoButtonBehavior_t3117567429  : public MonoBehaviour_t3962482529
{
public:
	// UnityEngine.GameObject ManoButtonBehavior::menu
	GameObject_t1113636619 * ___menu_2;
	// System.Boolean ManoButtonBehavior::menuIsOpen
	bool ___menuIsOpen_3;
	// System.Single ManoButtonBehavior::timeStamp
	float ___timeStamp_4;
	// System.Single ManoButtonBehavior::menuCoolDown
	float ___menuCoolDown_5;

public:
	inline static int32_t get_offset_of_menu_2() { return static_cast<int32_t>(offsetof(ManoButtonBehavior_t3117567429, ___menu_2)); }
	inline GameObject_t1113636619 * get_menu_2() const { return ___menu_2; }
	inline GameObject_t1113636619 ** get_address_of_menu_2() { return &___menu_2; }
	inline void set_menu_2(GameObject_t1113636619 * value)
	{
		___menu_2 = value;
		Il2CppCodeGenWriteBarrier((&___menu_2), value);
	}

	inline static int32_t get_offset_of_menuIsOpen_3() { return static_cast<int32_t>(offsetof(ManoButtonBehavior_t3117567429, ___menuIsOpen_3)); }
	inline bool get_menuIsOpen_3() const { return ___menuIsOpen_3; }
	inline bool* get_address_of_menuIsOpen_3() { return &___menuIsOpen_3; }
	inline void set_menuIsOpen_3(bool value)
	{
		___menuIsOpen_3 = value;
	}

	inline static int32_t get_offset_of_timeStamp_4() { return static_cast<int32_t>(offsetof(ManoButtonBehavior_t3117567429, ___timeStamp_4)); }
	inline float get_timeStamp_4() const { return ___timeStamp_4; }
	inline float* get_address_of_timeStamp_4() { return &___timeStamp_4; }
	inline void set_timeStamp_4(float value)
	{
		___timeStamp_4 = value;
	}

	inline static int32_t get_offset_of_menuCoolDown_5() { return static_cast<int32_t>(offsetof(ManoButtonBehavior_t3117567429, ___menuCoolDown_5)); }
	inline float get_menuCoolDown_5() const { return ___menuCoolDown_5; }
	inline float* get_address_of_menuCoolDown_5() { return &___menuCoolDown_5; }
	inline void set_menuCoolDown_5(float value)
	{
		___menuCoolDown_5 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // MANOBUTTONBEHAVIOR_T3117567429_H
#ifndef SHOWSWIPES_T375804480_H
#define SHOWSWIPES_T375804480_H
#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// showSwipes
struct  showSwipes_t375804480  : public MonoBehaviour_t3962482529
{
public:
	// HandTrackerManager showSwipes::htm
	HandTrackerManager_t4164054413 * ___htm_2;
	// UnityEngine.UI.Image showSwipes::swipeRightIndicator
	Image_t2670269651 * ___swipeRightIndicator_3;
	// UnityEngine.UI.Image showSwipes::swipeLeftIndicator
	Image_t2670269651 * ___swipeLeftIndicator_4;

public:
	inline static int32_t get_offset_of_htm_2() { return static_cast<int32_t>(offsetof(showSwipes_t375804480, ___htm_2)); }
	inline HandTrackerManager_t4164054413 * get_htm_2() const { return ___htm_2; }
	inline HandTrackerManager_t4164054413 ** get_address_of_htm_2() { return &___htm_2; }
	inline void set_htm_2(HandTrackerManager_t4164054413 * value)
	{
		___htm_2 = value;
		Il2CppCodeGenWriteBarrier((&___htm_2), value);
	}

	inline static int32_t get_offset_of_swipeRightIndicator_3() { return static_cast<int32_t>(offsetof(showSwipes_t375804480, ___swipeRightIndicator_3)); }
	inline Image_t2670269651 * get_swipeRightIndicator_3() const { return ___swipeRightIndicator_3; }
	inline Image_t2670269651 ** get_address_of_swipeRightIndicator_3() { return &___swipeRightIndicator_3; }
	inline void set_swipeRightIndicator_3(Image_t2670269651 * value)
	{
		___swipeRightIndicator_3 = value;
		Il2CppCodeGenWriteBarrier((&___swipeRightIndicator_3), value);
	}

	inline static int32_t get_offset_of_swipeLeftIndicator_4() { return static_cast<int32_t>(offsetof(showSwipes_t375804480, ___swipeLeftIndicator_4)); }
	inline Image_t2670269651 * get_swipeLeftIndicator_4() const { return ___swipeLeftIndicator_4; }
	inline Image_t2670269651 ** get_address_of_swipeLeftIndicator_4() { return &___swipeLeftIndicator_4; }
	inline void set_swipeLeftIndicator_4(Image_t2670269651 * value)
	{
		___swipeLeftIndicator_4 = value;
		Il2CppCodeGenWriteBarrier((&___swipeLeftIndicator_4), value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
#endif // SHOWSWIPES_T375804480_H





#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1800 = { sizeof (ManoGestureContinuous_t3081313876)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1800[8] = 
{
	ManoGestureContinuous_t3081313876::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1801 = { sizeof (Flags_t624286006)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1801[26] = 
{
	Flags_t624286006::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1802 = { sizeof (Backgrounds_t4242298689)+ sizeof (RuntimeObject), sizeof(int32_t), 0, 0 };
extern const int32_t g_FieldOffsetTable1802[6] = 
{
	Backgrounds_t4242298689::get_offset_of_value___1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	0,
	0,
	0,
	0,
	0,
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1803 = { sizeof (ManoButtonBehavior_t3117567429), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1803[4] = 
{
	ManoButtonBehavior_t3117567429::get_offset_of_menu_2(),
	ManoButtonBehavior_t3117567429::get_offset_of_menuIsOpen_3(),
	ManoButtonBehavior_t3117567429::get_offset_of_timeStamp_4(),
	ManoButtonBehavior_t3117567429::get_offset_of_menuCoolDown_5(),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1804 = { sizeof (ManomotionGesture_t2403666322)+ sizeof (RuntimeObject), sizeof(ManomotionGesture_t2403666322 ), 0, 0 };
extern const int32_t g_FieldOffsetTable1804[18] = 
{
	ManomotionGesture_t2403666322::get_offset_of_frame_0() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_mano_class_1() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_mano_gesture_continuous_2() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_mano_gesture_trigger_3() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_hand_4() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_rotation_5() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_state_6() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_top_left_x_7() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_top_left_y_8() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_palm_center_x_9() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_palm_center_y_10() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_flag_11() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_background_mode_12() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_width_13() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_height_14() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_relative_depth_15() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_amount_of_contour_points_16() + static_cast<int32_t>(sizeof(RuntimeObject)),
	ManomotionGesture_t2403666322::get_offset_of_amount_of_palm_points_17() + static_cast<int32_t>(sizeof(RuntimeObject)),
};
extern const Il2CppTypeDefinitionSizes g_typeDefinitionSize1805 = { sizeof (showSwipes_t375804480), -1, 0, 0 };
extern const int32_t g_FieldOffsetTable1805[3] = 
{
	showSwipes_t375804480::get_offset_of_htm_2(),
	showSwipes_t375804480::get_offset_of_swipeRightIndicator_3(),
	showSwipes_t375804480::get_offset_of_swipeLeftIndicator_4(),
};
#ifdef __clang__
#pragma clang diagnostic pop
#endif
