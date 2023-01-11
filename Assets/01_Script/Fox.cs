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
    private bool isChange;

    private void Start()
    {
        foxAnim = GetComponent<Animator>();
        foxEf = GetComponentInChildren<FoxEffect>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y < 1.5 && !isChange)
        {
            isChange = true;
            OnChange();
        }
    }

    private void  OnChange()
    {
        foxEf.OnEffect();
        foxAnim.SetBool("IsChange", true);
    }

    public void OnDie()
    {
        Destroy(capsuleCollider);
        foxAnim.SetBool("IsDie", true);
    }

    public void FinishDie()
    {
        Destroy(gameObject);
        scoreSystem.Score += 100;
    }
}
