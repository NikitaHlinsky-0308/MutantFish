using System.Collections;
using UnityEngine;

public class GameModeManager : MonoBehaviour
{
    public static GameModeManager instance;

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
        
        if (PlayerMovement.instance.Health <= 0)
        {

            if (!UImanager.instance.GameOverPanel.activeInHierarchy)
            {
                UImanager.instance.inGameUI.SetActive(false);
                UImanager.instance.GameOverPanel.SetActive(true);

                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;

                Time.timeScale = 0f;
            }

            
        } 

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseUnpause();
        }
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
