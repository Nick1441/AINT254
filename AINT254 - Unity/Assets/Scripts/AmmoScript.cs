using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoScript : MonoBehaviour
{
    public float MoveSpeed = 100.0f;
    public int Damage = 1;

    //Gets Rigid Body Component, Multiplys by move speed of users  input.
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * MoveSpeed);
    }

    //When a bullet enters something, it sends int of Health as Damage.
    private void OnTriggerEnter(Collider Col)
    {
        Debug.Log("THIS");
        Col.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
        DestroyObject();
    }

    //Setting objects to destory when they can no longer bee seen.
    private void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void OnBecameInvisible()
    {
        DestroyObject();
    }
}
