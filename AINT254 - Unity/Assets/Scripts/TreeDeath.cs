using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDeath : MonoBehaviour
{
    //Calling animation before tree object is destroyed.
    public void StartThis()
    {
        gameObject.GetComponent<Animator>().enabled = true;
        Invoke("Destroy", 3.5f);
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }
}
