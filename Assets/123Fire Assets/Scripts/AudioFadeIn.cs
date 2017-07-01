using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioFadeIn : MonoBehaviour {

	public float steps = 0.01f;
	public float maxVolume = 0.3f;
	private AudioSource myAudioSource;

	// Use this for initialization
	void Start () {
		myAudioSource = GetComponent<AudioSource> ();
		myAudioSource.volume = 0.01f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (myAudioSource.volume < maxVolume){
			myAudioSource.volume = myAudioSource.volume + steps;	
		}

	}
}
