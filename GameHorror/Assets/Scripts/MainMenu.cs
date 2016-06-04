using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public GameObject aboutUI;
    public GameObject controllerUI;
    public bool about = false;
    public bool controller = false;

    void Start()
    {
        aboutUI.SetActive(false);
        controllerUI.SetActive(false);

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    void Update()
    {
        if (Input.GetButtonDown("CancelMouse") && about)// && pauseUI == true && paused == true)
        {
            Time.timeScale = 1;
            about = false;
            aboutUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        if (Input.GetButtonDown("CancelMouse") && controller)// && pauseUI == true && paused == true)
        {
            Time.timeScale = 1;
            controller = false;
            controllerUI.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }

    public void ShowAboutScreen()
    {
        aboutUI.SetActive(true);
        Time.timeScale = 0;
        about = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void ShowControllScreen()
    {
        controllerUI.SetActive(true);
        Time.timeScale = 0;
        controller = true;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void NewGame()
    {
        LoadLevel("StartLevel1Real");
        SavableMonoBehaviour.Clear();
    }

    public void LoadLevel(string _nameOfLevel){

        Time.timeScale = 1;
        SceneManager.LoadScene(_nameOfLevel);
    }

    public void Load()//string _nameOfLevel
    {
        SavableMonoBehaviour.Load();
        string defaultLevel = "StartLevel1Real";
        string _nameOfLevel;

        if (!SavableMonoBehaviour.RootTryLoad("Level", out _nameOfLevel))
            _nameOfLevel = defaultLevel;

        LoadLevel(_nameOfLevel);
    }

    public void Quit(){

        Application.Quit();
    }
}
