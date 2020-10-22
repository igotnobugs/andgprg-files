using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public float cooldown = 0.5f;
    private float currentCooldown = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (currentCooldown >= 0) currentCooldown -= Time.deltaTime;
    }

    public void ShootBullet(GameObject bullet) {
        if (currentCooldown <= 0) {
            Instantiate(bullet, transform.position, transform.rotation);
            currentCooldown = cooldown;
        }
        
    }
}
