using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMagic : MonoBehaviour
{
    private Transform target;
    Vector2 moveDirection;
    [SerializeField] private float shootSpeed;
    [SerializeField] private float maxLife = 8.0f;
    private float lifeBtwTimer;
    Rigidbody2D rb;
    

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        moveDirection = (target.transform.position - transform.position).normalized * shootSpeed;
        rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
    }
    private void Update()
    {
        lifeBtwTimer += Time.deltaTime;
        if (lifeBtwTimer >= maxLife)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<Health>().TakeDamage(20);
            Destroy(gameObject);
            Debug.Log("PlayerHealth: "+ other.GetComponent<Health>().currentHealth);
        }
    }
}
