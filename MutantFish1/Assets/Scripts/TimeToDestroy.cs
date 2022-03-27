using System.Collections;
using UnityEngine;

public class TimeToDestroy : MonoBehaviour
{
    [SerializeField] private float destroyDelay;

    private void Start() => StartCoroutine(Delay(destroyDelay));    

    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(this.gameObject);
    }
}
