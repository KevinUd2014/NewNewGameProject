using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

    public int maxHealth = 100;
    private int currentHealth;
	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
	}

    public void TakeDamage(int _damage)
    {
        currentHealth -= _damage;

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        //StartCoroutine(Wait()); //This should do something but don't work.
        SceneManager.LoadScene(2);
        Debug.Log("Game Over");
    }
    //public IEnumerator Wait()//don't work!
    //{
    //    float fadeTime = GameObject.Find("Player").GetComponent<Fading>().BeginFade(1);
    //    yield return new WaitForSeconds(fadeTime);
    //}
}
