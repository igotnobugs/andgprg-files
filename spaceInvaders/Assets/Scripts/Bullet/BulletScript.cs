using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public GameObject shotExplosion;
    protected Rigidbody rb;

    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Instantiate(shotExplosion, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 7.0f);
    }
}
