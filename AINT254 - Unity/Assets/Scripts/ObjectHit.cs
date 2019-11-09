using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public int Damage = 100;

    private void OnTriggerEnter(Collider Col)
    {
        Debug.Log("Test54");
        Col.transform.SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }
}
