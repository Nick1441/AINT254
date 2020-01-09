using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogPlaceSetter : MonoBehaviour
{
    public float POS;

    void Start()
    {
        POS = transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(POS, transform.position.y, transform.position.z);
    }
}
