using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float fireRate;
    private Transform firePoint;
    private float nextFire = 0f;


    private void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
    }

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