using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public int Damage = 100;

    //When the train object hits the player. It will be instant death. 100 Damage will kill them. Sends data to players health script.
    private void OnTriggerEnter(Collider Col)
    {
        Col.transform.GetChild(0).SendMessage("TakeDamage", Damage, SendMessageOptions.DontRequireReceiver);
    }
}
