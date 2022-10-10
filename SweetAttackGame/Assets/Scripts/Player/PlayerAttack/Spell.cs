using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spell : MonoBehaviour
{
    //List of spells that the player is able to switch between. 
    //Will change name of lightning later
    public enum Spells
    {
        FIREBALL, LIGHTNING_BOLT, MIST
    }

    [SerializeField] Player player;

    protected Spells currSpell;
    private Vector2 rayBoxSize;
    public Transform firePoint;
    public Transform lookDir;
    private Vector3 lookPos = Vector3.zero;
    //Prefabs
    public GameObject fireballPrefab;
    public GameObject lbPrefab;
    public GameObject mistPrefab;

    [SerializeField] private AudioClip fireBallSound;
    [SerializeField] private AudioClip MistSound;
    [SerializeField] private AudioClip LightningSound;

    public float spellForce = 10f;
    public int manaCost = 5;

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
            currSpell = Spells.MIST;
        }
        else if (currSpell == Spells.MIST)
        {
            currSpell = Spells.FIREBALL;
        }

        print("Changed Spell to " + currSpell);
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
                spellForce = 20f;
                return lbPrefab;
            case Spells.MIST:
                //This spell works differently from 
                spellForce = 10f;
                return mistPrefab;

            default:
                print("error occured. Huh?");
                return fireballPrefab;
        }
    }

    //Create GameObject and send it out with correct amount of force needed.
    public void castSpell()
    {
        //This is temporary for sprite rotation
        //Will import fixed sprites later
        if (currSpell == Spells.MIST || currSpell == Spells.FIREBALL)
        {
            Vector2 target = lookPos;
            GameObject spell = Instantiate(selectSpell(), firePoint.position, lookDir.rotation);
            if(currSpell == Spells.MIST)
            {
                SoundManagerScript.instance.PlaySound(MistSound);
            }
            else if (currSpell == Spells.FIREBALL)
            {
                SoundManagerScript.instance.PlaySound(fireBallSound);
            }
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * spellForce, ForceMode2D.Impulse);

            //In order to have mist work as needed, we need to give certain properties such as health
            //Reminder to set that in spell behavior later

            //We need mist to travel a certain distance
            //The current drag set is 3 -> we need to essentailly use F = W * D in order to set the correct force
            //Before we can set the distance by taking the cordinates of fire point - coordinates
            //Afterwards we find the distance by taking the vector and sqrt(x^2 + y^2)
            //If any other devs see this sorry this is just a mental note for later when I do code this in
        }
        //Projectile spells
        else if (currSpell == Spells.LIGHTNING_BOLT)

        {
            GameObject spell = Instantiate(selectSpell(), firePoint.position, firePoint.rotation);
            SoundManagerScript.instance.PlaySound(LightningSound);
            Rigidbody2D rb = spell.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * spellForce, ForceMode2D.Impulse);
        } 
        
        player.animator.SetTrigger("cast");
    }

    public Spells returnSpell()
    {
        return currSpell;
    }

    private void Update()
    {
        //Only does calculation while spell is out in order to save on resources
        if(currSpell == Spells.MIST)
        {
            lookPos = player.cam.ScreenToWorldPoint(player.controllerHandler.LookInput);
        }
    }
}
