using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public void LoadLevel(string _nameOfLevel){

        Time.timeScale = 1;
        SceneManager.LoadScene(_nameOfLevel);
    }

    public void Quit(){

        Application.Quit();
    }
    //public IEnumerator Wait()
    //{
    //    float fadeTime = GameObject.Find("NoteToSelf").GetComponent<Fading>().BeginFade(1);
    //    yield return new WaitForSeconds(fadeTime);
    //}
}
