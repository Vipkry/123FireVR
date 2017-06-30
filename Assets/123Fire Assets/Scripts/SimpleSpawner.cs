using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour {

    // Use this for initialization

    public int spawnedEnemies;
    private float spawnDowntime;
    int[] waveSize = { 2, 3 };
    protected WaypointManager myWaypoint;

    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
	void Start () {
        StartCoroutine(spawnCoroutine());
        spawnedEnemies = 0;
        spawnDowntime = 3.0f;
        myWaypoint = GetComponent<WaypointManager>();
	}

    IEnumerator spawnCoroutine()
    {
        while (true)
        {
            do
            {
                yield return new WaitForSecondsRealtime(spawnDowntime);
            } while (spawnedEnemies >= 10);

            myWaypoint.AddEntity((GameObject)Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation));
            spawnedEnemies = spawnedEnemies + 1;
        
        }

    }

}
