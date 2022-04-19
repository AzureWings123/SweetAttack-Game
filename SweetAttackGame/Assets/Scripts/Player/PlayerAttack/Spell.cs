using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //List of spells that the player is able to switch between. 
    private enum Spells
    {
        FIREBALL, LIGHTNING_BOLT
    }

    [SerializeField] Player player;

    private Spells currSpell;
    public Transform firePoint;

    //Prefabs
    public GameObject fireballPrefab;
    public GameObject lbPrefab;


    public float spellForce = 10f;

    private void Start()
    {
        currSpell = Spells.FIREBALL;
    }

    //Changes what spells we are going into. Will rotate though a circular motion for testing purposes but I think
    //We can add a menu or an intuitive 
    public void changeSpell()
    {
        if (currSpell == Spells.FIREBALL)
        {
            
            currSpell = Spells.LIGHTNING_BOLT;
        }
        else if (currSpell == Spells.LIGHTNING_BOLT)
        {
            currSpell = Spells.FIREBALL;   
        }
        
        print("Changed Spell to "+ currSpell);
    }

    //Searches which state it is currently in and depending on that state will return the needed prefab for that state
    private GameObject selectSpell()
    {
        switch (currSpell)
        {
            case Spells.FIREBALL:
                spellForce = 10f;
                return fireballPrefab;

            case Spells.LIGHTNING_BOLT:
                spellForce = 25f;
                return lbPrefab;

            default:
                print("error occured. Huh?");
                return fireballPrefab;
        }
    }

    //Create GameObject and send it out with correct amount of force needed.
    public void castSpell()
    {
        GameObject spell = Instantiate(selectSpell(), firePoint.position, firePoint.rotation);
        Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * spellForce, ForceMode2D.Impulse);
    }
}
