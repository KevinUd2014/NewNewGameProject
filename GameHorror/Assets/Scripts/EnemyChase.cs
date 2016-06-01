using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

    private NavMeshAgent myAgent;
    public Transform target;

    private Animator myAnimator;

    public bool chaseTarget = true;
    public float stoppingDistance = 3.5f;
    public float delayBetweenAttacks = 1.5f;
    private float attackCoolDown;

    private float distanceFromTarget;

	// Use this for initialization
	void Start () {
        myAgent = GetComponent<NavMeshAgent>();
        myAnimator = GetComponent<Animator>();
        myAgent.stoppingDistance = stoppingDistance;
        attackCoolDown = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        ChaseTarget();
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
            Debug.Log("Attack");
            myAnimator.SetTrigger("triggerAttack");
            attackCoolDown = Time.time + delayBetweenAttacks;
        }
    }
}
