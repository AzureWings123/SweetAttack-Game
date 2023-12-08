using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1 : EnemyBase
{

    private float shootRate = 3.0f;
    private float shootTimer;

    public GameObject projectile;
    public AudioSource SoundPlayer;

    private void Awake()
    {
        SoundPlayer.Play();
    }
    protected override void Attack()
    {
        Debug.Log("Start Shooting");
        shootTimer += Time.deltaTime;
        if (shootTimer > shootRate)
        {
            for(int i = 0; i < 2; i++)
            {
                
                StartCoroutine(MyCoroutine());
            }
            shootTimer = 0;
        }
    }

    IEnumerator MyCoroutine()
    {
        //Debug.Log(Time.time);
        yield return new WaitForSeconds(.5f);
        Instantiate(projectile, transform.position, Quaternion.identity);
        //Debug.Log(Time.time);
    }

}
