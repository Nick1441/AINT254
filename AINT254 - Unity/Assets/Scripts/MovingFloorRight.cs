using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingFloorRight : MonoBehaviour
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

        player.GetComponent<BasicMovement>().OnPlatForm();
    }
    // Start is called before the first frame update
    public void OnTriggerStay(Collider col)
    {

        TestThis();
        //OnPlatform.Invoke();
    }





}
