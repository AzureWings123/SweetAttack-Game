using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rig : MonoBehaviour
{
    public Rigidbody2D ldRb;

    private void Start()
    {
        ldRb = GetComponent<Rigidbody2D>();
    }
}


