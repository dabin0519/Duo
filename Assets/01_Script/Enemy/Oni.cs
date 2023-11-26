using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni : MonoBehaviour
{
    [SerializeField] private float _protectTime;
    [SerializeField] private float _protectPosY;
    [SerializeField] private GameObject _protect;
    [SerializeField] private int _hp = 3;

    private Animator _oniAnim;
    private CircleCollider2D _circleCollider;
    private ScoreSystem _scoreSystem;
    private CityHealth _cityHealth;
    private Movement _movement;


    private void Awake()
    {
        _oniAnim = GetComponent<Animator>();
        _circleCollider = GetComponent<CircleCollider2D>();
        _movement = GetComponent<Movement>();
        _scoreSystem = FindObjectOfType<ScoreSystem>();
        _cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            _cityHealth.OnDamage();
            _scoreSystem.Score -= 100;
        }
    }

    public void OnHurt()
    {
        _hp--;

        if(_hp > 0)
        {
            _oniAnim.SetBool("IsProtect", true);
            StartCoroutine(Protect());
        }
        else
        {
            _oniAnim.SetTrigger("Die");
            Destroy(_circleCollider);
        }
    }

    private IEnumerator Protect()
    {
        // 뒤로 밀리기
        _movement.enabled = false;
        Vector3 curPos =  transform.position;
        float time = 0;
        while(time < _protectTime)
        {
            transform.position = new Vector3(curPos.x, curPos.y + EaseOutQuad(time / _protectTime) * _protectPosY);
            time += Time.deltaTime;
            yield return null;
        }
        yield return new WaitForSeconds(0.2f);
        _movement.enabled = true;
        _oniAnim.SetBool("IsProtect", false);
    }

    private float EaseOutQuad(float x)
    {
        return 1 - (1 - x) * (1 - x);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        _scoreSystem.Score += 150;
    }
}
