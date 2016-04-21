using UnityEngine;
using System.Collections;

public class ScarePianoTrigger : MonoBehaviour {

    public GameObject painting;
    public AudioSource scareSoundPiano;

    public AudioClip ScareSound;

    private bool donePlayedAudio;

    void OnTriggerEnter(Collider triggerEnter){

        if (triggerEnter.CompareTag("Player") && donePlayedAudio == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            scareSoundPiano.PlayOneShot(ScareSound);
            painting.SetActive(true);
            donePlayedAudio = true;

        }
    }
}
