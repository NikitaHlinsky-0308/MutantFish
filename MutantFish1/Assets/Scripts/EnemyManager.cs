using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager instance;

    [SerializeField] private GameObject spawnee;
    [SerializeField] private GameObject[] spawnPoints;
    [SerializeField] private bool stopSpawn = false;
    [SerializeField] private float spawnTime;
    [SerializeField] private float spawnDelay;

    private int nextPositionPoint = 0;
    private int score;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogError("Waves spawner duplicated", gameObject);
        }
    }

    void Start()
    {
        InvokeRepeating("SpawnObjects", spawnTime, spawnDelay);
    }

    public void SpawnObjects()
    {
        nextPositionPoint = Random.Range(0, spawnPoints.Length);
        //print(nextPositionPoint);
        Instantiate(spawnee, spawnPoints[nextPositionPoint].transform.position, transform.rotation);
        if (stopSpawn)
        {
            CancelInvoke("SpawnObjects");
        }
    }

    public void UpdateUI()
    {
        if (UImanager.instance.score != null)
        {
            UImanager.instance.score.text = score.ToString();
        }

    }

    public void AddScore(int amount)
    {
        score += amount;
    }
}
