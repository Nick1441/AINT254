using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public Transform player;

    public void Update()
    {
        transform.LookAt(player);
    }
}
