﻿using UnityEngine;
using System.Collections;

public class EnemyChase : MonoBehaviour {

    private NavMeshAgent myAgent;
    public Transform target;

	// Use this for initialization
	void Start () {
        myAgent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        myAgent.SetDestination(target.position);
	}
}
