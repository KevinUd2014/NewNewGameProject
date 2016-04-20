using UnityEngine;
using System.Collections;

[RequireComponent (typeof(CharacterController))]// make it so that we need a Character controller in our game in order for it to run!
public class Character : MonoBehaviour {

    public float movementSpeed = 5.00f;
    public float mouseSensitivity = 5.00f;
    float verticalRotation = 0f; //will help with the vertical rotation of the camera  
    public float upDownRate = 60.0f;//sets the rate that the camera will max go to best is 80.  
    public float jumpSpeed = 1.0f;
    public float gravity = 20.0f;
    public float runSpeed = 3.0f;
    public AudioSource footstep;
    public AudioSource footstepSprint;
    private Vector3 moveDirection = Vector3.zero;

    CharacterController cC;

    float verticalVelocity = 0;

    private float elapsedTime = 0;
    public float footstepsPerSecond;
    public float footstepsPerSecondSprint;

    // Use this for initialization  
    void Start()
    {
        //Cursor.lockState = CursorLockMode.Locked;//This hiddes the mouse pointer
        //footstep = GetComponent<AudioSource>();
        cC = GetComponent<CharacterController>(); //create a new CharacterController
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

        //test-----------------------------------------------------------
        float forwardMoveSpeed = Input.GetAxis("Vertical") * movementSpeed;
        float SideMoveSpeed = Input.GetAxis("Horizontal") * movementSpeed;

        elapsedTime += Time.deltaTime;

        verticalVelocity += Physics.gravity.y * Time.deltaTime;
        if(forwardMoveSpeed != 0 && cC.isGrounded || SideMoveSpeed != 0 && cC.isGrounded)
        {
            if(elapsedTime >= 1/footstepsPerSecond)
            {
                footstep.Play();
                elapsedTime = 0;
            }
            
        }
        if(cC.isGrounded && Input.GetButtonDown("Jump") ){

            verticalVelocity = jumpSpeed;
        }
        if (Input.GetKey(KeyCode.LeftShift)) //this checks to see if the player is holding left shif
        {
            footstep.Stop();
            if (elapsedTime >= 1 / footstepsPerSecondSprint)
            {
                footstepSprint.Play();
                elapsedTime = 0;
            }
            forwardMoveSpeed = Input.GetAxis("Vertical") * movementSpeed + runSpeed; //this increases our speed by the multiplier
        }

        Vector3 speed = new Vector3(SideMoveSpeed, verticalVelocity, forwardMoveSpeed); //puts both speeds in the speed variable

        speed = transform.rotation * speed;

        cC.Move(speed * Time.deltaTime);
        //---------------------------------------------------------------
        /*if (cC.isGrounded)
        {
            
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= movementSpeed;
            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;

        }
        moveDirection.y -= gravity * Time.deltaTime;
        cC.Move(moveDirection * Time.deltaTime);*/

        //transform.position += transform.up, jumpSpeed, Time.deltaTime;
        //transform.Translate(speed * Time.deltaTime, Space.World);
        // }

        // speed = transform.rotation * speed;

        // cC.SimpleMove(speed);//apply speed to the characterController takes care of gravity for you!

    }
}
