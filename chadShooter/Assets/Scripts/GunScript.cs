using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{ 
    public Transform bulletSpawn;

    public bool fireRateRandom = false;
    public float fireRate;
    public Vector2 fireRateRand = new Vector2(2.0f, 5.0f);
    public int bulletClip = 30;
    public float reloadTime = 1.0f;

    private float firePerSecond;
    private float fireCooldown = 0;
    private float reloadCooldown = 0;

    [HideInInspector]
    public int totalBullets;
    [HideInInspector]
    public bool reloading = false;

    // Start is called before the first frame update
    void Start()
    {
        firePerSecond = 1.0f / fireRate;
        totalBullets = bulletClip;
    }

    // Update is called once per frame
    void Update()
    {
        if (fireCooldown > 0) fireCooldown -= Time.deltaTime;

        if (reloading) {
            if (reloadCooldown > 0) {
                reloadCooldown -= Time.deltaTime;
            }
            else {
                totalBullets = bulletClip;
                reloading = false;
            }
        }

    }

    public void Fire(GameObject bullet) {
        if (fireCooldown > 0) return;
        if (reloading) return;
        if (totalBullets <= 0) return;

        GameObject nb = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        totalBullets--;
        if (!fireRateRandom)
            fireCooldown = firePerSecond;
        else
            fireCooldown = Random.Range(fireRateRand.x, fireRateRand.y);
    }

    public void Reload() {
        reloadCooldown = reloadTime;
        reloading = true;
    }
}
