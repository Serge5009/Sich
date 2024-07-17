using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSensitivity = 100.0f;
    public float moveSmoothingSpeed = 1.0f;
    public float mouseSensitivity = 100.0f;


    Vector3 moveSpeed;
    Vector3 moveTargetSpeed;
    void Start()
    {
        
    }

    void Update()
    {
        UpdateMove();
        UpdateRotation();
    }

    void UpdateMove()
    {

        //  Use keyboard to set the axis
        moveTargetSpeed = new();
        if (Input.GetKey(KeyCode.W))
            moveTargetSpeed.z += 1.0f;
        if (Input.GetKey(KeyCode.S))
            moveTargetSpeed.z -= 1.0f;
        if (Input.GetKey(KeyCode.D))
            moveTargetSpeed.x += 1.0f;
        if (Input.GetKey(KeyCode.A))
            moveTargetSpeed.x -= 1.0f;

        //  Lerp camera speed to the target
        moveSpeed = Vector3.Lerp(moveSpeed, moveTargetSpeed * moveSensitivity, moveSmoothingSpeed * Time.deltaTime);

        //  Apply speed
        transform.position += moveSpeed * Time.deltaTime;

    }

    float xRotation;
    float yRotation;
    void UpdateRotation()
    {
        //  If mouse button isn't pressed - skip rotation
        if(!Input.GetMouseButton(1))
        {
            return;
        }

        //  Mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; //  Getting mouse position for player
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime; //  Getting mouse position for camera

        xRotation -= mouseY;
        yRotation += mouseX;

        xRotation = Mathf.Clamp(xRotation, -80f, 80f);                              //  Limiting camera rotation
        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);     //  Rotating camera

        //transform.Rotate(Vector3.up * mouseX);                      //  Rotating camera horizontaly

    }
}
