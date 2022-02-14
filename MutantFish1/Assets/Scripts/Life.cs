using UnityEngine;

public class Life : MonoBehaviour
{
    public float amount;

    private void Update()
    {
        if (amount <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
