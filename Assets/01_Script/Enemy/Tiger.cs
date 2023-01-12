using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiger : MonoBehaviour
{
    private Animator tigerAnim;
    private CircleCollider2D circleCollider;
    private ScoreSystem scoreSystem;
    private CityHealth cityHealth;


    private void Start()
    {
        tigerAnim = GetComponent<Animator>();
        circleCollider = GetComponent<CircleCollider2D>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        if (gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            cityHealth.OnDamage();
            scoreSystem.Score -= 100;
        }
    }

    public void OnDie()
    {
        Destroy(circleCollider);
        tigerAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 150;
    }
}
