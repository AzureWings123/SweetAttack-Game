using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyBase
{

    private float shootRate = 3.0f;
    private float shootTimer;
    private float attackChoice;

    public GameObject regProjectile;
    public GameObject homProjectile;
    //public AudioSource SoundPlayer;

    private void Awake()
    {
       // SoundPlayer.Play();
    }
    protected override void Attack()
    {
        Debug.Log("Start Shooting");
        shootTimer += Time.deltaTime;
        if (shootTimer > shootRate)
        {
            var attackChoice = Random.Range(0, 3);
            if (attackChoice < 1)
            {
                StartCoroutine(homingCoroutine());
            }
            else
            {
                StartCoroutine(normalCoroutine());
            }
            shootTimer = 0;
        }
    }

    IEnumerator homingCoroutine()
    {
        yield return new WaitForSecondsRealtime(.3f);
        Instantiate(homProjectile, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(.3f);
        Instantiate(homProjectile, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(.3f);
        Instantiate(homProjectile, transform.position, Quaternion.identity);
    }
    IEnumerator normalCoroutine()
    {
        yield return new WaitForSecondsRealtime(.2f);
        Instantiate(regProjectile, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(.2f);
        Instantiate(homProjectile, transform.position, Quaternion.identity);
        yield return new WaitForSecondsRealtime(.2f);
        Instantiate(homProjectile, transform.position, Quaternion.identity);
    }
}
