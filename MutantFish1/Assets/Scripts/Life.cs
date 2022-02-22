using UnityEngine;

public class Life : MonoBehaviour
{
    public int amount;
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value;
        }
    }
    private void Update()
    {
        if (amount <= 0)
        {
           //Destroy(this.gameObject);
        }
    }





    /*
     
    public int Amount
    {
        get
        {
            return amount;
        }

        set
        {
            amount = value;

            if (amount <= 0)
            {
                onDeath?.Invoke();
            }
        }
    }

    private int amount; 
    private System.Action onDeath;


    public Life(System.Action deathCallback)
    {
        onDeath = deathCallback;
    }
     */


}
