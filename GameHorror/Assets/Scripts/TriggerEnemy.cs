using UnityEngine;
using System.Collections;

public class TriggerEnemy : MonoBehaviour {

    public GameObject enemyTrigger;

    public GameObject ghoul;//reference to the ghoulanimation
    public GameObject ghoulWorldModel; //theghould in bath

    public AudioSource scareSoundSource;

    public AudioClip scareSound;

    private bool doneScreamAudio;

    void OnTriggerEnter(Collider triggerEnter)
    {

        if (triggerEnter.CompareTag("Player") && doneScreamAudio == false)//checks if the object is player and if the sound hasn't been played yet!
        {
            scareSoundSource.PlayOneShot(scareSound);
            ghoul.SetActive(true);
            enemyTrigger.SetActive(true);
            ghoulWorldModel.SetActive(false);
            doneScreamAudio = true;
        }
    }
}
