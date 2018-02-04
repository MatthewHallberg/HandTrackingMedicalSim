using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class appearAndDisappear : MonoBehaviour {

    float currentTransparency = 0;
    float currentIndex = 0;
    float speed = 3;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
        currentIndex += (speed * Time.deltaTime);
        currentTransparency = (Mathf.Sin(currentIndex )+1)/2;
        GetComponent<Image>().color = new Color(1, 1, 1, currentTransparency); ;
	}
}
