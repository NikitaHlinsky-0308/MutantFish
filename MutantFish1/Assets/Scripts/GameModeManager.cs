using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{

    [SerializeField] Life PlayerLife;
    [SerializeField] WaveSpawner Spawner;

    void Update()
    {
        if (EnemyManager.instance.enemies.Count == 0)
        {
            Spawner.CountEnemy += 2;

            Spawner.NextWave();   


        } else if (PlayerLife.amount <= 0)
        {
            print("Lose");
        }
    }
}
