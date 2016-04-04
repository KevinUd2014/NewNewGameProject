using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

    public Light spotlight;
       
    // Use this for initialization
    void Start () {
        spotlight.enabled = false;
    }
	
	// Update is called once per frame
	void Update () {

        bool F = Input.GetKeyDown(KeyCode.F);

        if (F && spotlight.enabled == false)
        {
            spotlight.enabled = true;
        }
        else if (F && spotlight.enabled == true)
        {
            spotlight.enabled = false;
        }
    }
}
