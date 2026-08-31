using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public float speed;

    private void Update()
    {
        if (Input.touchCount == 0)
            return;
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            transform.Rotate(0, touch.deltaPosition.x/Screen.width * Time.deltaTime * speed * 1000, 0);
        }
    }
}
