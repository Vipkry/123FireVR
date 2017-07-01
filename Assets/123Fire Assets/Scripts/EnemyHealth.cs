using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {

	public float health = 200f;
	public Material defaultEnemy;
	public Material takingDamageEnemy;
	private bool changeMaterial;
	private int tookDamageDelay;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (tookDamageDelay > 0){
			tookDamageDelay--;
		}else {
			if (changeMaterial){
				changeMaterial = false;
				GetComponentInChildren<MeshRenderer> ().material = defaultEnemy;
			}
		}
	}

	public void takeDamage (float damage){
		this.health -= damage;
		GetComponentInChildren<MeshRenderer> ().material = takingDamageEnemy;
		tookDamageDelay = 5;
		changeMaterial = true;
		if (this.health <= 0){
			GameObject.Destroy (gameObject);
		}
	}
}
