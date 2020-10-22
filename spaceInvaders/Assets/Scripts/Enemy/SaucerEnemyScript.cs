using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaucerEnemyScript : Ship
{
    // Shoots fast moving lasers
    // Goes in a straight line

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.right * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
