using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;

    public Text waves;
    public GameObject pauseMenu;
    public GameObject optionsScreen;
    public GameObject inGameUI;
    public Slider sensSlider;
    public GameObject upgradePanel;
    

    private void Awake()
    {
        instance = this;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenUpgrade();
        }
    }
     
     */

    public void Resume()
    {
        GameModeManager.instance.PauseUnpause();
    }

    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }

    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }

    public void SetSensLevel()
    {
        CameraMovement.instance.AjustSens();
    }

    public void OpenUpgrade()
    {
        upgradePanel.SetActive(true);
    }

    public void CloseUpgrade()
    {
        upgradePanel.SetActive(false);
    }

    public void Quit()
    {

    }
    


}
