using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] spawnObj;
    public Transform[] enemySpawnPos;

    private bool isSpawn = true;

    private void Update()
    {
        if (isSpawn)
        {
            switch(RandomNum() / 10)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                    StartCoroutine(SpawnObj(0));
                    break;
                case 8:
                case 9:
                case 10:
                    StartCoroutine(SpawnObj(1));
                    break;
            }
        }
    }

    IEnumerator SpawnObj(int i)
    {
        isSpawn = false;
        int r = Random.Range(0, enemySpawnPos.Length);
        Instantiate(spawnObj[i], enemySpawnPos[r]);
        yield return new WaitForSeconds(2);
        isSpawn = true;
    }

    private int RandomNum()
    {
        return Random.Range(0, 100);
    }
}
