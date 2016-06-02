using UnityEngine;
using System.Collections;

public class TwoDoorsOpen : MonoBehaviour {

    public Door myDoor;
    public Door BAtchroom;
    public AudioClip pickUpKeySound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void UnlockDoor()
    {
        myDoor.isLocked = false;
        BAtchroom.isLocked = false;
        audioSource.PlayOneShot(pickUpKeySound);

        StartCoroutine("WaitForSelfDestruct");//works as a function
        //Destroy(gameObject);
    }

    IEnumerator WaitForSelfDestruct()//makes a countdown awailable
    {
        yield return new WaitForSeconds(pickUpKeySound.length);//will not destroy before the sound is finished.
        Destroy(gameObject);
    }
}
