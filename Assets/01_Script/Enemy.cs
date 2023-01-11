using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Animator enemyAnim;
    private CircleCollider2D circleCollider;
    private ScoreSystem scoreSystem;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        circleCollider = GetComponent<CircleCollider2D>();
        enemyAnim = GetComponent<Animator>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            //마을 공격
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            playerHealth.OnDamage();
        }
    }

    public void OnDie()
    {
        Destroy(circleCollider);
        enemyAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 100;
    }
}
