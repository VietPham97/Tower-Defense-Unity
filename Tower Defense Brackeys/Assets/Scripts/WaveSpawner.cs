﻿using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour 
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float countdown = 2f;

    int waveIndex;  // default initialize to 0


    private void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine("SpawnWave");
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
    }


    IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);  // TODO get rid of hard coding
        }
    }


    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
