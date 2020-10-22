using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Very fast, but very weak, moves around
// Shoots a lot, disappears after a while
// When dead, spawns a power-up


public class BonusEnemyScript : Ship
{
    private Vector3 targetPosition;
    public float yBoundary;

    public float timeToMove;
    public int amountToMove;
    public float countDown;

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
        if (countDown > 0) countDown -= Time.deltaTime;
        //Move to random position
        if (countDown <= 0) {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);

            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) {
                countDown = timeToMove;
                amountToMove--;

                targetPosition = new Vector3(Random.Range(-xBoundary + 1.0f, xBoundary - 1.0f),
                    Random.Range(yBoundary, 18.0f),
                    transform.position.z);
            }
        }

        if (amountToMove <= 0) {
            targetPosition.x = -xBoundary;
            Destroy(gameObject, 3.0f);
        }

        if (transform.position.x >= xBoundary || transform.position.x <= -xBoundary) {
            Destroy(gameObject);
        }
    }
}
