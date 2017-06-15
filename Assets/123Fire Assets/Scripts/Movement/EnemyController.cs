using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public float spawntime = 2.0f;
	public Transform spawnArea;
	public GameObject[] enemyTypes;

	// enquanto o spawn não está feito 100%...
	void Start () {
		


	}
	


	void OnDrawGizmos(){

		Gizmos.DrawCube(this.transform.position, new Vector3(10,10,10));

	}


}
