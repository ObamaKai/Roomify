using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARIndicator : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hit;
    public GameObject indicator;
    public Camera cam;

    private void Update()
    {
        hit = new List<ARRaycastHit>();

        bool isPlaneFound = raycastManager.Raycast(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), hit, TrackableType.Planes);

        indicator.SetActive(isPlaneFound);

        if (isPlaneFound)
        {
            transform.position = hit[0].pose.position;
        }
    }
}
