using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SimpleSpawner : MonoBehaviour {

    // Use this for initialization

    public float timeBetweenWaves = 5f;
    public float timeBetweenSpawn;
    public int waveNumber = 0;

    public int enemiesLeft;
    public int playerScore;

    public int baseLife;

    public TextMesh score;
    public TextMesh currentWave;
    public TextMesh lifeText;

    bool hasEnemies = false;


    //Tamanho de cada wave
    public int[] spawnTable = {10, 20, 35, 50, 70, 80, 100 };

    protected WaypointManager myWaypoint;
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    
	void Start () {
        playerScore = 0;
        myWaypoint = GetComponent<WaypointManager>();
        enemiesLeft = 0;
        baseLife = 3;
        timeBetweenSpawn = 3.15f;
    }

    private void FixedUpdate()
    {
        
        /*
        if(baseLife == 0)
        {
            TODO: Game Over
        }
        */

        if (enemiesLeft == 0 && !hasEnemies)
        {
            hasEnemies = true;
            StartCoroutine(spawnWave());

            // código abaixo acelera velocidade do spawn.
            if (timeBetweenSpawn >= 1.15f)
            {
                timeBetweenSpawn -= 0.15f;
            }

            waveNumber++;
        }
        showScore();
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

    private void showScore()
    {
        score.text = "score: " + playerScore.ToString();

        currentWave.text = "wave: " + waveNumber.ToString();
        lifeText.text = "base HP: " + baseLife.ToString();
		if (baseLife < 5){
			lifeText.color = Color.red;
		}

    }

}
