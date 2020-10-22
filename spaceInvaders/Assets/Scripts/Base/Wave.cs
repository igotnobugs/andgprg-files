using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave")]
public class Wave : ScriptableObject
{
    // Weighted among other waves
    public bool isNotReallyAWave;
    public int waveChance;
    public GameObject mainEnemyToSpawn;
    public int enemyCount;
    public Vector3 SpawnLocation;
}
