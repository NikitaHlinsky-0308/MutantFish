using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float startTime, endTime, spawnRate;

    void Start()
    {
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("CancelInvoke", endTime);
    }


    
    void Update()
    {
        
    }

    private void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

}
