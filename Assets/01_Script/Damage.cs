using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ColliderType
{
    Attack,
    Player,
    Enemy
}

public class Damage : MonoBehaviour
{
    public ColliderType type;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(type == ColliderType.Attack && collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
        }

        if(type == ColliderType.Player && collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
