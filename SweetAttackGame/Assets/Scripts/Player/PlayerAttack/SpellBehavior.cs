using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBehavior : MonoBehaviour
{
    [SerializeField] private int baseDamage;
    [SerializeField] public int damageAdd;

    [HideInInspector] int hold = 0;

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
                /*
                if (hold == 0)
                {
                    hold = 1;
                    Debug.Log("Hold apply ice " + hold);
                }
                else if(hold == 1) // ice
                {
                    hold = 0;
                }
                else if(hold == 2) // ice + elec
                {
                    collision.GetComponent<Health>().TakeDamage(30);
                    hold = 0;
                }
                else // ice + fire
                {
                    collision.GetComponent<Health>().TakeDamage(10);
                    hold = 0;
                }*/
            }
            else if (gameObject.tag == "LightningMagic")
            {
                damageAdd *= (PlayerPrefs.GetInt("ElecLevel")-1);
                baseDamage += damageAdd;
                collision.GetComponent<Health>().TakeDamage(baseDamage);
                collision.GetComponent<StatusEffect>().ChangeEffect(2);

                /*
                if (hold == 0)
                {
                    hold = 2;
                    Debug.Log("Hold apply elec " + hold);
                }
                else if (hold == 1) //ice + elec
                {
                    collision.GetComponent<Health>().TakeDamage(30);
                    hold = 0;
                }
                else if (hold == 2) //elec
                {
                    hold = 0;
                }
                else //elec + fire
                {
                    Debug.Log("Overload");
                    collision.GetComponent<Health>().TakeDamage(20);
                    hold = 0;
                } */


            }
            else if(gameObject.tag == "FireMagic")
            {
                damageAdd *= (PlayerPrefs.GetInt("FireLevel")-1);
                baseDamage += damageAdd;
                collision.GetComponent<Health>().TakeDamage(baseDamage);
                collision.GetComponent<StatusEffect>().ChangeEffect(3);

                /*
                if (hold == 0)
                {
                    hold = 3;
                    Debug.Log("Hold apply fire " + hold);
                }
                else if (hold == 1) //fire + ice
                {
                    collision.GetComponent<Health>().TakeDamage(10);
                    hold = 0;
                }
                else if (hold == 2) //elec + fire
                {
                    collision.GetComponent<Health>().TakeDamage(20);
                    hold = 0;
                }
                else //fire
                {
                    hold = 0;
                } */
            }
            Destroy(gameObject);
            Debug.Log("hold = " + hold);
        }
    }
}
