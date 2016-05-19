using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadLevel(string _nameOfLevel){

        SceneManager.LoadScene(_nameOfLevel);
    }

    public void Quit(){

        Application.Quit();
    }
}
