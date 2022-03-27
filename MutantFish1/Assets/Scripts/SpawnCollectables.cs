using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{
    public static SpawnCollectables instance; 

    [SerializeField] private GameObject DamageBuffPrefab;
    [SerializeField] private GameObject HealthBuffPrefab;
    [SerializeField] private GameObject ProtectionBuffPrefab;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void SpawnItem(int numOfItem, Vector3 position)
    {
        switch (numOfItem)
        {
            case 0:
                Instantiate(DamageBuffPrefab, position, transform.rotation);
                break;
            
            case 1:
                Instantiate(HealthBuffPrefab, position, transform.rotation);
                break;

            case 2:
                Instantiate(ProtectionBuffPrefab, position, transform.rotation);
                break;
        }
    }

   
}
