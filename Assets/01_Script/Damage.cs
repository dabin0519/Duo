using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    Attack,
    Player,
    Enemy,
    Person,
    Fox
}

public class Damage : MonoBehaviour
{
    public ColliderType type;

    private Enemy enemy;
    private Person person;
    private Fox fox;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        person = GetComponent<Person>();
        fox = GetComponent<Fox>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ColliderType.Enemy && collision.gameObject.tag == "Attack")
        {
            enemy.OnDie();
        }

        if(type == ColliderType.Person && collision.gameObject.tag == "Attack")
        {
            person.OnDie();
        }

        if(type == ColliderType.Fox && collision.gameObject.tag == "Attack")
        {
            fox.OnDie();
        }
    }
}
