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
    Tiger,
    Boss
}

public class Damage : MonoBehaviour
{
    public ColliderType type;
    public AudioClip hitClip;
    public GameObject effectPrefab;
    public float effectTime;

    private Enemy enemy;
    private Person person;
    private Fox fox;
    private Tiger tiger;
    private Boss boss;
    private PlayerHealth playerHealth;
    private AudioSource audioSource;
    private GameObject slashPrefab;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boss = GetComponent<Boss>();
        enemy = GetComponent<Enemy>();
        person = GetComponent<Person>();
        fox = GetComponent<Fox>();
        tiger = GetComponent<Tiger>();
        playerHealth = GetComponent<PlayerHealth>();
    }

    private int RandomNum()
    {
        return Random.Range(0, 360);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            StartCoroutine(Effect());
            audioSource.clip = hitClip;
            audioSource.Play();
            if(type == ColliderType.Enemy)
            {
                enemy.OnDie();
            }
            else if(type == ColliderType.Person)
            {
                person.OnDie();
            }
            else if(type == ColliderType.Fox)
            {
                fox.OnDie();
            }
            else if(type == ColliderType.Tiger)
            {
                tiger.OnDie();
            }
            else if(type == ColliderType.Boss)
            {
                boss.OnHurt();
            }
        }

        if(type == ColliderType.Player && collision.gameObject.tag == "Enemy")
        {
            playerHealth.OnDamage();
            Destroy(collision.gameObject);
        }
        else if(type == ColliderType.Player && collision.gameObject.tag == "Boss")
        {
            playerHealth.OnDamage();
        }
    }

    IEnumerator Effect()
    {
        slashPrefab = Instantiate(effectPrefab, transform.position, Quaternion.Euler(0, 0, RandomNum()));
        yield return new WaitForSeconds(effectTime);
        Destroy(slashPrefab);
    }
}
