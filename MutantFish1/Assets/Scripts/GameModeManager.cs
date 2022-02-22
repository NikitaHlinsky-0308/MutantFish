using System.Collections;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{

    [SerializeField] Life PlayerLife;
    [SerializeField] WaveSpawner Spawner;
    [SerializeField] private float WaveDelay;
    private bool corotineInProcess = false;
    
    

    void Update()
    {

        if (EnemyManager.instance.enemies.Count == 0 && corotineInProcess == false)
        {
            WaveManager.instance.waves += 1;
            
            if (WaveManager.instance.waves <= 5)
            {
                Spawner.CountEnemy++;
                
            } 

            

            StartCoroutine(NextWaveDelay(WaveDelay));

        } else if (PlayerLife.amount <= 0)
        {
            print("Lose");
        }
    }

    IEnumerator NextWaveDelay(float delay)
    {
        corotineInProcess = true;
        yield return new WaitForSeconds(delay);
        Spawner.NextWave();
        corotineInProcess = false;
    }

}
