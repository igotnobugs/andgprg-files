using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBehaviorScript : MonoBehaviour
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
    // Start is called before the first frame update
    void Start()
    {
        maxHealth = health;
        meshRenderer = hair.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health < maxHealth) CheckHealth();
        if (health <= 0) return;


        if (Input.GetKey(KeyCode.W)) {
            transform.position += transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A)) {
            transform.position -= transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D)) {
            transform.position += transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S)) {
            transform.position -= transform.forward * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Space)) {
            gun.GetComponent<GunScript>().Fire(bullet);
        }

        if (Input.GetKey(KeyCode.R)) {
            gun.GetComponent<GunScript>().Reload();
        }

        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }    
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
        if (collider.CompareTag("EnemyBullet")) {
            Destroy(collider.gameObject);
            health--;
            //if (health <= 0)
            //Destroy(gameObject);
        }
    }
}
