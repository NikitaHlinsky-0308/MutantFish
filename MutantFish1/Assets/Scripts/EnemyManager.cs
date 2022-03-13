using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    public List<EnemyController> enemies;
    public int additionHealth = 100;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Enemy manager duplicated", gameObject);
        }
    }

    public int AdditionHealth
    {
        get
        {
            return additionHealth;
        }
        set
        {
            additionHealth = value;
        }
    }

}
