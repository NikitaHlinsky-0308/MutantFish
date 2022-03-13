using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public static UImanager instance;

    public Text waves;
    public Text healthCount;
    public GameObject pauseMenu;
    public GameObject optionsScreen;
    public GameObject inGameUI;
    public Slider sensSlider;
    public GameObject upgradePanel;
    public GameObject GameOverPanel;
    public Text waveNumber;
    public Scene scene;


    private void Awake()
    {
        instance = this;
        scene = SceneManager.GetActiveScene();
    }

    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            OpenUpgrade();
        }
    }
     
    

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

    public void RestartScene()
    {
        SceneManager.LoadSceneAsync(0);
        Time.timeScale = 1f;
    }
    


}
