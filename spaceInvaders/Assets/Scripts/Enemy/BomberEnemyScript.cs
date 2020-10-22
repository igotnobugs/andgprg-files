using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomberEnemyScript : Ship
{
    //Goes in a straight line then explodes once y boundary is reached

    public float yBoundary;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * -1 * moveSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < yBoundary) {
            Destroy(gameObject);
        }

    }

    void OnTriggerEnter(Collider collider) {

        if (collider.CompareTag("Wall")) {
            Destroy(gameObject);
            Instantiate(deathExplosion, transform.position, transform.rotation);
        }


        if (collider.CompareTag("Bullet")) {
            Destroy(collider.gameObject);

            if (health <= 0) {
                Destroy(gameObject);
                Instantiate(deathExplosion, transform.position, transform.rotation);
            }
        }
    }
}
