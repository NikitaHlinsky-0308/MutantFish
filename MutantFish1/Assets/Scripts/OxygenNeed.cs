using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenNeed : MonoBehaviour
{
    [SerializeField] private float oxygenAmount;
    private float currentOxygen;

    void Start() => currentOxygen = oxygenAmount;

    void LateUpdate()
    {
        SubtrackOxygen(2f * Time.deltaTime);
       
    }



    public void AddOxygen(float amount)
    {
        currentOxygen = Mathf.Min(currentOxygen + amount, oxygenAmount);
    }

    public void SubtrackOxygen(float amount)
    {
        currentOxygen = Mathf.Max(currentOxygen - amount, 0);
    }

    private void UpdateUI()
    {
        UImanager.instance.oxygenSlider.value = oxygenAmount;
    }
}
