using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameManager;
    public GameObject trackedPlayer;
    public Ship trackedShip;
    public WaveSystem gameWaveScript;

    public int currentScore = 0;
    public TextMeshProUGUI wave;
    public TextMeshProUGUI score;
    public TextMeshProUGUI health;

    public GameObject gameOverMenu;
    public TextMeshProUGUI gameOverText;

    public Image healthBar;


    // Start is called before the first frame update
    void Start()
    {
        trackedPlayer = GameObject.FindGameObjectWithTag("Player");
        trackedShip = trackedPlayer.GetComponent<Ship>();
        gameWaveScript = gameManager.GetComponent<WaveSystem>();

        Ship.OnDestroyed += Scored;
    }

    // Update is called once per frame
    void Update() {
        wave.text = gameWaveScript.currentWave.ToString();
        score.text = "Score: " + currentScore.ToString();

        float healthPerc = trackedShip.health / 5.0f;
        healthBar.rectTransform.localScale = new Vector3(healthPerc, 1.0f, 1.0f);
        if (trackedShip.health >= 4) healthBar.color = Color.green;
        else if (trackedShip.health >= 2) healthBar.color = new Vector4(1.0f, 0.65f, 0.0f, 1.0f);
        else healthBar.color = Color.red;

        if (trackedPlayer != null) return;

        gameOverMenu.SetActive(true);
        gameOverText.text = "Total Score:" + currentScore.ToString();

    }



    public void Scored() {
        Debug.Log("Scored!");
        currentScore++;
    }
}
