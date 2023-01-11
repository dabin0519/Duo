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
    private Person person;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        person = GetComponent<Person>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ColliderType.Enemy && collision.gameObject.tag == "Attack")
        {
            enemy.OnDie = true;
        }

        if(type == ColliderType.Person && collision.gameObject.tag == "Attack")
        {
            person.OnDie();
        }
    }
}
