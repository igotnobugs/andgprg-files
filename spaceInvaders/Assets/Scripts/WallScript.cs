using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallScript : MonoBehaviour
{
    public AudioClip destroySound;
    public GameObject explosion;
    private AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Bullet")) {

            Destroy(collision.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider collider) {
        if (collider.CompareTag("Enemy")) {
            Destroy(collider.gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
