using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimation : MonoBehaviour
{
    private Animator Anim;
    //Starts Challenges at random times.
    void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
        Anim.Play(0, -1, Random.Range(0.0f, 1.0f));
    }
}
