using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    public Light spotlight;

    public AudioSource audioSource;

    public AudioClip offSound;
    public AudioClip onSound;

    // Use this for initialization
    void Start () {
        spotlight.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
        
        bool F = Input.GetKeyDown(KeyCode.F);

        if (F && spotlight.enabled == false)//light on
        {
            spotlight.enabled = true;
            audioSource.PlayOneShot(onSound);
        }
        else if (F && spotlight.enabled == true)//light off
        {
            spotlight.enabled = false;
            audioSource.PlayOneShot(offSound);
        }
    }
}
