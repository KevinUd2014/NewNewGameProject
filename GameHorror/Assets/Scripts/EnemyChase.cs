using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

    public PauseMenu pauseMenu;

    private NavMeshAgent myAgent;
    public Transform target;

    private Animator myAnimator;

    public bool chaseTarget = true;
    public float stoppingDistance = 3.5f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCoolDown;

    private float distanceFromTarget;

    private PlayerHealth playerHealth;
    public int damage = 50;

    private float elapsedTime = 0;
    public float footstepsPerSecond;
    public float footstepsPerSecondSprint;
    public AudioSource footstep;
    public AudioSource whispers;

    // Use this for initialization
    void Start () {
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stoppingDistance;
        whispers.Play();
        whispers.loop = true;
        attackCoolDown = Time.time;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
        ChaseTarget();

        elapsedTime += Time.deltaTime;

        if (chaseTarget)
        {
            if (elapsedTime >= 1 / footstepsPerSecond)
            {
                footstep.Play();
                elapsedTime = 0;
            }
        }
        if(!chaseTarget)
        {
            footstep.Stop();
        }
        //myAgent.SetDestination(target.position);
    }

    void ChaseTarget()
    {
        distanceFromTarget = Vector3.Distance(target.position, transform.position);

        if(distanceFromTarget >= stoppingDistance)
        {
            chaseTarget = true;
        }
        else
        {
            chaseTarget = false;
            Attack();
        }

        if(chaseTarget)
        {
            myAgent.SetDestination(target.position);
            myAnimator.SetBool("isChasing", true);
        }
        else
        {
            myAnimator.SetBool("isChasing", false);
        }
    }
    void Attack()
    {
        if(Time.time > attackCoolDown)
        {
            playerHealth.TakeDamage(damage);
            //Debug.Log("Attack");
            myAnimator.SetTrigger("triggerAttack");
            attackCoolDown = Time.time + delayBetweenAttacks;
        }
    }
}
