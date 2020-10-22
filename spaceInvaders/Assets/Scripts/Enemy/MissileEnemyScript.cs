using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileEnemyScript : Ship
{
    // Move to a random spot in the field, and fire a homing rocket 
    public float yBoundary;

    public int amountToMove;
    public float timeToShoot;

    public float countDown;
    public bool willShoot = false;

    private Vector3 targetPosition;
    

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = new Vector3(Random.Range(-xBoundary + 1.0f, xBoundary - 1.0f),
            Random.Range(yBoundary, 18.0f),
            transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0) shotCooldown -= Time.deltaTime;
   
        if (countDown > 0) countDown -= Time.deltaTime;

        //Move to random position
        if (countDown <= 0) {
            if (!willShoot) {
                float step = moveSpeed * Time.deltaTime;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

                if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) {
                    countDown = timeToShoot;
                    amountToMove--;
                    willShoot = true;
                }

            } else {
                Shoot();
                countDown = timeToShoot;
                willShoot = false;

                targetPosition = new Vector3(Random.Range(-xBoundary + 1.0f, xBoundary - 1.0f),
                    Random.Range(yBoundary, 18.0f),
                    transform.position.z);
            }
        }

        if (amountToMove <= 0) {
            targetPosition.x = -xBoundary;
        }


        if (transform.position.x >= xBoundary - 0.5f  || transform.position.x <= -xBoundary + 0.5f) {
            Destroy(gameObject);
        }

    }
}
