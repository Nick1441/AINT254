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

    void Update()
    {
        //Getting rotation into Euler
        transform.localEulerAngles = euler;
        //Getting Input from the mouse.
        RotLeftRight = Input.GetAxis("Mouse X") * RotSpeed * Time.deltaTime;
        RotUpDown = Input.GetAxis("Mouse Y") * RotSpeed * Time.deltaTime;

        euler.x += -RotUpDown;

        euler.y += RotLeftRight;

        // Seeing if the movement extands over the certain amount. if it does, set it back to the limit.
        if (euler.x >= maxX)
            euler.x = maxX;
        if (euler.x <= minX)
            euler.x = minX;

        if (euler.y >= maxY)
            euler.y = maxY;
        if (euler.y <= minY)
            euler.y = minY;
    }
}
