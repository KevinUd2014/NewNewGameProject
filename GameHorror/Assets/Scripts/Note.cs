using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Note : MonoBehaviour {

    public Image noteImage;
    public GameObject HideButton;

    public AudioClip pickingUpSound;
    public AudioClip putAwaySound;
    
    public GameObject playerObject;
    public GameObject playerHeadBobing;

    // Use this for initialization
    void Start () {

        noteImage.enabled = false;
        HideButton.SetActive(false);// button not available
    }
    
    void Update()
    {
        if (noteImage.enabled)
        {
            Time.timeScale = 0;
            playerObject.GetComponent<Character>().enabled = false;
            playerHeadBobing.GetComponent<BobbingHead>().enabled = false;

            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("CancelMouse") && noteImage.enabled)
        {
            noteImage.enabled = false;
            HideButton.SetActive(false);// button not available
            Time.timeScale = 1;
            GetGoingCharacter();

            if (noteImage.enabled == true) {
                GetComponent<AudioSource>().PlayOneShot(putAwaySound);
            }
        }
    }
	public void ShowNoteImage()
    {
        noteImage.enabled = true;
        GetComponent<AudioSource>().PlayOneShot(pickingUpSound);

        HideButton.SetActive(true);// button available
        Time.timeScale = 0;

        playerObject.GetComponent<Character>().enabled = false;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = false;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void HideNoteImage()
    {
        noteImage.enabled = false;
        

        HideButton.SetActive(false);// button not available
        Time.timeScale = 1;

        GetGoingCharacter();
    }
    private void GetGoingCharacter()
    {
        GetComponent<AudioSource>().PlayOneShot(putAwaySound);
        playerObject.GetComponent<Character>().enabled = true;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}
