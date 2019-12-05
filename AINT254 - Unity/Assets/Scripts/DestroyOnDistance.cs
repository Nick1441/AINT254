using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    //Player Distance
    public GameObject Player;
    public float Distance;
    public float Range = 10;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Player = GameObject.FindWithTag("Player");
        Distance = Vector3.Distance(Player.transform.position, transform.position);

        if (Distance >= Range)
        {
            Destroy(this.gameObject);
        }
    }
}
