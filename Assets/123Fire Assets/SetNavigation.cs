using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SetNavigation : MonoBehaviour {

	private NavMeshAgent myagent;
	public Transform target;

	// Use this for initialization
	void Start () {
		myagent = gameObject.GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		myagent.SetDestination (target.position);
	}
}
