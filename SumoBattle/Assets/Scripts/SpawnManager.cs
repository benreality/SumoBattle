using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float range = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject powerUps;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemyWave(waveNumber);
        Instantiate(powerUps, randomPos(), powerUps.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerUps, randomPos(), powerUps.transform.rotation);
        }
    }

    private Vector3 randomPos()
    {
        float spawnX = Random.Range(-range, range);
        float spawnZ = Random.Range(range, range);
        Vector3 spawnRange = new Vector3(spawnX, 0, spawnZ);
        return spawnRange;
    }

    void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 1; i <= enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, randomPos(), enemyPrefab.transform.rotation);
        }
    }

}
