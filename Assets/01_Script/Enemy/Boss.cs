using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    public GameObject bossParents;
    public GameObject twinklePrefab; 
    public Vector3 offset;
    public Image slider;

    private Animator bossAnim;
    private EnemySpawn enemySpawn;
    private int bossHealth;
    private bool isDie;

    private void Start()
    {
        bossHealth = 50;
        bossAnim = GetComponent<Animator>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        StartCoroutine(Pattern());
    }

    private void Update()
    {
        if(bossHealth <= 0 && !isDie)
        {
            isDie = true;
            bossAnim.SetBool("IsDie", true);
            StopAllCoroutines();
            SceneManager.LoadScene(4);
        }
        slider.transform.position = Camera.main.WorldToScreenPoint(transform.parent.position + offset);
    }
   

    IEnumerator Pattern()
    {
        while (bossHealth > 0)
        {
            StartCoroutine(SpawnEnemy());
            yield return new WaitForSeconds(10f);
            StartCoroutine(AttackPattern());
            yield return new WaitForSeconds(3f);
            StartCoroutine(AttackPattern());
            yield return new WaitForSeconds(3f);
            StartCoroutine(AttackPattern());
            yield return new WaitForSeconds(3f);
            StartCoroutine(DownPattern());
            yield return new WaitForSeconds(5f);
        }
    }

    IEnumerator SpawnEnemy()
    {
        enemySpawn.enabled = true;
        yield return new WaitForSeconds(10f);
        enemySpawn.enabled = false;
    }

    IEnumerator AttackPattern()
    {
        bossAnim.SetBool("IsWaiting", true);
        //보스 공격 전 경고
        int i = RandomNum();
        GameObject twinkleClone = Instantiate(twinklePrefab, new Vector3(i, 0, 0), Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Destroy(twinkleClone);

        bossParents.transform.position = new Vector2(i, 3.5f);
        bossAnim.SetBool("IsAttack", true);
    }

    IEnumerator DownPattern()
    {
        bossParents.transform.DOMove(new Vector3(0, -2), 1f);
        yield return new WaitForSeconds(5f);
        bossParents.transform.DOMove(new Vector3(0, 3.5f), 1f);
        bossAnim.SetBool("IsHurt", false);
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
        slider.fillAmount -= 0.02f;
    }

    public void FinishHurt()
    {
        bossAnim.SetBool("IsHurt", false);
    }

    public void FinishDie()
    {
        SceneManager.LoadScene("Dabin");
    }
}
