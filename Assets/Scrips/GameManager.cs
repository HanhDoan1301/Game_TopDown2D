using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshold = 3;
    [SerializeField] private GameObject boss;
    [SerializeField] private GameObject spawnEnemy;
    private bool bossCallsd = false;
    [SerializeField] private Image energyBar;
    [SerializeField] GameObject gameUi;

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverGame;
    [SerializeField] private GameObject pauseGameMenu;
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject red;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private CinemachineCamera cam;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnergy = 0;
        UpdateEnerguBar();
        boss.SetActive(false);
        MainMenu();
        audioManager.StopAudioGame();
        cam.Lens.OrthographicSize = 8f;
        red.SetActive(false);
    }

    public void AddEnergy()
    {
        if(bossCallsd)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnerguBar();
        if(currentEnergy == energyThreshold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCallsd = true;
        boss.SetActive(true);
        spawnEnemy.SetActive(false);
        gameUi.SetActive(false);
        audioManager.PlayBossAudio();
        cam.Lens.OrthographicSize = 12f;
        red.SetActive(true);
    }

    private void UpdateEnerguBar()
    {
        if(energyBar != null )
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }

    public void MainMenu()
    {
        mainMenu.SetActive(true);
        gameOverGame.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGame.SetActive(false);
        Time.timeScale = 0f;
    }

    public void GameOverMenu()
    {
        gameOverGame.SetActive(true );
        mainMenu.SetActive(false );
        pauseGameMenu.SetActive(false );
        winGame.SetActive(false);
        Time.timeScale = 0f;
    }

    public void PauseGameMenu()
    {
        pauseGameMenu.SetActive(true );
        mainMenu.SetActive(false ) ;    
        gameOverGame.SetActive(false );
        winGame.SetActive(false);
        Time.timeScale = 0f;
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        gameOverGame.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGame.SetActive(false);
        Time.timeScale = 1f;
        audioManager.PlayDefaultAudio();
    }

    public void ResumeGame()
    {
        mainMenu.SetActive(false);
        gameOverGame.SetActive(false);
        pauseGameMenu.SetActive(false);
        winGame.SetActive(false);
        Time.timeScale = 1f;
    }
    public void WinGame()
    {
        winGame.SetActive(true);
        mainMenu.SetActive(false);
        gameOverGame.SetActive(false);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 0f;
    }


}
