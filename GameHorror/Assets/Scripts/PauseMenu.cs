using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pauseUI;

    private bool paused = false;

    public GameObject playerObject;
    public GameObject playerHeadBobing;

    void Start(){

        pauseUI.SetActive(false);
    }
    void Update(){
        
        if (Input.GetButtonDown("Cancel") && !pauseUI)
        {
            ResumeGame();
        }
        if (Input.GetButtonDown("Pause") && pauseUI)
        {
            Pause();
        }

            //if(Input.GetButtonDown("Pause"))
            //{
            //    paused = !paused;
            //}

            //if(paused)
            //{
            //    pauseUI.SetActive(true);
            //    Time.timeScale = 0;
            //    Pause();
            //}

            //if(!paused)
            //{
            //    pauseUI.SetActive(false);
            //    Time.timeScale = 1;
            //    ResumeGame();
            //}
        }

    public void Pause()
    {
        playerObject.GetComponent<Character>().enabled = false;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = false;

        pauseUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void ResumeGame()
    {
        playerObject.GetComponent<Character>().enabled = true;
        playerHeadBobing.GetComponent<BobbingHead>().enabled = true;

        pauseUI.SetActive(false);
        Time.timeScale = 1;
        paused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
