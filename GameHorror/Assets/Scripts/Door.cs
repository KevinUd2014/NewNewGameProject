using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool openDoor = false;//false = close true = open

    public float doorOpenAngle = 90f;

    public float doorClosedAngle = 0f;

    public float smooth = 2f; // speed of rotation, needed for unity function.1-100, slow-fast

    public void ChangeDoorState()
    {
        openDoor = !openDoor; // will be called for changing the door state!
    }
	// Update is called once per frame
	void Update () {

        if (openDoor)
        {//opens the door //advanced!
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
        }
	}
}
