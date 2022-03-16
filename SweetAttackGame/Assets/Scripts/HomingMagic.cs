using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMagic : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float shootSpeed;

    [SerializeField] private float maxLife = 2.0f;
    private float lifeBtwTimer;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, shootSpeed * Time.deltaTime);

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
            Destroy(gameObject);
        }
    }
}
