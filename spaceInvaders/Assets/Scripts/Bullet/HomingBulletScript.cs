using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingBulletScript : BulletScript
{
    // Face towards target, stops homing when reached the boundary

    public float rotationSpeed;
    public string targetTag;
    public float yBoundary;
    public Vector3 targetDirection;

    private GameObject target;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag(targetTag);
        Instantiate(shotExplosion, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 7.0f);
        rb.velocity = transform.forward * speed;

        if (transform.position.y < yBoundary) return;
        targetDirection = target.transform.position - transform.position;

        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
