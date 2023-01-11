using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fox : MonoBehaviour
{
    public GameObject foxEffect;

    private Animator foxAnim;
    private FoxEffect foxEf;
    private ScoreSystem scoreSystem;
    private CapsuleCollider2D capsuleCollider;
    private CityHealth cityHealth;
    private bool isChange;
    private bool isDie = true;

    private void Start()
    {
        foxAnim = GetComponent<Animator>();
        foxEf = GetComponentInChildren<FoxEffect>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y < 1.5 && !isChange)
        {
            isChange = true;
            OnChange();
        }

        if (gameObject.transform.position.y <= -7 && !isDie)
        {
            Destroy(gameObject);
            cityHealth.OnDamage();
            //마을 공격
        }
    }

    private void  OnChange()
    {
        foxEf.OnEffect();
        foxAnim.SetBool("IsChange", true);
    }

    public void OnDie()
    {
        isDie = true;
        Destroy(capsuleCollider);
        foxAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 200;
    }
}
