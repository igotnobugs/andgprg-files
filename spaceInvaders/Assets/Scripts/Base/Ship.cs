using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipType {Player, Standard, Missile, Bomber, UFO, Bonus, PowerUp};

public class Ship : MonoBehaviour
{
    public ShipType type;
    public int health = 5;
    public float moveSpeed;
    public float xBoundary;

    public Transform bulletSpawn;
    public GameObject bullet;
    public float fireRate = 0.5f;

    protected Rigidbody rb;
    protected float shotCooldown = 0;

    public GameObject deathExplosion;
    public GameObject hitExplosion;

    public delegate void ShipEvent();
    public static event ShipEvent OnDestroyed;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shotCooldown > 0) shotCooldown -= Time.deltaTime; 
    }

    public void Shoot() {
        if (shotCooldown > 0) return;
        Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        shotCooldown = fireRate;
        BulletScript bulScrpt = bullet.GetComponent<BulletScript>();
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Bullet")) {
            BulletScript bullet = collider.GetComponent<BulletScript>();
            health -= bullet.damage;

            Destroy(collider.gameObject);
            if (health > 0) {
                Instantiate(hitExplosion, transform.position, transform.rotation);
            } else 
            { 
                OnDestroyed?.Invoke();
                Destroy(gameObject);
                Instantiate(deathExplosion, transform.position, transform.rotation);
            }
        }
    }
}
