using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float SpeedHor = 2.0f;
    public float SpeedVer = 2.0f;

    private float MoveH = 0.0f;
    private float MoveV = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        MoveH += SpeedHor * Input.GetAxis("Mouse X");
        MoveV -= SpeedVer * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(MoveV, MoveH, 0.0f);
    }
}
