using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	public float lookDelayTime = 30;
	private float currentTime = 0;
	private bool isLooking = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (isLooking){
			currentTime++;
			Debug.Log (currentTime);
		}

		if (currentTime >= lookDelayTime){
			NewGame ();
		}
	}


	public void NewGame (){
		Debug.Log ("entered");
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
