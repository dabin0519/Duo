using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Animator enemyAnim;
    private CircleCollider2D circleCollider;
    private ScoreSystem scoreSystem;
    private CityHealth cityHealth;

    private void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        enemyAnim = GetComponent<Animator>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            //마을 공격
            cityHealth.OnDamage();
            scoreSystem.Score -= 100;
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
