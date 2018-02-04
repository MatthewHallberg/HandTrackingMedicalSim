using UnityEngine;
using System.Collections;

public class adjustToScreen : MonoBehaviour
{
    [SerializeField]
    Camera cam;
    // Use this for initialization
    [SerializeField]
    HandTrackerManager htm;

    float width, height;

    [SerializeField]
    float initial_depth;

    void Awake()
    {
		if (!cam)
		{
			cam = Camera.main;
		}
		transform.parent = cam.transform;
		transform.localPosition = new Vector3(0, 0, initial_depth);
		#if UNITY_EDITOR
		transform.localScale = transform.localScale * -1;
		transform.localScale.Scale(new Vector3(1, -1, 1));
		#endif
		#if UNITY_IOS
		transform.localScale.Scale (new Vector3 (1, -1, 1));
		#endif
		AdjustSize();
    }

    public void AdjustSize()
    {
        float size = 1;

        width = cam.pixelWidth;
		height = cam.pixelHeight;
        float ratio = (float)width / height;

        transform.localScale = new Vector3(size * ratio, size, 1);
        Bounds b = GetComponent<MeshRenderer>().bounds;
        Vector3 v3ViewPort = new Vector3(0, 0, transform.localPosition.z);
        Vector3 v3BottomLeft = cam.ViewportToWorldPoint(v3ViewPort);
        v3ViewPort.Set(1, 1, transform.localPosition.z);
        Vector3 v3TopRight = cam.ViewportToWorldPoint(v3ViewPort);
        Vector3 v1 = (v3TopRight - v3BottomLeft);
        Vector3 v2 = (b.max - b.min);
        size *= v1.y / v2.y;
#if UNITY_IOS
     transform.localScale = new Vector3(size * ratio, -size, 1);
#elif UNITY_ANDROID
        transform.localScale = new Vector3(size * ratio, size, 1);
#endif
    }
}