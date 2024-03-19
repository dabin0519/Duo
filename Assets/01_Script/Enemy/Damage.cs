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
    Oni,
    Ghost,
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
    private Oni _oni;
    private Ghost _ghost;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        boss = GetComponent<Boss>();
        enemy = GetComponent<Enemy>();
        person = GetComponent<Person>();
        fox = GetComponent<Fox>();
        tiger = GetComponent<Tiger>();
        playerHealth = GetComponent<PlayerHealth>();
        _oni = GetComponent<Oni>();
        _ghost = GetComponent<Ghost>();
    }

    private int RandomNum()
    {
        return Random.Range(0, 360);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Attack")
        {
            slashPrefab = Instantiate(effectPrefab, transform.position, Quaternion.Euler(0, 0, RandomNum()));
            Destroy(slashPrefab, effectTime);
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
            else if(type == ColliderType.Oni)
            {
                _oni.OnHurt();
            }
            else if(type == ColliderType.Ghost)
            {
                _ghost.OnDie();
            }
        }

        if(type == ColliderType.Player && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("??");
            playerHealth.OnDamage();
            StartCoroutine(Die(collision.gameObject));
        }
        else if(type == ColliderType.Player && collision.gameObject.tag == "Boss")
        {
            playerHealth.OnDamage();
        }
    }

    IEnumerator Die(GameObject gameObject)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
