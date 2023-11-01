using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oni : MonoBehaviour
{
    private Animator _oniAnim;
    private CapsuleCollider2D _capsuleCollider;
    private ScoreSystem _scoreSystem;
    private CityHealth _cityHealth;

    private int _hp = 3;

    private void Awake()
    {
        _oniAnim = GetComponent<Animator>();
        _capsuleCollider = GetComponent<CapsuleCollider2D>();
        _scoreSystem = FindObjectOfType<ScoreSystem>();
        _cityHealth = FindObjectOfType<CityHealth>();
    }

    private void Update()
    {
        
    }

    public void OnHurt()
    {
        _hp--;

        if(_hp > 0)
        {

        }
        else
        {
            _oniAnim.SetTrigger("Die");
        }
    }
}
