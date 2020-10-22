using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyBullet : Bullet
{
    private float t;
    public float amplitude;
    public float frequency;

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = Vector3.up * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += amplitude * Mathf.Sin(2 * Mathf.PI * frequency * Time.time) * new Vector3(1,0,0);
        Destroy(go, 5.0f);
    }
}
