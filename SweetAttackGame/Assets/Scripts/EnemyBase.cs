using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField] public string enemyName;
    [SerializeField] protected float moveSpeed; //changed from private
    protected Transform target; // Enemy target = player ***changed from private
    private SpriteRenderer sp;
    Rigidbody2D rb;
    void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        facePlayer();
        Attack();
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(4);
            Debug.Log("PlayerHealth: " + other.GetComponent<Health>().currentHealth);
        }
    }

}
