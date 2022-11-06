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
        // foreach(WaveConfigS0 wave in waveConfigs)
        // {
        //     currentWave = wave;
        //     for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        //     {
        //         Instantiate(currentWave.GetEnemyPrefab(i),
        //             currentWave.GetStartWaypoint().position,
        //             Quaternion.identity,
        //             transform
        //         );

        //         yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
        //     }
        //     yield return new WaitForSeconds(timeBetweenWaves);
        // }

        do
        {
            foreach(WaveConfigS0 wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(i),
                        currentWave.GetStartWaypoint().position,
                        Quaternion.identity,
                        transform
                    );

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
