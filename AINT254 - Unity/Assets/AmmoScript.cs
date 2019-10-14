using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public float MoveSpeed = 100.0f;
    public int Damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
