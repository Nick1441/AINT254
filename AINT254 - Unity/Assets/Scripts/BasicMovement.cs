using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    float LerpTime;
    float CurrentLerpTime;
    float MoveTime = 1;

    bool input;
    public bool Jumping;
    private bool Cooldown = false;

    //Locations Of Players Start and End Positions.
    Vector3 StartPos;
    Vector3 EndPos;

    //Animator anim;
    //public GameObject Player;
    
    //void Start()
    //{
    //    anim = gameObject.GetComponent<Animator>();
    //}

    void Update()
    {
        //This Is Called Every Frame, it is for movement of the Player.
        Movement();
        //AnimationController();
    }

    public void Movement()
    {
        //Checks To See if player is pressing one of the move Keys.
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (MoveTime == 1)
            {
                LerpTime = 1;
                CurrentLerpTime = 0;
                input = true;
                Jumping = true;
            }
        }

        //Sets Start and End Position By Defualt to where the Player is, Prevents Player Reseting Position.
        StartPos = gameObject.transform.position;

        //Moves Player when any of the Movement Keys Are Pressed.
        if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("UNSDFHSUADHU");
            EndPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EndPos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EndPos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }

        if (input == true)
        {
            //Moves Player to New End Position.
            CurrentLerpTime += Time.deltaTime;
            MoveTime = CurrentLerpTime / LerpTime;
            gameObject.transform.position = Vector3.Lerp(StartPos, EndPos, MoveTime);

            //Checks to see if Movement is almost complete then Resets.
            if (MoveTime > 0.8)
            {
                MoveTime = 1;
            }

            if (Mathf.Round(MoveTime) == 1)
            {
                Jumping = false;
            }
        }
    }
}
