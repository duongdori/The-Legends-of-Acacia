using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;

    public int spawnCount;
    public int maxSpawnCount;
    private void Update()
    {
        if(spawnCount >= maxSpawnCount) return;
        
        Vector3 pos = new Vector3(Random.Range(0f, 55f), Random.Range(5f, 10f), 0f);
        GameObject newEnemy = Instantiate(enemyPrefab, pos, Quaternion.identity, transform);
        spawnCount++;
    }
}