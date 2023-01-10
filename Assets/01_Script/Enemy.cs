using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerHealth playerHealth;
    private Animator enemyAnim;
    private CircleCollider2D circleCollider;
    private Rigidbody2D enemyRigid;
    private ScoreSystem scoreSystem;

    public bool OnDie
    {
        get;
        set;
    }

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
        circleCollider = GetComponent<CircleCollider2D>();
        enemyAnim = GetComponent<Animator>();
        enemyRigid = GetComponent<Rigidbody2D>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            //마을 공격
        }

        if(OnDie) Die();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(gameObject);
            playerHealth.OnDamage();
        }
    }

    private void Die()
    {
        Destroy(circleCollider);
        Destroy(enemyRigid);
        enemyAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 100;
    }
}
