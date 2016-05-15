﻿using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public bool openDoor = false;//false = close true = open

    public float doorOpenAngle = 90f;

    public float doorClosedAngle = 0f;

    private bool openCompletly;

    public float smooth = 2f; // speed of rotation, needed for unity function.1-100, slow-fast

    private AudioSource audioSource;
    public AudioClip opneningSound;

    public AudioClip lockedDoorSound;

    public bool isLocked = false;

    public bool front = false;
    public bool back = false;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();//gets the audiosource
    }

    public void ChangeDoorState()
    {
        if (isLocked != true)
        {
            openDoor = !openDoor; // will be called for changing the door state!

            if (audioSource != null)
            {
                audioSource.PlayOneShot(opneningSound);
            }
        }
        else
        {
            PlayLockedDoorSound();
        }
    }
    void PlayLockedDoorSound()
    {
        audioSource.PlayOneShot(lockedDoorSound);
    }
	// Update is called once per frame
	void Update () {
        
        if (openDoor)//openDoor)
        {//opens the door //advanced!
            Quaternion targetRotationOpen = Quaternion.Euler(0, doorOpenAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationOpen, smooth * Time.deltaTime);
            
        }
        else
        {
            Quaternion targetRotationClosed = Quaternion.Euler(0, doorClosedAngle, 0);
            transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotationClosed, smooth * Time.deltaTime);
            openCompletly = false;
        }
	}
}
