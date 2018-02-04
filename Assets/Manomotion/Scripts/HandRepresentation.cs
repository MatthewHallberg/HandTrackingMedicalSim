using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using System;

public class HandRepresentation : MonoBehaviour
{
	[SerializeField]
	Color _outlinePointsColor, _innerPointsColor, _clickLineColor, _tapLineColor, _grabLineColor, _releaseLineColor, _releasePinchLineColor, _grabPinchLineColor, _fingertipsLineColor;
	[SerializeField]
	Color _holdColor, _baseColor, _pinchColor, _openHandColor, _closedHandColor, _pushColor, _pointerColor;
	[SerializeField]
	HandTrackerManager htm;
	[SerializeField]
	private Transform outer_dots, inner_dots;
    [Space(10)]
    [SerializeField]
    bool _showFingerTips = true;

    private Transform palm;
	private Transform[] contour_particles = new Transform[200];
	private Transform[] inner_particles = new Transform[200];
	private LineRenderer lr;
	private Transform[] fingertips_t = new Transform[5];
    private String[] finger_labels = {"Pinky", "Ring", "Mid", "Index", "Thumb"};

    public bool DisplayFingerTips
    {
        get
        {
            return _showFingerTips;
        }

        set
        {
            _showFingerTips = value;
        }
    }

    // Use this for initialization
    void Start ()
	{
		CreateFingerTipParticles ();
		CreateContourParticles ();
		CreateInnerParticles ();
	}

	void CreateFingerTipParticles ()
	{
		palm = GameObject.Instantiate (inner_dots);
		palm.SetParent( transform);
		palm.gameObject.GetComponent<MeshRenderer> ().material.color = _baseColor;

		for (int i = 0; i < fingertips_t.Length; i++) { // fingertips
			Transform pointer = GameObject.Instantiate (inner_dots);
			pointer.localScale = pointer.localScale * UnityEngine.Random.Range (4f, 4f);
            pointer.gameObject.GetComponent<MeshRenderer>().material.color = _fingertipsLineColor + (new Color(.2f, 0f, -.2f, 0)) * i;
            pointer.SetParent(transform);
            TextMesh label = pointer.GetComponentInChildren<TextMesh>();
          	label.text = finger_labels[i];
            fingertips_t [i] = pointer;
		}
	}

	void CreateContourParticles ()
	{
		lr = GetComponent<LineRenderer> ();
		for (int i = 0; i < contour_particles.Length; i++) {
			contour_particles [i] = GameObject.Instantiate (outer_dots);
			contour_particles [i].localScale = contour_particles [i].localScale * UnityEngine.Random.Range (0.5f, 1.5f);
			contour_particles [i].gameObject.GetComponent<MeshRenderer> ().material.color = _outlinePointsColor;
            contour_particles[i].SetParent(transform);

        }
    }

	void CreateInnerParticles ()
	{
		for (int i = 0; i < inner_particles.Length; i++) {
			inner_particles [i] = GameObject.Instantiate (inner_dots);
			inner_particles [i].gameObject.GetComponent<MeshRenderer> ().material.color = _innerPointsColor;
			inner_particles [i].localScale = inner_particles [i].localScale * UnityEngine.Random.Range (0.5f, 1.5f);
            inner_particles[i].SetParent(transform);

        }
    }

	void Update ()
	{
		HideAR (htm.GetManomotionGesture ());
		ShowFingerTips (htm.GetManomotionGesture ());
		ShowContour (htm.GetManomotionGesture ());
		ShowInner (htm.GetManomotionGesture ());
		UpdateLineColor ();
		UpdatePalmColor ();
	}

	void UpdateLineColor ()
	{
		int trigger = htm.GetManomotionGesture ().mano_gesture_trigger;
		switch (trigger) {
		case (int)HandTrackerManager.ManoGestureTrigger.GRAB_GESTURE:
			highLight (_grabLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.RELEASE_GESTURE:
			highLight (_releaseLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.CLICK_GESTURE:
			highLight (_clickLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.TAP_POINTING_GESTURE:
			highLight (_tapLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.GRAB_PINCH:
			highLight (_grabPinchLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.RELEASE_PINCH:
			highLight (_releasePinchLineColor);
			break;
		case (int)HandTrackerManager.ManoGestureTrigger.NO_GESTURE:
			break;
		default:
			break;
		}

	}

	void UpdatePalmColor ()
	{
		int continous = htm.GetManomotionGesture ().mano_gesture_continuous;

		switch (continous) {
		case (int)HandTrackerManager.ManoGestureContinuous.HOLD_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _holdColor;
			break;
		case (int)HandTrackerManager.ManoGestureContinuous.CLOSED_HAND_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _closedHandColor;
			break;
		case (int)HandTrackerManager.ManoGestureContinuous.OPEN_HAND_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _openHandColor;
			break;
		case (int)HandTrackerManager.ManoGestureContinuous.OPEN_PINCH_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _pinchColor;
			break;
		case (int)HandTrackerManager.ManoGestureContinuous.PUSH_POINTING_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _pushColor;
			break;
		case (int)HandTrackerManager.ManoGestureContinuous.POINTER_GESTURE:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _pointerColor;
			break;
		default:
			palm.gameObject.GetComponent<MeshRenderer> ().material.color = _baseColor;
			break;
		}
	}

	private void findPinch (ManomotionGesture gesture)
	{
		if (gesture.mano_class == (int)HandTrackerManager.ManoClass.PINCH_GESTURE_FAMILY) {
			Vector3 selectedPoint = htm.Bound_points [0];
			for (int i = 0; i < htm.Bound_points.Length; i++) {
				if (selectedPoint.x < htm.Bound_points [i].x) {
					selectedPoint = htm.Bound_points [i];
				}
			}
		}
	}

	private void HideAR (ManomotionGesture gesture)
	{
		if (gesture.mano_class == (int)HandTrackerManager.ManoClass.NO_HAND || htm._layering_enabled) {
			changeLayer (12);
		} else {
			changeLayer (0);
		}
        if (_showFingerTips)
        {
            for (int i = 0; i < fingertips_t.Length; i++)
            {
                TextMesh label = fingertips_t[i].GetComponentInChildren<TextMesh>();
                label.color = Color.clear;
            }
        }
        else
        {
            for (int i = 0; i < fingertips_t.Length; i++)
            {
                TextMesh label = fingertips_t[i].GetComponentInChildren<TextMesh>();
                label.color = Color.white;
            }
        }
	}

	private void ShowFingerTips (ManomotionGesture gesture)
	{
		palm.position = Camera.main.ScreenToWorldPoint (htm.PalmCenter + Vector3.forward * gesture.relative_depth);
		for (int i = 0; i < 5; i++) {
			if (htm.FingerTips.Length > i) { 
				fingertips_t [i].gameObject.SetActive (true);
				Vector3 newPos = Camera.main.ScreenToWorldPoint (htm.FingerTips [i] + Vector3.forward * gesture.relative_depth);
				fingertips_t [i].position = newPos;
			} else
				fingertips_t [i].gameObject.SetActive (false);
		}
	}

	private void ShowContour (ManomotionGesture gesture)
	{
		if (htm.Bound_points != null) {
			lr.positionCount = htm.Bound_points.Length + 1;
			for (int i = 0; i < 200; i++) {
				if (i < htm.Bound_points.Length) {
					lr.SetPosition (htm.Bound_points.Length, contour_particles [0].position);
					contour_particles [i].gameObject.SetActive (true);
					Vector3 newPos = Camera.main.ScreenToWorldPoint ((Vector3)htm.Bound_points [i] + Vector3.forward * gesture.relative_depth);
					contour_particles [i].position = newPos;
					lr.SetPosition (i, contour_particles [i].position);
				} else {
					contour_particles [i].gameObject.SetActive (false);
				}
			}
		}
		
	}

	private void ShowInner (ManomotionGesture gesture)
	{
		for (int i = 0; i < 200; i++) {
			if (htm.Palm_points != null) {
				if (i < htm.Palm_points.Length) {
					inner_particles [i].gameObject.SetActive (true);
					inner_particles [i].position = Camera.main.ScreenToWorldPoint ((Vector3)htm.Palm_points [i] + Vector3.forward * gesture.relative_depth);
				} else {
					inner_particles [i].gameObject.SetActive (false);
				}
			}
		}
	}

	private void highLight (Color color)
	{
		lr.startColor = color;
		lr.endColor = color;
		StartCoroutine (fade ());
	}

	private void changeLayer (int layer)
	{
		if (gameObject.layer != layer) {
			gameObject.layer = layer;
			for (int i = 0; i < transform.childCount; i++) {
				transform.GetChild (i).gameObject.layer = layer;
			}
		}
	}

	IEnumerator fade ()
	{
		for (int i = 0; i < 100; i++) {
			yield return new WaitForSeconds (.01f);
			float r = lr.startColor.r + .02f;
			float g = lr.startColor.g + .02f;
			float b = lr.startColor.b + .02f;
			float a = Math.Max (.1f, lr.startColor.a - .02f);
			Color newColor = new Color (r, g, b, a);
			lr.startColor = newColor;
			lr.endColor = newColor;
			if (r >= 1 && g >= 1 && b >= 1 && a <= .1f)
				break;
		}
	}
}