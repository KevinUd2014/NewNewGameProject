using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

    public Door myDoor;
    public AudioClip pickUpKeySound;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

	public void UnlockDoor()
    {
        myDoor.isLocked = false;
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
