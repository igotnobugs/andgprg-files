using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
		// No enemy to test this on so whats the point?
		// Lets just pretend its a homing bullet
        Destroy(go, 5.0f);
    }
}
