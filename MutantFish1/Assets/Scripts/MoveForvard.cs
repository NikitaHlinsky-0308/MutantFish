using UnityEngine;

public class MoveForvard : MonoBehaviour
{
    [SerializeField] private float speed;
    
    private Gun weapon;
    private Vector3 lastPos;

    private void Start()
    {
        lastPos = transform.position;
        weapon = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Gun>();
    }

    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed * Time.deltaTime));

        RaycastHit hit;
        

        if (Physics.Linecast(lastPos, transform.position, out hit))
        {

            DamageDeal(hit);
            Destroy(gameObject);
        }
        lastPos = transform.position;
        Destroy(gameObject, 1);

    }

    private void DamageDeal(RaycastHit hit)
    {
        EnemyController enemy = hit.transform.GetComponent<EnemyController>();
        if (enemy != null)
        {
            enemy.TakeDamage(weapon.Damage);
        }
    }
    
    
    
}
