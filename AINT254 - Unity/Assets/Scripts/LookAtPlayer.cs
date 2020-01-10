using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    public Transform playerPos;

    public void Update()
    {
        transform.LookAt(playerPos);
    }

    //Makes Enemy look towards a player.
    public void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerPos = player.transform;
    }
}
