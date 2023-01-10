using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    Attack,
    Player,
    Enemy,
    Person
}

public class Damage : MonoBehaviour
{
    public ColliderType type;

    private Enemy enemy;
    private Animator personAnim;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ColliderType.Enemy && collision.gameObject.tag == "Attack")
        {
            enemy.OnDie = true;
        }
        else if(type == ColliderType.Person && collision.gameObject.tag == "Attack")
        {
            personAnim = GetComponent<Animator>();
            personAnim.SetBool("IsDie", true);
        }
    }
}
