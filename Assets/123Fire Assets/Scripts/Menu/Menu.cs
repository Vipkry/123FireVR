using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public float lookDelayTime = 30;
	private float currentTime = 0;
	private bool isLooking = false;
	public Slider slider;
	
	// Update is called once per frame
	void FixedUpdate () {
		if (isLooking){
			currentTime++;
			slider.value = currentTime / lookDelayTime;

		}

		if (currentTime >= lookDelayTime){
			NewGame ();
		}
	}


	public void NewGame (){
		SceneManager.LoadScene ("mainGame");
	}

	public void onReticleEnter(){
		slider.gameObject.SetActive (true);
		isLooking = true;
	}

	public void onReticleExit (){
		slider.value = 0;
		slider.gameObject.SetActive (false);
		currentTime = 0;
		isLooking = false;
	}
}
