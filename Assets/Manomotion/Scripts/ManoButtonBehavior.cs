using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManoButtonBehavior : MonoBehaviour
{
	[SerializeField]
	GameObject menu;

	private bool menuIsOpen;
	float timeStamp, menuCoolDown;
	// Use this for initialization
	void Start ()
	{
		menuCoolDown = 0.2f;
		timeStamp = Time.time + menuCoolDown;
		
	}
	
	// Update is called once per frame
	void Update ()
	{
        
		if (Input.touches.Length == 4 && timeStamp <= Time.time) {
			ActivateManoButton ();
			timeStamp = Time.time + menuCoolDown;
		}
        if (menu.activeSelf)
        {
            transform.Rotate(0, 0, -1);
        }
	}

	public void ActivateManoButton ()
	{
		if (menu.activeSelf == true) {
			menu.SetActive (false);
			Handheld.Vibrate ();

		} else {
			menu.SetActive (true);
			Handheld.Vibrate ();

		}
	}




}
