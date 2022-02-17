using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int countEnemy;
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
            //Debug.Log("Spawn success");
            Spawn();
            yield return new WaitForSeconds(delay);
        }


    }

    public void NextWave()
    {
        StartCoroutine(SpawnDelay(delay, countEnemy));
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
        }
    }

}
