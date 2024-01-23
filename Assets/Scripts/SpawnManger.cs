using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    public GameObject prefabEnemy;
    private float zSpawnRangeMin = 9;
    private float xSpawnRangeMin = 16.3f;
    private float zSpawnRangeMax = 9.5f;
    private float xSpawnRangeMax = 16.8f;
    public int enemyCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(enemyCount);
    }

    // Update is called once per frame
    void Update()
    {
        int enemyAmount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (enemyAmount == 0 )
        {
            SpawnEnemyWave(enemyCount);
        }
    }

    Vector3 GenerateSpawnPosition()
    {
        float xPos = Random.Range(Random.Range(xSpawnRangeMin, xSpawnRangeMax), Random.Range(-xSpawnRangeMin, -xSpawnRangeMax));
        float zPos = Random.Range(Random.Range(zSpawnRangeMin, zSpawnRangeMax), Random.Range(-zSpawnRangeMin, -zSpawnRangeMax));
        return new Vector3(xPos, 0, zPos);
    }

    void SpawnEnemyWave(int enemyCount)
    {
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(prefabEnemy, GenerateSpawnPosition(), prefabEnemy.transform.rotation);
        }
    }
}
