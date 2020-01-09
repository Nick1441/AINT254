using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float Speed = 1;

    void Update()
    {
        transform.position += Vector3.forward * Speed  * Time.deltaTime;
    }
}
