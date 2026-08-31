using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SplashScreen : MonoBehaviour
{
    public UnityEvent onCanceled;
    public float delayTime = 2;

    IEnumerator Start()
    {
        yield return new WaitForSeconds(delayTime);
        onCanceled?.Invoke();
    }
}
