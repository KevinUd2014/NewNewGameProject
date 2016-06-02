using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour {

    public int maxHealth = 100;
    private int currentHealth;

    private Animator animator;

	// Use this for initialization
	void Start () {

        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
	}
	
    public void TakingDamage(int _damage)
    {
        currentHealth -= _damage;

        animator.SetTrigger("isHit");

        if(currentHealth <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
