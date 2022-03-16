using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMagic : MonoBehaviour
{
    private Transform target;
    private Vector3 targetPosition;
    [SerializeField] private float shootSpeed;

    [SerializeField] private float maxLife = 2.0f;
    private float lifeBtwTimer;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        targetPosition = target.position;
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPosition, shootSpeed * Time.deltaTime);

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
