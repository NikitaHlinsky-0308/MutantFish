using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    PlayerMovement Player;
    [SerializeField] private float dashSpeed;
    [SerializeField] private float dashTime;
    private float defaultSpeed;


    void Start()
    {
        Player = GetComponent<PlayerMovement>();
        defaultSpeed = Player.Speed;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
            //Debug.Log("после корутины");
        }        
    }

    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            Player.Speed = dashSpeed;

            yield return null;
        }
        Player.Speed = defaultSpeed;

    }
}
