using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour 
{
    public static int EnemiesAlive;

    public Wave[] waves;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    float countdown = 2f;

    public Text waveCountdownText;

    int waveIndex;  // default initialize to 0


    private void Update()
    {
        if (EnemiesAlive > 0) return;

        if (countdown <= 0f)
        {
            StartCoroutine("SpawnWave");
            countdown = timeBetweenWaves;
            return;
        }

        countdown -= Time.deltaTime;

        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }


    IEnumerator SpawnWave()
    {
        PlayerStats.Rounds++;

        Wave wave = waves[waveIndex];

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

		waveIndex++;

        if (waveIndex == waves.Length)
        {
            Debug.LogWarning("LEVEL WON");
            enabled = false;                // prevent waveIndex out of range
        }
    }


    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
        EnemiesAlive++;
    }
}
