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
    private Vector2 lookPos = Vector2.zero;
    //Prefabs
    public GameObject fireballPrefab;
    public GameObject lbPrefab;
    

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
                spellForce = 25f;
                return lbPrefab;
            case Spells.MIST:
                //This spell works differently from 
                spellForce = 0f;
                return lbPrefab;
            default:
                print("error occured. Huh?");
                return fireballPrefab;
        }
    }

    //Create GameObject and send it out with correct amount of force needed.
    public void castSpell()
    {
        //Make it so it differentiate between hitscan and projectile spells
        //Hitscan spell
        if (currSpell == Spells.MIST)
        {
            
            rayBoxSize.x = 4f;
            rayBoxSize.y = Mathf.Sqrt(Mathf.Pow(lookPos.x - firePoint.position.x, 2) + Mathf.Pow(lookPos.y - firePoint.position.y, 2));
            //Make a boxcast that is at a fixed width and a length of origin            
            RaycastHit2D box = Physics2D.BoxCast(firePoint.position, rayBoxSize, 0f, Vector2.up);
            Debug.DrawRay(firePoint.position + new Vector3( rayBoxSize.x, 0), Vector2.up * (rayBoxSize.y), Color.blue);
        }
        //Projectile spells
        else
        {
            GameObject spell = Instantiate(selectSpell(), firePoint.position, lookDir.rotation);
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
