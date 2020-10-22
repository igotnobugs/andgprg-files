using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : Ship
{  
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0) shotCooldown -= Time.deltaTime;

        float moveHorizontal = Input.GetAxis("Horizontal"); 
        if (moveHorizontal != 0 ) {
            rb.velocity = new Vector3(moveHorizontal, 0.0f, 0.0f) * moveSpeed;
        }

        if (Input.GetKey(KeyCode.Space)) {
            Shoot();
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }

        transform.position = new Vector3
        (
            Mathf.Clamp(transform.position.x, -xBoundary, xBoundary),
            transform.position.y,
            transform.position.z
        );
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
            health--;

            if (health > 0) {
                Instantiate(hitExplosion, transform.position, transform.rotation);
            } else {
                Destroy(gameObject);
                Instantiate(deathExplosion, transform.position, transform.rotation);
            }
        }
    }
}
