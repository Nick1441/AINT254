using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogPlaceSetter : MonoBehaviour
{
    public float POS;

    //Sets Fog Infront of player, keeps it at the same place, but doesnt move sideways as player does.
    void Start()
    {
        POS = transform.position.x;
    }

    void Update()
    {
        transform.position = new Vector3(POS, transform.position.y, transform.position.z);
    }
}
