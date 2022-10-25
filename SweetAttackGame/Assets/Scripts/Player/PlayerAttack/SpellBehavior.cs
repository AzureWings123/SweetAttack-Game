using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
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
            if(gameObject.tag == "IceMagic")
            {
                collision.GetComponent<Health>().TakeDamage(30);
                collision.GetComponent<StatusEffect>().ChangeEffect(1);
                Debug.Log("ice");
                Debug.Log(collision.GetComponent <StatusEffect>().currentEffect);
            }
            else if (gameObject.tag == "LightningMagic")
            {
                collision.GetComponent<Health>().TakeDamage(30);
                collision.GetComponent<StatusEffect>().ChangeEffect(2);
                Debug.Log("lightning");
                Debug.Log(collision.GetComponent<StatusEffect>().currentEffect);
            }
            else if(gameObject.tag == "FireMagic")
            {
                collision.GetComponent<Health>().TakeDamage(20);
                collision.GetComponent<StatusEffect>().ChangeEffect(3);
                Debug.Log("fire");
                Debug.Log(collision.GetComponent<StatusEffect>().currentEffect);
            }
            Debug.Log(collision.GetComponent<EnemyBase>().enemyName + ": " + collision.GetComponent<Health>().currentHealth);
            Destroy(gameObject);
        }
    }
}
