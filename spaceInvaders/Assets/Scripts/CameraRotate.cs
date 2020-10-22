using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public float startingPosition = 10.0f;
    public float rotationSpeed = 5.0f;
    public float timeToMove = 1.5f;

    private Vector3 targetDirection;
    private Vector3 targetPosition;
    private bool startMovingDown;

    

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        transform.position = new Vector3(transform.position.x
            , transform.position.y + 10.0f
            , transform.position.z);

        targetDirection = Vector3.forward * -1;
        transform.rotation = Quaternion.LookRotation(targetDirection);
        
    }

    // Update is called once per frame
    void Update()
    {
        float step = rotationSpeed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);

        if (!startMovingDown) return;
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);
    }

    public void RotateCameraFront() {
        targetDirection = Vector3.forward;
        startMovingDown = true;
    }
}
