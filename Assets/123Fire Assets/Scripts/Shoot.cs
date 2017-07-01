using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
	
	public float damage = 10f;
	public ParticleSystem rightParticleSystem;
	public ParticleSystem leftParticleSystem;
	private bool isLeftShooting;

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
			actualDelayTime = 0;
			shootSoundSource.PlayOneShot (shootSoundClip);
				
		}

	}

	void FixedUpdate (){
		if (actualDelayTime < delayTime)
			actualDelayTime++;
	}


}
