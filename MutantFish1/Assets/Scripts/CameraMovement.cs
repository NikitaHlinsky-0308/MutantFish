using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static CameraMovement instance;
    
    [SerializeField] private Transform lookAt, Player, cam;
    [SerializeField] private float distance;

    // camera clampin angles1
    private const float YMin = -17.0f;
    private const float YMax = 50.0f;

    public Transform targetLook;


    private float currentX = 0.0f, currentY = 0.0f;
    public float sensivity;
    
    

    //1
    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }


    void Update()
    {

        currentX += Input.GetAxis("Mouse X") * sensivity * Time.deltaTime;
        currentY += Input.GetAxis("Mouse Y") * sensivity * Time.deltaTime;

        currentY = Mathf.Clamp(currentY, YMin, YMax);

        Vector3 Direction = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        transform.position = lookAt.position + rotation * Direction;

        transform.LookAt(lookAt.position);

        TargetLook();
    }

    public void TargetLook()
    {
        Ray ray = new Ray(cam.position, cam.forward * 1000);
        RaycastHit hit;
        
        if(Physics.Raycast(ray, out hit))
        {
            targetLook.position = Vector3.Lerp(targetLook.position, hit.point, Time.deltaTime * 30);
        }
        else
        {
            targetLook.position = Vector3.Lerp(targetLook.position, targetLook.transform.forward * 150, Time.deltaTime);
        }
     
    }
}
