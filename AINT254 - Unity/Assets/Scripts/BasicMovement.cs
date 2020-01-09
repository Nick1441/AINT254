using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BasicMovement : MonoBehaviour
{
    //Script to Move Player Around Map.
    //Moves Player 1 "Block" At a time, Equivilent to 1 Increase in Unity.
    //This Script also Contains methods for Colliding into walls & Moving When Colliding with Objects.
    //All Values Get Reset Back To a Integer.
    //Animation is Played When Player Moves, Allowing a smooth Transition for the Camera.


    float LerpTime;
    float CurrentLerpTime;
    float MoveTime = 1;

    bool input;
    public bool Jumping;
    public bool Floating;
    public bool InAir = false;
    private bool RightPlatform= false;
    private bool LeftPlatform = false;
    private bool OnFirstTime = true;
    private bool OnFirstTime2 = false;
    public float MoveSpeed = 10;

    //Locations Of Players Start and End Positions.
    Vector3 StartPos;
    Vector3 EndPos;

    //Calls Methods To Check What Movement Player Needs.
    void Update()
    {
        PlatFormCollision();
    }

    //These Are Sent By Colliders From Jumping Challenge.
    public void OnPlatForm()
    {
        RightPlatform= true;
    }

    public void OnPlatformLeft()
    {
        
        LeftPlatform = true;
    }

    //Method For Choosing Which Movement We Want, This is either Auto (On Jumping Challenger, Right Or Left), or Fully Down to the Player.
    public void PlatFormCollision()
    {
        if (RightPlatform== false && LeftPlatform == false)
        {
            //Calls Regular Method For Moving.
            Movement();
        }
        else if (RightPlatform== true)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)));
            if (MoveTime == 1)
            {
                LerpTime = 1;
                CurrentLerpTime = 0;
                input = true;
                Floating = true;
            }


            StartPos = gameObject.transform.position;

            EndPos = new Vector3((Mathf.RoundToInt(transform.position.x)) + 1, transform.position.y, transform.position.z);

            if (input == true)
            {
                //Moves Player to New End Position.
                CurrentLerpTime += Time.deltaTime * 5;
                MoveTime = CurrentLerpTime / LerpTime;
                gameObject.transform.position = Vector3.Lerp(StartPos, EndPos, MoveTime);


                //Checks to see if Movement is almost complete then Resets.
                if (MoveTime > 0.8)
                {
                    MoveTime = 1;
                }

                if (Mathf.Round(MoveTime) == 1)
                {
                    Floating = false;
                }
            }

            //Only Option On Platforms is To Move Forward Off Of Current Object.
            if (Input.GetKeyDown(KeyCode.W))
            {
                RightPlatform= false;
                EndPos = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)) + 1);
                EndMovement(EndPos);
                
            }

            RightPlatform= false;
        }
        else if (LeftPlatform == true)
            {
            transform.position = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)));
            if (MoveTime == 1)
            {
                LerpTime = 1;
                CurrentLerpTime = 0;
                input = true;
                Floating = true;
            }


            StartPos = gameObject.transform.position;

            EndPos = new Vector3((Mathf.RoundToInt(transform.position.x)) - 1, transform.position.y, transform.position.z);

            if (input == true)
            {
                //Moves Player to New End Position.
                CurrentLerpTime += Time.deltaTime * 5;
                MoveTime = CurrentLerpTime / LerpTime;
                gameObject.transform.position = Vector3.Lerp(StartPos, EndPos, MoveTime);


                //Checks to see if Movement is almost complete then Resets.
                if (MoveTime > 0.8)
                {
                    MoveTime = 1;
                }

                if (Mathf.Round(MoveTime) == 1)
                {
                    Floating = false;
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                LeftPlatform = false;
                EndPos = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)) + 1);
                EndMovement(EndPos);

            }

            LeftPlatform = false;
        }
    }

    //PLATFORMS MOVING GOING RIGHT

    //If Player Hits Enviroment or Side Walls.
    public void OnCollisionEnter(Collision Coll)
    {
        //If Player Hits Something Ahead.
        if (Coll.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            float Rounded = (Mathf.FloorToInt(transform.position.z));
            EndPos = new Vector3(transform.position.x, transform.position.y, Rounded);

            EndMovement(EndPos);
        }

        //If Player Hits Left Wall
        if (Coll.gameObject.layer == LayerMask.NameToLayer("LeftWall"))
        {
            float Rounded = (Mathf.CeilToInt(transform.position.x));
            EndPos = new Vector3(Rounded, transform.position.y, transform.position.z);

            EndMovement(EndPos);
        }

        //if Player Hits Right Wall.
        if (Coll.gameObject.layer == LayerMask.NameToLayer("RightWall"))
        {
            float Rounded = (Mathf.FloorToInt(transform.position.x));
            EndPos = new Vector3(Rounded, transform.position.y, transform.position.z);

            EndMovement(EndPos);
        }
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

        //Moves Player when any of the Movement Keys Are Pressed. Each Time The Player Moves, Rounds it to Integer to keep player On exact Blocks.
        if (Input.GetKeyDown(KeyCode.W))
        {
            EndPos = new Vector3(transform.position.x, transform.position.y, (Mathf.RoundToInt(transform.position.z)) + 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            EndPos = new Vector3((Mathf.RoundToInt(transform.position.x)) + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            EndPos = new Vector3((Mathf.RoundToInt(transform.position.x)) - 1, transform.position.y, transform.position.z);
        }

        EndMovement(EndPos);
        
    }

    public void EndMovement(Vector3 EndPos)
    {
        if (input == true)
        {
            //Moves Player to New End Position.
            CurrentLerpTime += Time.deltaTime * 5;
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
