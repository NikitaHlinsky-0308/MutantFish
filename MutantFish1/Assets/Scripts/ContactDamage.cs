using UnityEngine;

public class ContactDamage : MonoBehaviour
{

    public float damage;

    /*
    private void OnTriggerEnter(Collider other)
    {
        Life life = other.GetComponent<Life>();
        Debug.Log(other.name);
        if (life != null)
        {
            
            life.amount -= damage;
        }
    }
     
     
     
     */

    public void DamageDeal(RaycastHit hit)
    {
        Life life = hit.transform.GetComponent<Life>();

        if (life != null)
        {
            life.amount -= damage;
        }
    }


}
