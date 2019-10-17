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

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("THIS");
        other.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        DestroyObject();
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        DestroyObject();
    }
}
