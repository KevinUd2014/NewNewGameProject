using UnityEngine;
using System.Collections;

public class PlayerEnterSafeZone : MonoBehaviour {

    public AudioSource audioSource;

    public EnemyHealth ghoul;

    public AudioClip exhaustSound;

    private bool doneExhaust;

    void OnTriggerEnter(Collider triggerEnter)
    {

        if (triggerEnter.CompareTag("Player") && doneExhaust == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            audioSource.PlayOneShot(exhaustSound);
            doneExhaust = true;
            ghoul.Die();
        }
    }
}
