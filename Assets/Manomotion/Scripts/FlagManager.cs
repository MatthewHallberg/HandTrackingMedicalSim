using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlagManager : MonoBehaviour
{
	[SerializeField]
	HandTrackerManager htm;

	[SerializeField]
	Image[] flagImages;

	[SerializeField]
	Image vignette;

    [SerializeField]
    bool showBorderFlags, showVignete;
	void Update ()
	{
		HighlightFlags (htm.GetManomotionGesture ().flag);
		ShowDetectionWarning (htm.GetManomotionGesture ().flag);
//		Debug.Log ("Flag = " + htm.GetManomotionGesture ().flag.ToString ());

	}

	//This method will highlight the border images, used for alerting the user that he is approaching the edges of the screen.
	//The flag that respond to a given edge (upper, right, lower, left) will also set the color values of the image to its original RGB values as well as the alpha channel.
	//Otherwise the image will disapear overtime due to the alpha chanel decrease.
	void HighlightFlags (int warningFlag)
	{
        if(showBorderFlags)
        { 
		    if (warningFlag == (int)HandTrackerManager.Flags.FLAG_WARNING_APPROACHING_UPPER_EDGE) {
			    flagImages [0].color = new Color (85f / 255, 26f / 255, 139f / 255);

		    }
		    if (warningFlag == (int)HandTrackerManager.Flags.FLAG_WARNING_APPROACHING_RIGHT_EDGE) {
			    flagImages [1].color = new Color (85f / 255, 26f / 255, 139f / 255);

		    }
		    if (warningFlag == (int)HandTrackerManager.Flags.FLAG_WARNING_APPROACHING_LOWER_EDGE) {
			    flagImages [2].color = new Color (85f / 255, 26f / 255, 139f / 255);

		    }
		    if (warningFlag == (int)HandTrackerManager.Flags.FLAG_WARNING_APPROACHING_LEFT_EDGE) {
			    flagImages [3].color = new Color (85f / 255, 26f / 255, 139f / 255);

		    }
        }
        for (int i = 0; i < flagImages.Length; i++) {
			flagImages [i].color = new Color (85f / 255, 26f / 255, 139f / 255, flagImages [i].color.a - Time.deltaTime);
		}
	}


	// This method will set the vignette color to its original color values
	// This will result in a grey overlay image, indicating that the hand is not well reckognized


	void ShowDetectionWarning (int warningFlag)
	{
		Debug.Log ("warningFlag: "+ warningFlag);

        if (warningFlag == (int)HandTrackerManager.Flags.FLAG_NOISE &&  showVignete) {
            vignette.color = new Color(98f / 255f, 98f / 255f, 98f / 255f, Mathf.Min(vignette.color.a +2* Time.deltaTime/1.5f,1));
       //     Debug.Log ("color changed");
		}

		vignette.color = new Color (98f / 255f, 98f / 255f, 98f / 255f, Mathf.Max(vignette.color.a - Time.deltaTime / 1.5f, 0));
	}
    
}
