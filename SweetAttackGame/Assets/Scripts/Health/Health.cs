using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; set; }
    [SerializeField] private AudioClip GOSFX;

    private void Awake()
    {
        currentHealth = startingHealth;
    }
    
    public void TakeDamage(float _damage)
    {
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
        if (currentHealth > 0)
        {
            //hurt
        }
        else
        {
            if (gameObject.tag == "Enemy")
            {
                Destroy(gameObject);
            }
            else if (gameObject.tag == "Player")
            {
                SoundManagerScript.instance.PlaySound(GOSFX);
            }

        }
        
    }
    


}
