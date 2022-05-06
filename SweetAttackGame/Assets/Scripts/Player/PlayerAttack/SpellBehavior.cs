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
            if(gameObject.tag == "IceMagic" || gameObject.tag == "LightningMagic")
            {
                collision.GetComponent<Health>().TakeDamage(30);
            }
            else if(gameObject.tag == "FireMagic")
            {
                collision.GetComponent<Health>().TakeDamage(20);
            }
            Debug.Log(collision.GetComponent<EnemyBase>().enemyName + ": " + collision.GetComponent<Health>().currentHealth);
            Destroy(gameObject);
        }
    }
}
