using UnityEngine;
using System.Collections;

public class ScreamTrigger : MonoBehaviour {

    public Light spotlight;

    public AudioSource scareSoundScream;

    public AudioClip ScareSound;

    private bool doneScreamAudio;

    void OnTriggerEnter(Collider triggerEnter)
    {

        if (triggerEnter.CompareTag("Player") && doneScreamAudio == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            scareSoundScream.PlayOneShot(ScareSound);
            spotlight.enabled = false;
            doneScreamAudio = true;
        }
    }
}
