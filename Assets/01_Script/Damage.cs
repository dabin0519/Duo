using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    Attack,
    Player,
    Enemy,
    Person,
    Fox,
    Tiger
}

public class Damage : MonoBehaviour
{
    public ColliderType type;

    private Enemy enemy;
    private Person person;
    private Fox fox;
    private Tiger tiger;
    private PlayerHealth playerHealth;

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        person = GetComponent<Person>();
        fox = GetComponent<Fox>();
        tiger = GetComponent<Tiger>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ColliderType.Enemy && collision.gameObject.tag == "Attack")
        {
            enemy.OnDie();
        }
        else if(type == ColliderType.Person && collision.gameObject.tag == "Attack")
        {
            person.OnDie();
        }
        else if(type == ColliderType.Fox && collision.gameObject.tag == "Attack")
        {
            fox.OnDie();
        }
        else if(type == ColliderType.Tiger && collision.gameObject.tag == "Attack")
        {
            tiger.OnDie();
        }
        else if(type == ColliderType.Player && collision.gameObject.tag == "Enemy")
        {
            playerHealth.OnDamage();
            Destroy(collision.gameObject);
        }
    }
}
