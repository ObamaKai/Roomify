using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class Buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    private Transform button;
    private GameObject gameObj;
    public Vector3 scalingSize;
    public UnityEvent ToAR;
    public Transform Indicator;





    private void Start()
    {
        button = GetComponent<Transform>();
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        
        button.transform.localScale = button.transform.localScale - scalingSize;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        ToAR?.Invoke();
        button.transform.localScale = button.transform.localScale + scalingSize;
    }
    public void OnClick(GameObject prefab)
    {
        gameObj = Instantiate(prefab, Vector3.zero, Quaternion.Euler(Vector3.zero), Indicator);
    }
    public void OnClickToReturnBack()
    {
        Destroy(gameObj);
    }
}
