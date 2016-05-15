using UnityEngine;
using System.Collections;

public class ScaryOpenDoor : MonoBehaviour {

    public bool openDoor;//false = close true = open
    public float doorOpenAngle = 90f;

    public Door door;
    public bool isLocked;

    public AudioSource audioSource;
    public float smooth = 2f;

    public AudioClip scareSound;
    private bool doneScreamAudio;

    // Use this for initialization

    public void Start()
    {
        openDoor = false;
        isLocked = false;
    }

    void ScaryDoorOpen()
    {
        Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
        transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
    }
    void OnTriggerEnter(Collider triggerEnter)
    {
        if (triggerEnter.CompareTag("Player") && doneScreamAudio == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            isLocked = false;
            audioSource.PlayOneShot(scareSound);
            ScaryDoorOpen();
            doneScreamAudio = true;
            openDoor = true;
        }
    }
    public void ChangeDoorState()
    {
        if (isLocked != true)
        {
            openDoor = !openDoor; // will be called for changing the door state!

            if (audioSource != null)
            {
                audioSource.PlayOneShot(scareSound);
            }
        }
        /*else
        {
            PlayLockedDoorSound();
        }*/
    }
}
