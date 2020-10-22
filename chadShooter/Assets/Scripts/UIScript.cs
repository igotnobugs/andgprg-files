using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{

    public GunScript gunToTrack;
    public Text bulletCount;
    public Text reloadText;

    public Text results;
    public GameObject player;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        results.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemy == null) {
            results.enabled = true;
            results.text = "You Win!";
            return;
        }

        if (player.GetComponent<PlayerBehaviorScript>().health <= 0) {
            results.enabled = true;
            results.text = "You Lose!";
            return;
        }


        int gunBullets = gunToTrack.totalBullets;

        if (gunBullets > 10)
            bulletCount.color = Color.black;

        if (gunBullets < 10 && gunBullets > 0)
            bulletCount.color = new Vector4(1.0f, 0.65f, 0.0f, 1.0f);

        if (gunBullets == 0)
            bulletCount.color = Color.red;

        if (gunBullets > 0)
            bulletCount.text = "Bullets: " + gunBullets;
        else
            bulletCount.text = "Bullets: Empty";

        if (gunToTrack.reloading)
            reloadText.enabled = true;
        else
            reloadText.enabled = false;

            
    }
}
