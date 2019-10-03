using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
       
        //transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
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
