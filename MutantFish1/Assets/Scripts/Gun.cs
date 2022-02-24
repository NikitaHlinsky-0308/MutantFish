using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float fireRate;
    [SerializeField] private int damage;
    private Transform firePoint;
    private float nextFire = 0f;


    private void Start()
    {
        firePoint = GameObject.FindGameObjectWithTag("FirePoint").transform;
        if (firePoint == null)
        {
            Debug.Log("fire point has been not found");
        }
    }

    void Update()
    {
        firePoint.LookAt(CameraMovement.instance.targetLook);

        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate(prefab, firePoint.position, firePoint.rotation);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            //UpgradeWeaponFireRate();
            UpgradeWeaponDamage();
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public void UpgradeWeaponFireRate()
    {
        fireRate += 0.3f;
    }

    public void UpgradeWeaponDamage()
    {
        damage += 50;
    }
}
