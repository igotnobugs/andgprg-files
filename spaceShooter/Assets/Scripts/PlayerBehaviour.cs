using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float speed = 10;
    public float fireSpeed = 3;

    public GameObject[] equippedBullets;
    public GunScript[] guns;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Forward
        if (Input.GetKey(KeyCode.UpArrow)) {
            gameObject.transform.position += Vector3.up * speed * Time.deltaTime;
        }

        //Backward
        if (Input.GetKey(KeyCode.DownArrow)) {
            gameObject.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        //Left
        if (Input.GetKey(KeyCode.LeftArrow)) {
            gameObject.transform.position += Vector3.left * speed * Time.deltaTime;
        }

        //Right
        if (Input.GetKey(KeyCode.RightArrow)) {
            gameObject.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        //Shooting bullets QWER
        if (Input.GetKey(KeyCode.Q)) {
            for (int i = 0; i < guns.Length; i++) {
                guns[i].ShootBullet(equippedBullets[0]);
            }
        }
        if (Input.GetKey(KeyCode.W)) {
            for (int i = 0; i < guns.Length; i++) {
                guns[i].ShootBullet(equippedBullets[1]);
            }
        }
        if (Input.GetKey(KeyCode.E)) {
            for (int i = 0; i < guns.Length; i++) {
                guns[i].ShootBullet(equippedBullets[2]);
            }
        }
        if (Input.GetKey(KeyCode.R)) {
            for (int i = 0; i < guns.Length; i++) {
                guns[i].ShootBullet(equippedBullets[3]);
            }
        }


        if (Input.GetKey(KeyCode.Escape)) {
            Application.Quit();
        }
    }
}
