using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    private Animator tigerAnim;
    private CircleCollider2D circleCollider;
    private ScoreSystem scoreSystem;
    private CityHealth cityHealth;

    private bool isDie = true;

    private void Start()
    {
        tigerAnim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -7 && !isDie)
        {
            Destroy(gameObject);
            cityHealth.OnDamage();
        }
    }

    public void OnDie()
    {
        isDie = true;
        Destroy(circleCollider);
        tigerAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 150;
    }
}
