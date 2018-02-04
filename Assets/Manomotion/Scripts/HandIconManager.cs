using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandIconManager : MonoBehaviour
{

	[SerializeField]
	HandTrackerManager htm;
	[SerializeField]
	Image left, right;
	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{

	}

	int currenthand = 1;

	public void swapHand ()
	{

		currenthand = (currenthand + 1) % 2;
		adjustIcons ();
		htm.SetHand (currenthand);
		Handheld.Vibrate ();
	}

	private void adjustIcons ()
	{
		if (currenthand == 1) {
			left.color = new Color (left.color.r, left.color.g, left.color.b, .5f);
			right.color = new Color (right.color.r, right.color.g, right.color.b, 1f);
		} else {
			left.color = new Color (left.color.r, left.color.g, left.color.b, 1f);
			right.color = new Color (right.color.r, right.color.g, right.color.b, .5f);
		}
	}
}
