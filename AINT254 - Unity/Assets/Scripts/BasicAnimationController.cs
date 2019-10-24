using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimationController : MonoBehaviour
{

    Animator anim;
    public GameObject Player;

    //Getting Animator Component to allow animation between movements.
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
       AnimationController();
    }

    public void AnimationController()
    {
        BasicMovement MoveScript = Player.GetComponent<BasicMovement>();
        if (MoveScript.Jumping == true)
        {
            anim.SetBool("Jump", true);
        }
        else
        {
            anim.SetBool("Jump", false);
        }
    }
}
