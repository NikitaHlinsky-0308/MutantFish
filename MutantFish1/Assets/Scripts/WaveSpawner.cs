using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private int countEnemy;
    //private int[] enemyCountArr = { 1, 2, 3, 4, 5 };
    [SerializeField] private float delay;


    void Start()
    {
        StartCoroutine(SpawnDelay(delay, countEnemy));
    }


    private void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

    private IEnumerator SpawnDelay(float delay, int enemies)
    {
        for (int i = 0; i < enemies; i++)
        {
            Spawn();
            yield return new WaitForSeconds(delay);
        }

        WaveManager.instance.SpawnFinished = true;
        Debug.Log("Finish of spawn");
    }

    public void NextWave()
    {
        ChangePrefab();
        StartCoroutine(SpawnDelay(delay, countEnemy));
    }

    private void ChangePrefab()
    {
        int waveCount = WaveManager.instance.waves;

        if (waveCount >= 6)
        {
            enemyPrefab = enemyPrefabs[1];
        }
        if (waveCount >= 11)
        {
            enemyPrefab = enemyPrefabs[2];
        }
        if (waveCount >= 16)
        {
            enemyPrefab = enemyPrefabs[3];
        }
        if (waveCount >= 21)
        {
            enemyPrefab = enemyPrefabs[4];
        }
        if (waveCount >= 26)
        {
            enemyPrefab = enemyPrefabs[5];
        }
        if (waveCount >= 31)
        {
            enemyPrefab = enemyPrefabs[6];
        }
        if (waveCount >= 36)
        {
            enemyPrefab = enemyPrefabs[7];
        }
        


    }

    public int CountEnemy
    {
        get 
        {
            return countEnemy;
        }
        set 
        { 
            countEnemy = value;

            if (countEnemy >= 5 || value >= 5)
            {
                print("setter if works");
                countEnemy = 5;
            }
        }
    }

}
