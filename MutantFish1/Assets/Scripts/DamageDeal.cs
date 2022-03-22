using UnityEngine;

public class DamageDeal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            PlayerMovement.instance.Health -= 1;
            PlayerMovement.instance.UpdateUI();
        }

    }
}
