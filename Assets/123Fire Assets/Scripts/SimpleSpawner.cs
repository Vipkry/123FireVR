using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour {

    // Use this for initialization

    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawn = 3f;
    public int waveNumber = 0;
    public int enemiesLeft;

    bool hasEnemies = false;


    //Tamanho de cada wave
    public int[] spawnTable = {10, 20, 35, 50, 70, 80, 100 };

    protected WaypointManager myWaypoint;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
	void Start () {
        myWaypoint = GetComponent<WaypointManager>();
        enemiesLeft = 0;
	}

    private void Update()
    {
        
        if(enemiesLeft == 0 && !hasEnemies)
        {
            hasEnemies = true;
            StartCoroutine(spawnWave());
            waveNumber++;
        }
    }

    private IEnumerator spawnWave()
    {

        yield return new WaitForSeconds(timeBetweenWaves);

        for(int i = 0; i < decideEnemyNumber(); i++)
        {
            spawnEnemy();
            enemiesLeft++;
            yield return new WaitForSeconds(timeBetweenSpawn);
        }

        hasEnemies = false;

    }

    private void spawnEnemy()
    {
        myWaypoint.AddEntity((GameObject)Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation));
    }

    private int decideEnemyNumber()
    {
        if(waveNumber-1 < spawnTable.Length  )
        {
            return (spawnTable[waveNumber-1]);
        } else
        {
            return spawnTable[spawnTable.Length - 1] + 3 * waveNumber;
        }
        
    }

}
