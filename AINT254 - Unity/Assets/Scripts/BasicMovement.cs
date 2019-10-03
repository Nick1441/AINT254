using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    float LerpTime;
    float CurrentLerpTime;
    float Perc = 1;

    Vector3 StartPos;
    Vector3 EndPos;
    Vector3 HELLO;
    
    void Update()
    {
        Movement();
       
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    public void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (Perc == 1)
            {
                LerpTime = 1;
                CurrentLerpTime = 0;
            }
        }

        StartPos = gameObject.transform.position;
        EndPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.W))
        {   
            Debug.Log("HELLO");
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

        CurrentLerpTime += Time.deltaTime * 5.5f;
        Perc = CurrentLerpTime / LerpTime;
        gameObject.transform.position = Vector3.Lerp(StartPos, EndPos, Perc);
    }


    public void Move()
    {

        if (Input.GetKey(KeyCode.W))
        {
            Debug.Log("Test");
            Vector3 MoveVec = this.transform.position;
            MoveVec.z = MoveVec.z + 1;
            this.transform.position = MoveVec;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Vector3 MoveVec = this.transform.position;
            MoveVec.x = MoveVec.x - 1;
            this.transform.position = MoveVec;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Vector3 MoveVec = this.transform.position;
            MoveVec.x = MoveVec.x += 1;
            this.transform.position = MoveVec;
        }
    }
}
