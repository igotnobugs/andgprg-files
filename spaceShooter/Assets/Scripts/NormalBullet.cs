using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : Bullet
{
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(go, 5.0f);
    }

}
