using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float movementSpeed = 5.00f;
    public float mouseSensitivity = 5.00f;
    float verticalRotation = 0f; //will help with the vertical rotation of the camera  
    public float upDownRate = 60.0f;//sets the rate that the camera will max go to best is 80.  

    // Use this for initialization  
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;//This hiddes the mouse pointer
    }

    // Update is called once per frame
    void Update()
    {

        //rotation
        float rotationSide = Input.GetAxis("Mouse X") * mouseSensitivity;
        //float rotationUpDown = Input.GetAxis("Mouse Y") * mouseSensitivity; //you can't do it Like this, charactercontrollers don't pitch up and down! 
        transform.Rotate(0, rotationSide, 0);

        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        //float currentUpDown = Camera.main.transform.rotation.eulerAngles.x;
        //float desiredUpDown = currentUpDown - rotationUpDown;

        //Debug.Log(desiredUpDown);
        verticalRotation = Mathf.Clamp(verticalRotation, -upDownRate, upDownRate);

        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);

        //movement
        float forwardMoveSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float SideMoveSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        Vector3 speed = new Vector3(SideMoveSpeed, 0, forwardMoveSpeed); //puts both speeds in the speed variable

        speed = transform.rotation * speed;

        CharacterController cC = GetComponent<CharacterController>(); //create a new CharacterController

        cC.SimpleMove(speed);//apply speed to the characterController

    }
}
