using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButton : MonoBehaviour {

	private int counter;
	public TextMesh counterText;

	// Use this for initialization
	void Start () {
		counter = 0;
		counterText.text = counter + "/3";
	}

	public void hit (){
		counter++;
		counterText.text = counter + "/3";
		if (counter == 3){
			SceneManager.LoadScene (0);
		}
	}
}
