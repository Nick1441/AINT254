using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float speed = 10.0F;
    public float RotSpeed = 150.0F;

    //Setting Min & Maz For Ration Of Camera In Y. <-->
    public float minY = -30.0f;
    public float maxY = 30.0f;

    //Setting Min & Max For Rotation Of Camera In X. v ^
    public float minX = -30.0f;
    public float maxX = 30.0f;
    float forwardBackward;
    float leftRight;
    float RotLeftRight;
    float RotUpDown;
    Vector3 euler;

    void Start()
    {

    }


    void Update()
    {
        transform.localEulerAngles = euler;
        // Getting axes
        RotLeftRight = Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
        RotUpDown = Input.GetAxis("Mouse Y") * RotSpeed * Time.deltaTime;

        // Doing movements
        euler.x += -RotUpDown;

        euler.y += RotLeftRight;

        if (euler.x >= maxX)
            euler.x = maxX;
        if (euler.x <= minX)
            euler.x = minX;

        if (euler.y >= maxY)
            euler.y = maxY;
        if (euler.y <= minY)
            euler.y = minY;
    }
    //public float SpeedHor = 2.0f;
    //public float SpeedVer = 2.0f;

    //private float MoveH = 0.0f;
    //private float MoveV = 0.0f;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    Cursor.visible = false;
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    //transform.localEulerAngles = euler;

    //    MoveH += SpeedHor * Input.GetAxis("Mouse X");
    //    MoveV -= SpeedVer * Input.GetAxis("Mouse Y");

    //    transform.eulerAngles = new Vector3(MoveV, MoveH, 0.0f);
    //}
}
