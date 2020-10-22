using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveCapsule {
    public Wave mWave;
    public int position;
}

public class WaveSystem : MonoBehaviour
{

    

    public Wave[] waves;
    private List<WaveCapsule> wavesList = new List<WaveCapsule>();
    private int totalWeight = 0;

    private bool startWaves = false;
    public float timeTillNextWave = 5.0f;

    public float xSpawnBoundary;

    public int currentWave = 1;

    public Vector2 spawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        // Add to list with position
        foreach (Wave wave in waves) {
            wavesList.Add(new WaveCapsule() { mWave = wave, position = totalWeight });
            totalWeight += wave.waveChance;
        }       
    }

    // Update is called once per frame
    void Update()
    {
        if (!startWaves) return;

        // Start countdown with last enemy dead
        GameObject lastenemy = GameObject.FindWithTag("Respawn");
        if (lastenemy == null) {
            timeTillNextWave -= Time.deltaTime;
        }
      
        if (timeTillNextWave > 0) return;

        //Spawn new enemies
        WaveHandler();

    }

    void WaveHandler() {
        Wave wave = wavesList[wavesList.Count - 1].mWave; ;

        float randomFloat = UnityEngine.Random.Range(0.0f, totalWeight);
        
        for (int i = wavesList.Count - 1; i >= 0; i--) {         
            if (wavesList[i].position < randomFloat) {
                Debug.Log(wavesList[i].position + " < " + randomFloat);
                wave = wavesList[i].mWave;
                break;
            }               
        }

        //float miniWaves = wave.divideToMiniWave;
        //float spawnFromEachMiniWave = wave.enemyCount / wave.divideToMiniWave;
        //float totalSpawned = spawnFromEachMiniWave;
        Ship spawn = wave.mainEnemyToSpawn.GetComponent<Ship>();
        timeTillNextWave = 10.0f;

        int amountToSpawn = wave.enemyCount;


        switch (spawn.type) {
            case ShipType.Standard:
                //Just spawn one 
                amountToSpawn = 1;
                break;
            case ShipType.Missile:
                //Instantiate(wave.mainEnemyToSpawn, spawnLocation, transform.rotation);
                break;
            case ShipType.Bomber:

                break;
            case ShipType.UFO:

                break;
            case ShipType.Bonus:

                break;

            case ShipType.Player:
                // Nope
                break;
        }

        for (int i = 0; i < amountToSpawn; i++) {
            spawnLocation.x = UnityEngine.Random.Range(-xSpawnBoundary, xSpawnBoundary);
            Instantiate(wave.mainEnemyToSpawn, spawnLocation, transform.rotation);
        }

        if (!wave.isNotReallyAWave) currentWave++;
    }

    public void EnableWave() {
        startWaves = true;
    }
}
