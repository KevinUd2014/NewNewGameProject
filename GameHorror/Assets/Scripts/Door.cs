﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Door : SavableMonoBehaviour {

    public bool openDoor = false;//false = close true = open

    public float doorOpenAngle = 90f;

    public float doorClosedAngle = 0f;

    private bool openCompletly;

    public float smooth = 2f; // speed of rotation, needed for unity function.1-100, slow-fast

    private AudioSource audioSource;
    public AudioClip opneningSound;

    public AudioClip lockedDoorSound;

    public Image lockedIcon;

    public bool isLocked = false;

    public bool front = false;
    public bool back = false;
    public float interval;

    public override void Start()
    {
        base.Start();
        audioSource = GetComponent<AudioSource>();//gets the audiosource
        lockedIcon.enabled = false;

        tryLoad("open", out openDoor);
    }

    //function to make text blink 
    public IEnumerator BlinkText()
    {
        //blinks it forever. You can set a terminating condition depending upon your requirement
        while (true)
        {
            //display “I AM FLASHING TEXT” for the next 0.5 seconds
            lockedIcon.enabled = true;
            yield return new WaitForSeconds(1.5f);

            lockedIcon.enabled = false;

            yield break;
        }
    }
    public void ChangeDoorState()
    {
        if (isLocked != true)
        {
            lockedIcon.enabled = false;
            openDoor = !openDoor; // will be called for changing the door state!

            save("open", openDoor);

            if (audioSource != null)
            {
                audioSource.PlayOneShot(opneningSound);
            }
        }
        else
        {
            PlayLockedDoorSound();
            StartCoroutine(BlinkText());
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
