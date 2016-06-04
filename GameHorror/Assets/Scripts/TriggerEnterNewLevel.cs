using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TriggerEnterNewLevel : MonoBehaviour {
    
    void OnTriggerEnter(Collider triggerEnter)
    {
        if (triggerEnter.CompareTag("Player"))//checks if the object is player and if the sound hasn't been played yet!
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(3);
        }
    }
}
