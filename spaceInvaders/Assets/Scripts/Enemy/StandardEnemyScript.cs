using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardEnemyScript : Ship
{
    // Formation Starter creates a formation, and moves to the first cell.
    // Formation creates enemys to fill

    public GameObject formation;
    public Vector2 formationPosition;

    public bool formationStarter = false;
    public Transform target;

    private float waitTimeShoot = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        if (!formationStarter) return;
        GameObject form = Instantiate(formation, formationPosition, transform.rotation);
        form.GetComponent<Formation>().AddCell();
        target = form.GetComponent<Formation>().cells[0].transform; 
    }

    // Update is called once per frame
    void Update()
    {

        float step = moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);

        if (transform.position.x > xBoundary || transform.position.x < -xBoundary) {
            Destroy(gameObject);
        }

        if (waitTimeShoot > 0) {
            waitTimeShoot -= Time.deltaTime;
            return;
        }

        if (shotCooldown > 0) shotCooldown -= Time.deltaTime;

        float randomRange = Random.Range(1.0f, 5.0f);

        
        if (randomRange > 3.5f) return;
        Shoot();

    }
}
