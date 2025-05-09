using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;


public class PlayerCam : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;

    float xRotation;
    float yRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown("="))
        {
            sensX = sensX + 100f;
            sensY = sensY + 100f;
            Debug.Log("added");
        }
        if (Input.GetKeyDown("-"))
        {
            sensX = sensX + -100f;
            sensY = sensY + -100f;
            Debug.Log("subtracted");
        }

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;

        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.rotation = UnityEngine.Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation =  UnityEngine.Quaternion.Euler(0, yRotation, 0);
    }
}
