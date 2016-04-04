using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {

    public float movementSpeed = 5.00f;
    public float mouseSensitivity = 5.00f;
    float verticalRotation = 0f; //will help with the vertical rotation of the camera  
    public float upDownRate = 60.0f;//sets the rate that the camera will max go to best is 80.  
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

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
        CharacterController cC = GetComponent<CharacterController>(); //create a new CharacterController

        if (cC.isGrounded)
        {
            //float forwardMoveSpeed = Input.GetAxis("Vertical") * movementSpeed;
            //float SideMoveSpeed = Input.GetAxis("Horizontal") * movementSpeed;
            //Vector3 speed = new Vector3(SideMoveSpeed, 0, forwardMoveSpeed); //puts both speeds in the speed variable
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        cC.Move(moveDirection * Time.deltaTime);
        // if (Input.GetButton("Jump"))
        // {

        //transform.position += transform.up, jumpSpeed, Time.deltaTime;
        //transform.Translate(speed * Time.deltaTime, Space.World);
        // }

        // speed = transform.rotation * speed;

        // cC.SimpleMove(speed);//apply speed to the characterController takes care of gravity for you!

    }
}
