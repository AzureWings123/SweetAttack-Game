using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : EnemyBase
{
    private float teleRate = 2.0f;
    private float teleTimer;

    private float shootRate = 2.0f;
    private float shootTimer;

    public GameObject projectile;

    [SerializeField] private float minX, maxX, minY, maxY;
    
    protected override void Move()
    {
        //base.Move();
        teleportToPlayer();
    }

    private void teleportToPlayer()
    {
        teleTimer += Time.deltaTime;
        if(teleTimer > teleRate)
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
            teleTimer = 0;
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
}
