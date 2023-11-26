using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMouse : MonoBehaviour
{
    private Transform _player;
    private PlayerHealth _playerHealth;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _player = GameObject.Find("Player").transform;
        _playerHealth = _player.GetComponent<PlayerHealth>();
        _spriteRenderer = _player.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerHealth.Health = 0;
            _spriteRenderer.enabled = false;
        }
    }
}
