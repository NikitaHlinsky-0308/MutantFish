using System.Collections;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;

    [SerializeField] Life PlayerLife;
    [SerializeField] WaveSpawner Spawner;
    [SerializeField] private float WaveDelay;
    private bool corotineInProcess = false;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

    }

    void Update()
    {

        if (EnemyManager.instance.enemies.Count == 0 && corotineInProcess == false)
        {
            WaveManager.instance.waves += 1;
            WaveManager.instance.UpdateUI();
            if (WaveManager.instance.waves <= 5)
            {
                Spawner.CountEnemy++;
                
            } 

            

            StartCoroutine(NextWaveDelay(WaveDelay));

        } else if (PlayerLife.amount <= 0)
        {
            print("Lose");
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
    }

    IEnumerator NextWaveDelay(float delay)
    {
        corotineInProcess = true;
        yield return new WaitForSeconds(delay);
        Spawner.NextWave();
        corotineInProcess = false;
    }

    public void PauseUnpause()
    {
        if (UImanager.instance.pauseMenu.activeInHierarchy)
        {
            UImanager.instance.pauseMenu.SetActive(false);
            Time.timeScale = 1.0f;

            UImanager.instance.inGameUI.SetActive(true);

            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } else
        {
            UImanager.instance.pauseMenu.SetActive(true);
            Time.timeScale = 0f;

            UImanager.instance.upgradePanel.SetActive(false);
            UImanager.instance.inGameUI.SetActive(false);
            UImanager.instance.CloseOptions();

            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

}
