﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingFloor : MonoBehaviour
{

    //UnityEvent TestEvent = new UnityEvent()
    //public UnityEvent OnPlatform;

    public GameObject player;

    public void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    public void TestThis()
    {
        
        player.GetComponent<BasicMovement>().OnPlatformLeft();
    }
    // Start is called before the first frame update
    public void OnTriggerStay(Collider col)
    {

        TestThis();
        //OnPlatform.Invoke();
    }





}
