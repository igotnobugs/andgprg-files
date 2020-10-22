using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : Ship
{

    /*
     * 
    Double Damage: The player's bullets deal double damage to enemy units for a duration. Add VFX to the bullets.
    HP++: The player gains random hp from 1 to 3. Add VFX to the ship.
    Speed Up: The player gains movement speed for a duration. Add VFX to the ship.
    Power-ups should spawn on a random position.


     */
    public GameObject getExplosion;
    //protected Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * -1 * moveSpeed;       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Player")) {
            Instantiate(getExplosion, transform.position, transform.rotation);
        }
    }

    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
