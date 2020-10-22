using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSphereScript : MonoBehaviour
{
    public float lifetime = 1.0f;
    [HideInInspector]
    public TargetCylinderScript spawnerCylinder;

    //Wont play since it gets destroyed immediately
    //public AudioClip clipSphereHit; 
    //private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            spawnerCylinder.SphereHit();
            Destroy(gameObject);
        }
    }

    void OnDestroy() {
        spawnerCylinder.SphereDestroyed();
    }
}
