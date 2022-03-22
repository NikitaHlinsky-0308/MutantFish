using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private Transform cam, gun;
    [SerializeField] private int health = 2;
    [SerializeField] private Sprite[] healthBarImages;

    [SerializeField] private float oxygenAmount;
    [SerializeField] private float oxygenReducingRate;
    [SerializeField] private float oxygenIncreaseRate;
    private float currentOxygen;
    private Gun weapon;

    Animator anim;

    private void Awake()
    {
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
        instance = this;
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        currentOxygen = oxygenAmount;
        UpdateUI();
    }

    void Update()
    {
        SubtrackOxygen(oxygenReducingRate * Time.deltaTime);
        UpdateOxygenUI();


        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 Movement = cam.transform.right * Horizontal + cam.transform.forward * Vertical;
        Movement.y = 0f;

        gun.transform.localRotation = Quaternion.Euler(new Vector3(cam.transform.rotation.eulerAngles.x, 0, 0));
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * CameraMovement.instance.sensivity * Time.deltaTime);
        controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            Movement.Normalize();

            Quaternion CamRotation = cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }


        LocomotionAnim();
    }

    private void LocomotionAnim()
    {
        float velocityZ = Input.GetAxis("Vertical");
        float velocityX = Input.GetAxis("Horizontal");

        anim.SetFloat("VelocityX", velocityX, 0.1f, Time.deltaTime);
        anim.SetFloat("VelocityZ", velocityZ, 0.1f, Time.deltaTime);
    }

    public float Speed
    {
        get
        {
            return speed;
        }
        set
        {
            speed = value;
        }
    }

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }

    public void UpdateUI()
    {
        UImanager.instance.oxygenSlider.value = currentOxygen;

        switch (health)
        {
            case 0:
                UImanager.instance.healthImage.sprite = healthBarImages[0];
                break;
            case 1:
                UImanager.instance.healthImage.sprite = healthBarImages[1];
                break;
            case 2:
                UImanager.instance.healthImage.sprite = healthBarImages[2];
                break;
        }

    }

    public void UpdateOxygenUI()
    {
        UImanager.instance.oxygenSlider.value = currentOxygen;
    }

    public void AddOxygen(float amount)
    {
        currentOxygen = Mathf.Min(currentOxygen + amount, oxygenAmount);
    }

    public void SubtrackOxygen(float amount)
    {
        currentOxygen = Mathf.Max(currentOxygen - amount, 0);
    }

    private void OnTriggerEnter(Collider other)
    {

        switch (other.tag)
        {
            case "DamageBuff":
                StartCoroutine(DamageBuff(3));
                Destroy(other.gameObject);
                break;

            case "HealthBuff":
                Health = 2;
                UpdateUI();
                Destroy(other.gameObject);
                break;

            case "ProtectionBuff":
                //StartCoroutine();
                break;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "OxySupplier")
        {
            AddOxygen(oxygenIncreaseRate * Time.deltaTime);
            print("triggered");
        }
    }

    IEnumerator DamageBuff(float amount)
    {
        int defaultDmg = weapon.Damage;
        weapon.Damage = weapon.Damage * 4;

        yield return new WaitForSeconds(amount);
        
        weapon.Damage = defaultDmg;
    }
    IEnumerator ProtectionBuff(float amount)
    {
        

        yield return new WaitForSeconds(amount);

        
    }

}
    /*
    
    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * z + transform.right * x;
        moveDirection.Normalize();


        
        controller.Move(moveDirection * Time.deltaTime * speed);
        moveDirection.y = 0;

        transform.localRotation = Quaternion.Euler(new Vector3(0, cam.transform.rotation.eulerAngles.y, 0));
        //PlayerRotation(moveDirection);
        GunRotation();
    }

    private void PlayerRotation(Vector3 target)
    {
        //transform.LookAt(transform.position + target);

    }

    private void GunRotation()
    {
        gun.transform.localRotation = Quaternion.Euler(new Vector3(cam.transform.rotation.eulerAngles.x, 0, 0));
    }

     
    public void GetMoveInput(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
     
     
     
     
     
     
     
     
    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            transform.position += new Vector3(0, 0, 5);
            Debug.Log("CTRL is pressed");
        }
    }

    void CameraLook()
    {
        //rotation.y += Input.GetAxis("Mouse X");
        //rotation.x += -Input.GetAxis("Mouse Y");
        //transform.eulerAngles = (Vector2)rotation * camSpeed;

    }

    public void OnFire(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Vector3 forward = cam.transform.forward;
            forward.y = 0;
            forward.Normalize();
            PlayerRotation(forward);

            Vector2 center = new Vector2(Screen.width / 2, Screen.height / 2);
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(center);

            Debug.DrawRay(firePoint.transform.position, ray.direction * 100, Color.red, 2);

            if (Physics.Raycast(ray, out hit, 200.0f))
            {
                GameObject newProjectile = Instantiate(vfx, firePoint.transform.position, firePoint.transform.rotation);

                newProjectile.GetComponent<Rigidbody>().velocity = (hit.point - transform.position).normalized * bulletSpeed;

                Debug.Log(hit.transform.name);
            }
            //SpawnProjectiles.instance.SpawnVFX();
        }
    }
     
     */


