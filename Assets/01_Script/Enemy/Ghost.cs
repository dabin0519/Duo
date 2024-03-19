using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ghost : MonoBehaviour
{
    public float _duration;

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

        if (gameObject.transform.position.y <= -7 && _boxCollider.enabled)
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

        StartCoroutine(WaitCoroutine());
    }

    public void FinishTeleport()
    {
        _movement.moveDirection = new Vector3(0, -1, 0);
    }

    public void OnDie()
    {
        if(_boxCollider.enabled)
        {
            _boxCollider.enabled = false;
            _enemyAnim.SetTrigger("Die");
        }
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        _scoreSystem.Score += 100;
    }

    private IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(_duration);

        int r = Random.Range(0, EnemySpawn.Instance.enemySpawnPos.Length);

        Vector2 changePos = EnemySpawn.Instance.enemySpawnPos[r].position;
        changePos.y = transform.position.y;
        transform.position = changePos;
    }
}
