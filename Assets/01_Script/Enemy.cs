using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = FindObjectOfType<PlayerHealth>();
    }

    private void Update()
    {
        if(gameObject.transform.position.y <= -7)
        {
            Destroy(gameObject);
            playerHealth.health--;
        }
    }
}
