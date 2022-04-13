using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    //List of spells that the player is able to switch between. 
    private enum Spells
    {
     FIREBALL, LIGHTNING_BOLT
    }

    [SerializeField] Player player;


    private Spells currSpell;
    public Transform firePoint;

    public GameObject fireballPrefab;
    public GameObject lbPrefab;


    public float bulletForce = 20f;

    private void Start() {
        currSpell = Spells.FIREBALL;
    }

    //Searches which state it is currently in and depending on that state will return the needed prefab for that state
    private GameObject selectSpell()
    {
        switch(currSpell)
        {
            case Spells.FIREBALL:
                return fireballPrefab;

            case Spells.LIGHTNING_BOLT:
                return lbPrefab;

            default:
                print("error occured. Huh?");
                return fireballPrefab;
        }
    }

    void castSpell()
    {
        GameObject spell = Instantiate(selectSpell(), firePoint.position, firePoint.rotation);



    }
}
