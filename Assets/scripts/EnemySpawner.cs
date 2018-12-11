using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject enemy;
    public GameObject spawnPoint;
    public int numberOfEnemie;

    [HideInInspector]
    public List<SpawnPoint> enemySpawnPoints;
    
    // Use this for initialization
	void Start () {
		//set random spawn points for enemies
        for(int i=0;i<numberOfEnemie;i++)
        {
            var spawnPosition = new Vector3(Random.Range(-8f, 8f), 0f, Random.Range(-8f, 8f));
            var spawnRotation = Quaternion.Euler(0f, Random.Range(0, 180), 0f);
            
            SpawnPoint enemySpawnPoint = (Instantiate(spawnPoint, spawnPosition, spawnRotation) as GameObject).GetComponent<SpawnPoint>();
            enemySpawnPoints.Add(enemySpawnPoint);

        }
	}
	
	
    public void SpawnEnemies(/*TODO:network*/)
    {
        foreach(SpawnPoint sp in enemySpawnPoints)
        {
            int i = 0;
            Vector3 position = sp.transform.position;
            Quaternion rotation = sp.transform.rotation;
            GameObject newEnemy = Instantiate<GameObject>(enemy, position, rotation);
            newEnemy.name = "enemy"+i;
            Health h = newEnemy.GetComponent<Health>();
            h.currentHealth = 100;
            h.OnChangeHealth();
            h.isEnemy = true;

            i++;
        }

    }
    
}
