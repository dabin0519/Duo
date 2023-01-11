using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthImage;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    private PlayerController playerController;
    private Animator playerAnim;
    private EnemySpawn enemySpawn;
    private BackGroundScorll bGS;
    private BackGroundScroll2 bGS2;
    private int health = 0;
    private bool isDie;

    private void Start()
    {
        health = 3;
        playerController = GetComponent<PlayerController>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        playerAnim = GetComponent<Animator>();
        bGS = FindObjectOfType<BackGroundScorll>();
        bGS2 = FindObjectOfType<BackGroundScroll2>();
    }

    void Update()
    {
        if(health == 0 && !isDie)
        {
            //player die
            Die();
            isDie = true;
        }
    }

    private void Die()
    {
        playerController.OnDie();
        healthImage.fillAmount = 0;
        enemySpawn.enabled = false;
        StartCoroutine(SpeedDown());
    }

    IEnumerator SpeedDown()
    {
        while (!(bGS2.moveSpeed <= 0 && bGS.moveSpeed <= 0))
        {
            bGS.moveSpeed -= 1;
            bGS2.moveSpeed -= 1;
            yield return new WaitForSeconds(0.1f);
        }
    }

    public void OnDamage()
    {
        if(health != 0)
        {
            healthImage.fillAmount -= 0.3f;
            Health--;
            playerAnim.SetBool("IsHurt", true);
            playerAnim.SetBool("PlayerAttack", false);
            playerAnim.SetBool("PlayerAttack2", false);
        }
    }

    public void FinishHurt()
    {
        playerAnim.SetBool("IsHurt", false);
    }
}
