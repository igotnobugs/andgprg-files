using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCylinderScript : MonoBehaviour
{  
    public GameObject spherePrefab; 
    public float alertRange = 50.0f;
    public AudioClip clipInRange;
    public AudioClip clipOutRange;
    public AudioClip clipSphereHit;
    public float cooldownTime = 3.0f;
    public Vector3 sphereSpawnLocation;
    public Material normal; // Player out of range
    public Material alert; // In range and sphere spawned
    public Material cooldown; // Sphere destroyed

    private GameObject player;
    private GameObject sphereTarget;
    private TargetSphereScript sphereScript;
    private float curCooldown = 0.0f;
    private MeshRenderer meshRenderer;
    private AudioSource audioSource;

    public delegate void SphereEvent();
    public static event SphereEvent OnHit;

    private bool inRange = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GameManagerScript.TimeOut += StopSpawning;
        meshRenderer = GetComponent<MeshRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);
        if (dist <= alertRange) {
            if (!inRange)
                audioSource.PlayOneShot(clipInRange);
            inRange = true;
        } else {
            if (inRange)
                audioSource.PlayOneShot(clipOutRange);
            inRange = false;
        }
 
        if (sphereTarget != null) {
            if (dist > alertRange) {
                Destroy(sphereTarget);
            }
            return;
        }

        if (curCooldown >= 0) {
            curCooldown -= Time.deltaTime;
            return;
        }

        if (inRange) {
            sphereTarget = Instantiate(spherePrefab, transform.position + sphereSpawnLocation, transform.rotation);
            sphereScript = sphereTarget.GetComponent<TargetSphereScript>();
            sphereScript.spawnerCylinder = gameObject.GetComponent<TargetCylinderScript>();
            meshRenderer.material = alert;         
        } else {
            meshRenderer.material = normal;
        }
    }

    public void SphereHit() {
        audioSource.PlayOneShot(clipSphereHit);
        OnHit?.Invoke();
    }

    public void SphereDestroyed() {
        meshRenderer.material = cooldown;
        curCooldown = cooldownTime;
    }

    void StopSpawning() {
        alertRange = 0;
    }

    void OnDrawGizmosSelected() {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, alertRange);
    }
}
