using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPath1Follow : MonoBehaviour {

	public float speed = 2.5f;
	public Transform[] path1;
	public int currentPath = 0;

	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	public void Update() {

		// Cria um valor que é a distância entre o próximo waypoint que o inimigo segue e a sua posição atual, pra saber em que direção o inimigo está se movendo.
		float distance = Vector3.Distance (path1[currentPath].position, transform.position);
		// Abaixo é o movimento do objeto (no caso vai ser um inimigo). /posição do objeto a mover / checkpoint a chegar / velocidade.
		transform.position = Vector3.MoveTowards (transform.position, path1 [currentPath].position, Time.deltaTime * speed);

		// Se chegar a uma distancia do checkpoint, começar a ir pro próximo checkpoint.
		if (distance <= 0.5f) {
			currentPath++;
		}
	}

	void OnDrawGizmos(){

		if (path1.Length > 0) {

			for (int i = 0; i < path1.Length; i++) {
				if (path1 [i] != null) {
					// A próxima linha é a forma e o tamanho do checkpoint que o inimigo chega.
					Gizmos.DrawSphere (path1 [i].position, 0.5f);
				}
			}

		}

	}

}
