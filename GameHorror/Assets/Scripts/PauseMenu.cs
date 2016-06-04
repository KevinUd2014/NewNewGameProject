using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public EnemyChase enemyChase;

    public GameObject pauseUI;

    public bool paused = false;

    public GameObject playerObject;
    public GameObject playerHeadBobing;

    void Start(){

        pauseUI.SetActive(false);
    }
    void Update(){
        
        if (Input.GetButtonDown("CancelMouse"))// && pauseUI == true && paused == true)
        {
            ResumeGame();
        }
        if (Input.GetButtonDown("Cancel"))// && pauseUI == false && paused == false)
        {
            Pause();
        }
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

        if (enemyChase != null)
        {
            enemyChase.whispers.Pause();
        }

        //enemyChase.whispers.Pause();
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

        if (enemyChase != null)
        {
            enemyChase.whispers.UnPause();
        }

        //enemyChase.whispers.UnPause();
    }
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void Save()
    {
        playerObject.GetComponent<Character>().Save();
        SavableMonoBehaviour.RootSave("Level", SceneManager.GetActiveScene().name);
        SavableMonoBehaviour.Save();
    }
    public void Quit()
    {
        Application.Quit();
    }
    //public IEnumerator Wait()
    //{
    //    float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
    //    yield return new WaitForSeconds(fadeTime);
    //}
}
