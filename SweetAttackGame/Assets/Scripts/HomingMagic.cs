using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingMagic : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float shootSpeed;

    [SerializeField] private float maxLife = 4.0f;
    [SerializeField] private AudioClip HMSFX;
    private float lifeBtwTimer;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        SoundManagerScript.instance.PlaySound(HMSFX);
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
            other.GetComponent<Health>().TakeDamage(10);
            Destroy(gameObject);
            Debug.Log("PlayerHealth: "+ other.GetComponent<Health>().currentHealth);
        }
    }
}
