using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelectBackground : MonoBehaviour
{
	[SerializeField]
	GameObject activeBackgroundCircle, menu;
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void SelectBackgroundMode ()
	{

		if (this.gameObject.GetComponent<Image> ().sprite != null) {
			activeBackgroundCircle.GetComponent<Image> ().sprite = this.gameObject.GetComponent<Image> ().sprite;
			Handheld.Vibrate ();
			menu.SetActive (false);
		}


	}
}
