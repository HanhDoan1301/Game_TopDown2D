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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentEnergy = 0;
        UpdateEnerguBar();
        boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
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
    }

    private void UpdateEnerguBar()
    {
        if(energyBar != null )
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
