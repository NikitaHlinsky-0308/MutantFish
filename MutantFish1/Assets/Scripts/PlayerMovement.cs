using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public static PlayerMovement instance;

    [SerializeField] private CharacterController controller;
    [SerializeField] private float speed;
    [SerializeField] private Transform cam, gun;

    Animator anim;

    private void Awake()
    {
        instance = this;
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float Horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float Vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 Movement = cam.transform.right * Horizontal + cam.transform.forward * Vertical;
        //Vector3 Movement = new Vector3(Vertical, 0.0f, Horizontal);
        Movement.y = 0f;

        gun.transform.localRotation = Quaternion.Euler(new Vector3(cam.transform.rotation.eulerAngles.x, 0, 0));
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * CameraMovement.instance.sensivity * Time.deltaTime);
        controller.Move(Movement);

        if (Movement.magnitude != 0f)
        {
            Quaternion CamRotation = cam.rotation;
            CamRotation.x = 0f;
            CamRotation.z = 0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, CamRotation, 0.1f);

        }

        Movement.Normalize();
        LocomotionAnim();
    }

    private void LocomotionAnim()
    {
        float velocityZ = Input.GetAxis("Vertical");
        float velocityX = Input.GetAxis("Horizontal");

        anim.SetFloat("VelocityX", velocityX);
        anim.SetFloat("VelocityZ", velocityZ);
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

}
