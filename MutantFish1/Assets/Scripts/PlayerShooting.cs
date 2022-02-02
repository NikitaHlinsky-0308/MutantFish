using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireRate;
    private float nextFire = 0f;


    void Update()
    {
        firePoint.LookAt(CameraMovement.instance.targetLook);

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(prefab, firePoint.position, firePoint.rotation);
        }
    }

}
