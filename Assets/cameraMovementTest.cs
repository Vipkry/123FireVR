using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.position = new Vector3 (transform.position.x + 1f, transform.position.y + 1f, transform.position.z + 1f);
	}
}
