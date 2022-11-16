using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    [SerializeField] public int damageAdd;

    private void Start() 
   {
        if (gameObject.tag == "IceMagic")
        {
            Destroy(gameObject, 10f);
        }
        else
        {
            Destroy(gameObject, 3f);
        }

        
   }
   
   private void OnCollisionEnter2D(Collision2D other) 
   {
       Destroy(gameObject);
   }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            if (gameObject.tag == "IceMagic")
            {
                damageAdd *= (PlayerPrefs.GetInt("IceLevel")-1);
                baseDamage += damageAdd;
                collision.GetComponent<Health>().TakeDamage(baseDamage);
                collision.GetComponent<StatusEffect>().ChangeEffect(1);
                Debug.Log("ice");
                Debug.Log(collision.GetComponent <StatusEffect>().currentEffect);
                
            }
            else if (gameObject.tag == "LightningMagic")
            {
                damageAdd *= (PlayerPrefs.GetInt("ElecLevel")-1);
                baseDamage += damageAdd;
                collision.GetComponent<Health>().TakeDamage(baseDamage);
                collision.GetComponent<StatusEffect>().ChangeEffect(2);
                Debug.Log("lightning");
                Debug.Log(collision.GetComponent<StatusEffect>().currentEffect);
            }
            else if(gameObject.tag == "FireMagic")
            {
                damageAdd *= (PlayerPrefs.GetInt("FireLevel")-1);
                baseDamage += damageAdd;
                collision.GetComponent<Health>().TakeDamage(baseDamage);
                collision.GetComponent<StatusEffect>().ChangeEffect(3);
                Debug.Log("fire");
                Debug.Log(collision.GetComponent<StatusEffect>().currentEffect);
            }
            Debug.Log(collision.GetComponent<EnemyBase>().enemyName + ": " + collision.GetComponent<Health>().currentHealth);
            Destroy(gameObject);
        }
    }
}
