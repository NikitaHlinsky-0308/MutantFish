using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    
    void Update()
    {
        Destroy(gameObject, 1);
    }
}
