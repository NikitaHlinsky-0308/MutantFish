using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForvard : MonoBehaviour
{
    [SerializeField] private float speed;
    private ContactDamage ContDmg;
    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
        ContDmg = GetComponent<ContactDamage>();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        RaycastHit hit;

        if (Physics.Linecast(lastPos, transform.position, out hit))
        {
            //print(hit.transform.name);
            ContDmg.DamageDeal(hit);
            Destroy(gameObject);
        }
        lastPos = transform.position;
        Destroy(gameObject, 1);

    }
}
