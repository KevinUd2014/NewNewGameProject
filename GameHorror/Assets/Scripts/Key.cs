using UnityEngine;
using System.Collections;
using System;

public class Key : SavableMonoBehaviour {

    public Door myDoor;
    public AudioClip pickUpKeySound;
    public AudioSource audioSource;

    public override void Start()
    {
        base.Start();
        bool taken = false;

        if (tryLoad("taken", out taken) && taken)
        {
            unlockDoor();
        }
        
        audioSource = GetComponent<AudioSource>();
    }

	public void UnlockDoor()
    {
        audioSource.PlayOneShot(pickUpKeySound);

        save("taken", true);
        StartCoroutine("WaitForSelfDestruct");//works as a function
    }

    IEnumerator WaitForSelfDestruct()//makes a countdown awailable
    {
        yield return new WaitForSeconds(pickUpKeySound.length);//will not destroy before the sound is finished.
        unlockDoor();
    }

    private void unlockDoor()
    {
        myDoor.isLocked = false;
        Destroy(gameObject);
    }
}
