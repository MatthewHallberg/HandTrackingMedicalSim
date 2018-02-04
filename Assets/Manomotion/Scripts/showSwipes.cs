using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showSwipes : MonoBehaviour
{
	[SerializeField]
	HandTrackerManager htm;
	[SerializeField]
	private Image swipeRightIndicator, swipeLeftIndicator;
	// Use this for initialization
	void Start ()
	{
	}

	void Update ()
	{
		switch (htm.GetManomotionGesture ().mano_gesture_trigger) {
		case (int)HandTrackerManager.ManoGestureTrigger.SWIPE_LEFT_GESTURE:
			swipeLeftIndicator.color = new Color (85f / 255, 26f / 255, 139f / 255);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.SWIPE_RIGHT_GESTURE:
			swipeRightIndicator.color = new Color (85f / 255, 26f / 255, 139f / 255);
			break;
		}
		fadeSwipeIndicators ();
	}

	void fadeSwipeIndicators ()
	{
		swipeLeftIndicator.color = new Color (85f / 255, 26f / 255, 139f / 255, swipeLeftIndicator.color.a - Time.deltaTime);
		swipeRightIndicator.color = new Color (85f / 255, 26f / 255, 139f / 255, swipeRightIndicator.color.a - Time.deltaTime);
	}
}