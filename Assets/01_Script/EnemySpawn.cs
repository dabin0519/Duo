using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyNormal;
    public Transform[] enemySpawnPos;

    private bool isSpawn = true;

    private void Update()
    {
        if(isSpawn) StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        isSpawn = false;
        int r = Random.Range(0, enemySpawnPos.Length);
        Instantiate(enemyNormal, enemySpawnPos[r]);
        yield return new WaitForSeconds(2);
        isSpawn = true;
    }
}
