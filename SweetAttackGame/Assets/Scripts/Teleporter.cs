using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : EnemyBase
{
    private float teleRate = 2.5f;
    private float teleTimer = 0.0f;
    private bool teleporting = false;

    private float shootRate = 2.0f;
    private float shootTimer;

    public GameObject projectile;

    private ParticleSystem startTPParticles;
    private ParticleSystem endTPParticles;

    [SerializeField] private float minX, maxX, minY, maxY;
    
    protected override void Initialize()
    {
        base.Initialize();

        startTPParticles = transform.Find("Start_Teleport_Particles").GetComponent<ParticleSystem>();
        endTPParticles = transform.Find("End_Teleport_Particles").GetComponent<ParticleSystem>();
    }

    protected override void Move()
    {
        //base.Move();
        teleportToRandomSpot();
    }

    private void teleportToRandomSpot()
    {
        teleTimer += Time.deltaTime;
        if(teleTimer > teleRate && !teleporting)
        {
            // transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            // teleTimer = 0;

            StartCoroutine(teleport());
        }
    }

    protected override void Attack()
    {
        base.Attack();

        shootTimer += Time.deltaTime;
        if(shootTimer > shootRate)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            shootTimer = 0;
        }
    }

    IEnumerator teleport()
    {
        teleporting = true;
        
        Color spDefaultColor = sp.color;
        Color transparent = new Color(0,0,0,0);

        startTPParticles.Play();
        yield return new WaitForSeconds(0.25f);
        sp.color = transparent;
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        yield return new WaitForSeconds(0.3f);
        endTPParticles.Play();
        sp.color = spDefaultColor;

        teleTimer = 0;
        teleporting = false;
    }
}
