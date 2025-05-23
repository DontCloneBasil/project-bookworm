using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX;
    public float senY;
    public Transform orientation;
    float xRotation;
    float yRotation;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; //locks mouse in center of the screen
        Cursor.visible = false; // turn mouse visibility off
    }
    // Update is called once per frame
    void Update()
    {
        // gets the mouse movent between now and the last update and multiplies that movement with sensitivity
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * senY;

        //set the desired rotation of the camera
        yRotation += mouseX;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // makes sure to adjust the x rotation to make sure it doesn't look to far up or down

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // applies camera rotation
        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // applies the y rotation to the orientation opject so the player moves where they look
    }
}









//base tutorial: https://www.youtube.com/watch?v=f473C43s8nE