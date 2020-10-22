using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float forwardSpeed = 50;
    public float backwardSpeed = 20;
    public float rotationSpeed = 25;
    public Thrusters[] ThrustersMovingForward;
    public Thrusters[] ThrustersMovingBackward;
    public Thrusters[] ThrustersTurningLeft;
    public Thrusters[] ThrustersTurningRight;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Forward
        if (Input.GetKey(KeyCode.W)) {
            for (int i = 0; i < ThrustersMovingForward.Length; i++) {
                ThrustersMovingForward[i].Thrust(rotationSpeed);
            }
        }

        //Backward
        if (Input.GetKey(KeyCode.S)) {
            for (int i = 0; i < ThrustersMovingBackward.Length; i++) {
                ThrustersMovingBackward[i].Thrust(rotationSpeed);
            }
        }

        //Left
        if (Input.GetKey(KeyCode.A)) {
            for (int i = 0; i < ThrustersTurningLeft.Length; i++) {
                ThrustersTurningLeft[i].Thrust(rotationSpeed);
            }
        }

        //Right
        if (Input.GetKey(KeyCode.D)) {
            for (int i = 0; i < ThrustersTurningRight.Length; i++) {
                ThrustersTurningRight[i].Thrust(rotationSpeed);
            }
        }
    }
}
