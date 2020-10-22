using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorScript : MonoBehaviour
{
    public float health = 10;
    public float speed;
    public GameObject gun;
    public GameObject bullet;

    public Material greenHair; // Above 50% health
    public Material orangeHair; // Above 10% health
    public Material redHair; // Below or equal to 10% health

    private MeshRenderer meshRenderer;
    public GameObject hair;

    private float maxHealth;


    private GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        player = GameObject.FindGameObjectWithTag("Player");
        meshRenderer = hair.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < maxHealth) CheckHealth();

        Vector3 targetDirection = player.transform.position - transform.position;

        float step = speed * Time.deltaTime;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);

        transform.rotation = Quaternion.LookRotation(newDirection);

        gun.GetComponent<GunScript>().Fire(bullet);
    }

    void CheckHealth() {
        float healthPerc = health / maxHealth;
        if (healthPerc > 0.5f) {
            meshRenderer.material = greenHair;
            return;
        }
        if (healthPerc > 0.1f) {
            meshRenderer.material = orangeHair;
            return;
        }
        if (healthPerc >= 0.0f) {
            meshRenderer.material = redHair;
            return;
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("PlayerBullet")) {
            Destroy(collider.gameObject);
            health--;
            if (health <= 0)
                Destroy(gameObject);
        }
    }
}
