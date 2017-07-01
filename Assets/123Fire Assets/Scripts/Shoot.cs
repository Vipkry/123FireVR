using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	

	public ParticleSystem rightParticleSystem;
	public ParticleSystem leftParticleSystem;
	private bool isLeftShooting;

	public float damage = 10f;
	public float blastRadius = 5f;
	public Transform crosshairTransform;
	public LayerMask enemyLayer;

	public AudioSource shootSoundSource;
	public AudioClip shootSoundClip;

	public int delayTime;
	private int actualDelayTime;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetMouseButtonDown(0) && actualDelayTime >= delayTime){
			if (isLeftShooting){
				leftParticleSystem.Play();
				shootSoundSource.panStereo = -0.3f;
				isLeftShooting = false;

			}else{
				rightParticleSystem.Play();
				shootSoundSource.panStereo = 0.3f;
				isLeftShooting = true;
			}
			castShooting ();
			actualDelayTime = 0;
			shootSoundSource.PlayOneShot (shootSoundClip);
		}
	}

	void FixedUpdate (){
		if (actualDelayTime < delayTime)
			actualDelayTime++;
	}

	private void castShooting(){

		Vector3 cameraPos = Camera.main.transform.position;
		Vector3 dir = crosshairTransform.position - cameraPos;
		Debug.DrawRay(cameraPos, dir * 100,  Color.red, 5);

		RaycastHit hit;
		Ray ray = new Ray (cameraPos, dir);


		if (Physics.Raycast(ray, out hit, 1000f)){
			// 9 é a layer dos inimigos
			Collider[] collisions = Physics.OverlapSphere (hit.point, blastRadius, enemyLayer.value);
			if (collisions.Length > 0){
				Debug.Log (collisions.Length + " targets hit!");
			}

		}

	}




}
