using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class safeDoor : MonoBehaviour {

    public Canvas safeUI;
    public GameObject playerObject;
    public GameObject playerHeadBobing;

	// Use this for initialization
	void Start () {
        safeUI.enabled = false;
	}

    public void ShowSafeCanvas()
    {
        safeUI.enabled = true;
        //disables the player = no movement
        playerObject.GetComponent<Character>().enabled = false;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Cancel"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            playerObject.GetComponent<Character>().enabled = true;
            playerHeadBobing.GetComponent<BobbingHead>().enabled = true;
            safeUI.enabled = false;
        }
	}
}
