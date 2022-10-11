using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    [SerializeField] private Health enemyHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    private void Start()
    {
        totalHealthBar.fillAmount = enemyHealth.currentHealth / 100;
    }
    private void Update()
    {
        currentHealthBar.fillAmount = enemyHealth.currentHealth / 100;
    }
}
