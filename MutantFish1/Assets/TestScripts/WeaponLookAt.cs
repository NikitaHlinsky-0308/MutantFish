using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponLookAt : MonoBehaviour
{
    public GameObject weapon;
    public Transform target;



    
    void Update()
    {
        weapon.transform.LookAt(target);
    }
}
