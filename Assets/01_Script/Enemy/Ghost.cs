using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    private Animator _enemyAnim;
    private BoxCollider2D _boxCollider;
    private ScoreSystem _scoreSystem;
    private CityHealth _cityHealth;
    private Movement _movement;
    private EnemySpawn _enemySpawn;

    private bool _isSkill;

    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _enemyAnim = GetComponent<Animator>();
        _scoreSystem = FindObjectOfType<ScoreSystem>();
        _cityHealth = FindObjectOfType<CityHealth>();
        _movement = FindObjectOfType<Movement>();
        _enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    private void Update()
    {
        if (transform.position.y < 1.5f && !_isSkill)
        {
            _isSkill = true;
            ChangeLine();
        }

        if (gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            //마을 공격
            _cityHealth.OnDamage();
            _scoreSystem.Score -= 100;
        }
    }

    public void ChangeLine()
    {
        _movement.moveDirection = Vector3.zero;
        _enemyAnim.SetTrigger("Teleport");
    }

    public void OnDie()
    {
        Destroy(_boxCollider);
        _enemyAnim.SetTrigger("Die");
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        _scoreSystem.Score += 100;
    }
}
