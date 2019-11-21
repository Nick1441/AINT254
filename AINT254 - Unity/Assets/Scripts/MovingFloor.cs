using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingFloor : MonoBehaviour
{
    public UnityEvent OnPlatform;
    // Start is called before the first frame update
    public void OnTriggerStay(Collider col)
    {
        OnPlatform.Invoke();
    }
}
