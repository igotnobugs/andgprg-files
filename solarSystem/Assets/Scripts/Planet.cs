using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{

    public GameObject planetToRevolve;

    public float revolveSpeed = 20;

    public Vector3 axis = Vector3.up;

    public float rotationSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (planetToRevolve != null)
            transform.RotateAround(planetToRevolve.transform.position, axis, revolveSpeed * Time.deltaTime);

        if (rotationSpeed != 0)
            transform.localRotation *= Quaternion.AngleAxis(rotationSpeed * Time.deltaTime, Vector3.up);

    }
}
