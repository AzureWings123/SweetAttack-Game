using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    //public GameObject GameOverCanvas;

    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 100; 
    }
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 100;
        /*
        if (playerHealth.currentHealth <= 0)
        {
            GameOverCanvas.SetActive(true);
        }
        */
    }
}
