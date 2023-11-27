using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] spawnObj;
    public Transform[] enemySpawnPos;
    public float spawnTime = 2;
    public bool isBoss;

    private bool isSpawn = true;

    private void Update()
    {
        if (isSpawn && !isBoss)
        {
            int randIdx = Random.Range(0, spawnObj.Length);

            StartCoroutine(SpawnObj(randIdx));
        }
        else if(isSpawn && isBoss)
        {
            int randomIdx = Random.Range(0, spawnObj.Length - 1);
            StartCoroutine(SpawnObj(randomIdx));
        }
    }

    IEnumerator SpawnObj(int i)
    {
        isSpawn = false;
        int r = Random.Range(0, enemySpawnPos.Length);
        Instantiate(spawnObj[i], enemySpawnPos[r]);
        yield return new WaitForSeconds(spawnTime);
        isSpawn = true;
    }

    private int RandomNum()
    {
        return Random.Range(0, 10);
    }
}
