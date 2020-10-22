using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thrusters : MonoBehaviour
{
    private Rigidbody mainBody;
    private float speed = 0;
    private bool active = false;

    // Start is called before the first frame update
    void Start()
    {
        mainBody = GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (active) {
            mainBody.AddForceAtPosition(transform.forward * speed * Time.deltaTime, transform.position);
            active = false;
        }
    }


    public void Thrust(float spd) {
        speed = spd;
        active = true;
    }
}
