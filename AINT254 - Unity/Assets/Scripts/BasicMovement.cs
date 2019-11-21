using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class BasicMovement : MonoBehaviour
{
    float LerpTime;
    float CurrentLerpTime;
    float MoveTime = 1;

    bool input;
    public bool Jumping;
    public bool Floating;
    public bool InAir = false;
    private bool Platform = false;
    private bool PlatformLeft = false;
    private bool OnFirstTime = true;
    private bool OnFirstTime2 = false;
    public Rigidbody rb;
    public float MoveSpeed = 10;

    //Locations Of Players Start and End Positions.
    Vector3 StartPos;
    Vector3 EndPos;

    void start()
    {
        rb = GetComponent<Rigidbody>();
        //bc = GetComponent<BoxCollider>();
    }
    void Update()
    {
        //This Is Called Every Frame, it is for movement of the Player.
        //Movement();
        RestartGame();
        PlatFormCollision();
    }

    public void OnPlatForm()
    {
        Platform = true;
    }

    public void OnPlatformLeft()
    {
        
        PlatformLeft = true;
    }

    //PLATFORMS MOVING GOING RIGHT
    public void PlatFormCollision()
    {

        if (Platform == false && PlatformLeft == false)
        {
            Movement();
        }
        else if (Platform == true)
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

            if (Input.GetKeyDown(KeyCode.W))
            {
                Platform = false;
                EndPos = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)) + 1);
                EndMovement(EndPos);
                
            }

            Platform = false;
        }
        else if (PlatformLeft == true)
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
                PlatformLeft = false;
                EndPos = new Vector3(transform.position.x, transform.position.y, (Mathf.CeilToInt(transform.position.z)) + 1);
                EndMovement(EndPos);

            }

            PlatformLeft = false;
        }
    }

    //PLATFORMS MOVING GOING RIGHT

    public void OnCollisionEnter(Collision Coll)
    {
        if (Coll.gameObject.layer == LayerMask.NameToLayer("Environment"))
        {
            float Rounded = (Mathf.FloorToInt(transform.position.z));
            EndPos = new Vector3(transform.position.x, transform.position.y, Rounded);

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

    public void RestartGame()
    {
        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("WORKS");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
