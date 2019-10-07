using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAnimationController : MonoBehaviour
{

    Animator anim;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
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
        //AnimationController();
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
