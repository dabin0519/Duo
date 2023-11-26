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
            switch(RandomNum())
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                    StartCoroutine(SpawnObj(0));
                    break;
                case 5:
                case 6:
                    StartCoroutine(SpawnObj(1));
                    break;
                case 7:
                    StartCoroutine(SpawnObj(2));
                    break;
                case 8:
                    StartCoroutine(SpawnObj(3));
                    break;
                case 9:
                    StartCoroutine(SpawnObj(4));
                    break;
            }
        }
        else if(isSpawn && isBoss)
        {
            switch (RandomNum())
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    StartCoroutine(SpawnObj(0));
                    break;
                case 6:
                case 7:
                    StartCoroutine(SpawnObj(1));
                    break;
                case 8:
                case 9:
                    StartCoroutine(SpawnObj(2));
                    break;
            }
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
