using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigS0> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;
    [SerializeField] Boolean isLooping;
    
    // [SerializeField] WaveConfigSO currentWave;
    WaveConfigS0 currentWave;

    void Start()
    {
        // SpawnEnemies();
        StartCoroutine(SpawnEnemyWaves());    
    }

    public WaveConfigS0 GetCurrentWave()
    {
        return currentWave;
    }
    
    // void SpawnEnemies()
    // {
    //     for(int i = 0; i < currentWave.GetEnemyCount(); i++)
    //     {
    //         Instantiate(currentWave.GetEnemyPrefab(i), 
    //                     currentWave.GetStartWaypoint().position,
    //                     Quaternion.identity,
    //                     transform);            
    //     }
    // }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach(WaveConfigS0 wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartWaypoint().position,
                        Quaternion.Euler(0, 0, 180), // enemy prefabs 이미지를 뒤집어서 여기서 180으로 다시 뒤집어서 spawn
                        transform
                    );

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
