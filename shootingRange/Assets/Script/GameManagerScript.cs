using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript : MonoBehaviour
{

    public Text timerText;
    public Text scoreText;

    public float gameTime = 30.0f;
    public int score = 0;

    public AudioClip clipScored; 
    private AudioSource audioSource;

    public delegate void GameEvent();
    public static event GameEvent TimeOut;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        TargetCylinderScript.OnHit += Score;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameTime >= 0) gameTime -= Time.deltaTime;
        if (gameTime < 0) {
            TimeOut?.Invoke();
            gameTime = 0;
        }
        timerText.text = gameTime.ToString("f0");       
    }

    void Score() {
        score++;
        audioSource.PlayOneShot(clipScored);
        scoreText.text = score.ToString();
    }
}
