using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{

    public static WaveManager instance;

    [SerializeField] WaveSpawner Spawner;
    public int waves = 1;

    private int addittionHealth = 0;
    private bool healthAlreadySet;
    public bool spawnFinished;




    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Debug.LogError("Waves spawner duplicated", gameObject);
        }
    }

    private void Start()
    {
        UpdateUI();
    }

    public bool SpawnFinished
    {
        get
        {
            return spawnFinished;
        }
        set
        {
            spawnFinished = value;
        }
    }


    public void WaveHealthIncrease()
    {
        //if (EnemyManager.instance.enemies.Count >= 2)
        if (waves % 5 == 0) // || WaveManager.instance.waves > 5)
        { // первый иф работает на каждые 5 волн
            /*
                что нам надо от первого 
                    увеличивать хп каждую пятую волну
                    ставить хас в тру


                
                проблема - как держать увеличение хп после первого иф

             */

            healthAlreadySet = true;
            addittionHealth += 50;
            print("called every 5 waves" + healthAlreadySet + addittionHealth);
        }

        if (waves >= 5 && healthAlreadySet == true)
        {// второй работает последующие 5 и если установили has на тру
            /*
                что нам надо от второго 
                    присваивать хп каждую волну после пятой 
                    хас в фалс
             
             
             
             */
            print("called once " + healthAlreadySet);

            // * health = EnemyManager.instance.AdditionHealth;

            //health += addittionHealth;
            healthAlreadySet = false;
            print("called once " + healthAlreadySet);
        }

        if (spawnFinished == true)
        {
            for (int i = 0; i < Spawner.CountEnemy; i++)
            {
                Debug.Log("for works");
                //EnemyManager.instance.enemies[i].Health = addittionHealth;
                //EnemyManager.instance.enemies[i].GetComponent<Renderer>().material.SetColor("_Color", Color.blue) ;
            }

            SpawnFinished = false;
        }
    }

    public void UpdateUI()
    {
        UImanager.instance.waves.text = waves.ToString();
    }
}
