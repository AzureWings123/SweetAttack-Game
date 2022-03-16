using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    private float healthPoints;
    [SerializeField] private float maxHealthPoints;

    private Transform target; // Enemy target = player
    private SpriteRenderer sp;
    void Start()
    {
        healthPoints = maxHealthPoints;
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        facePlayer();
        Attack();
        if(healthPoints <= 0)
        {
            Death();
        }
    }

    protected virtual void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed = Time.deltaTime);
    }

    private void facePlayer()
    {
        if (transform.position.x > target.position.x)
            sp.flipX = true;
        else
            sp.flipX = false;
    }

    protected virtual void Attack()
    {

    }
    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
