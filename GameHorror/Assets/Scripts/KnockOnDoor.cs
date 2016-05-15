using UnityEngine;
using System.Collections;

public class KnockOnDoor : MonoBehaviour {

    public Light spotlight;

    public AudioSource scareSoundKnock;

    public AudioClip scareSound;

    private bool doneScreamAudio;

    void OnTriggerEnter(Collider triggerEnter)
    {

        if (triggerEnter.CompareTag("Player") && doneScreamAudio == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            scareSoundKnock.PlayOneShot(scareSound);
            spotlight.enabled = false;
            doneScreamAudio = true;
        }
    }
}
