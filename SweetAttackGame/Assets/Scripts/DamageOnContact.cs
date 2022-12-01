using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : EnemyBase
{
    protected float distance;
    protected float timer = 1;
    protected float triggerDist = 4;
    protected bool trig = false;
    protected bool done = false;

    protected override void Move()
    {
        if (trig == true && done == false) //if player is in range and stop hasn't completed
        {
            if (timer >= 0) timer -= Time.deltaTime; //timer for stop

            else done = true; //signal to move again

            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed = 0);
        }
        if (trig == true && done == true) //player was in range and stop has completed
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed = 4 * Time.deltaTime);
        }
        else if (trig == false)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed = Time.deltaTime);
        }
    }

    protected override void Attack()
    {
        distance = target.position.x - transform.position.x; // calculates distance from player
        if (Mathf.Abs(distance) <= triggerDist) trig = true;
    }
}
