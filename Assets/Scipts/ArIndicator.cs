using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ArIndicator : MonoBehaviour
{
    public ARRaycastManager raycastManager;
    private List<ARRaycastHit> hit;
    public GameObject indicator;
    public Camera cam;

    private bool isPlaced;
    bool isPlaneFound;

    private void Update()
    {
        if (indicator == null)
            return;
        if (isPlaced)
            return;
        hit = new List<ARRaycastHit>();
        isPlaneFound = raycastManager.Raycast(cam.ViewportToScreenPoint(new Vector2(0.5f, 0.5f)), hit, TrackableType.Planes);

        indicator.SetActive(isPlaneFound);

        if (isPlaneFound)
        {
            transform.position = hit[0].pose.position;
        }
    }

    public void SetPlaced()
    {
        if (!isPlaneFound)
            return;
        isPlaced = !isPlaced;
    }

    public void CreateIndicator(GameObject prefab = null)
    {
        if (prefab == null) {
            if (indicator != null)
            {
                Destroy(indicator.gameObject);
            }
            indicator = null;
        }
        else
        {
            indicator = Instantiate<GameObject>(prefab, Vector3.zero, Quaternion.identity, transform);
        }
    }

    public void DeleteIndicator()
    {
        CreateIndicator();
    }
}
