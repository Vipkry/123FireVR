using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour {

	public float lookDelayTime = 30;
	private float currentTime = 0;
	private bool isLooking = false;
	public GameObject playGameButton;

	void FixedUpdate () {
		if (isLooking){
			currentTime++;
		}

		if (currentTime >= lookDelayTime){
			if (gameObject.CompareTag(playGameButton.tag)){
				NewGame ();	
			}else {
				Application.Quit ();
			}
		}
	}


	public void NewGame (){
		SceneManager.LoadScene ("mainGame");
	}

	public void onReticleEnter(){
		isLooking = true;
	}

	public void onReticleExit (){
		currentTime = 0;
		isLooking = false;
	}
}
