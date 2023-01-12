using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Boss : MonoBehaviour
{
    public GameObject bossParents;
    public GameObject twinklePrefab;

    private Animator bossAnim;
    private EnemySpawn enemySpawn;

    public int BossHealth
    {
        get { return bossHealth; }
        set { bossHealth = value; }
    }
    private int bossHealth;

    private void Start()
    {
        bossAnim = GetComponent<Animator>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(AttackPattern());
        }
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DownPattern());
        }
    }

    IEnumerator AttackPattern()
    {
        enemySpawn.enabled = false;
        bossAnim.SetBool("IsWaiting", true);
        //보스 공격 전 경고
        int i = RandomNum();
        GameObject twinkleClone = Instantiate(twinklePrefab, new Vector3(i, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(twinkleClone);

        bossParents.transform.position = new Vector2(i, 3.5f);
        bossAnim.SetBool("IsAttack", true);
        yield return new WaitForSeconds(5f);
        enemySpawn.enabled = true; 
    }

    IEnumerator DownPattern()
    {
        bossParents.transform.DOMove(new Vector3(0, -2), 1f);
        yield return new WaitForSeconds(5f);
        bossParents.transform.DOMove(new Vector3(0, 3.5f), 1f);
    }

    private int RandomNum()
    {
        return Random.Range(-2, 2);
    }

    public void AttackFinish()
    {
        bossAnim.SetBool("IsAttack", false);
        bossAnim.SetBool("IsWaiting", false);
        bossParents.transform.position = new Vector3(0, 3.5f, 0);
    }

    public void OnHurt()
    {
        bossAnim.SetBool("IsHurt", true);
        bossHealth--;
    }

    public void FinishHurt()
    {
        bossAnim.SetBool("IsHurt", false);
    }
}
