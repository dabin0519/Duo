using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GuideElement : MonoBehaviour
{
    [HideInInspector] public GameObject enemyUIPrefab;
    [HideInInspector] public string text;
    [HideInInspector] public bool isBoss;

    [SerializeField] private Sprite _bossSprite;

    private GameObject _imageContainer;
    private TextMeshPro _tmp;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _imageContainer = transform.Find("Image").gameObject;
        _tmp = transform.Find("Text").GetComponent<TextMeshPro>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Init()
    {
        GameObject enemyUI;
        if (isBoss)
        {
            _spriteRenderer.sprite = _bossSprite;
            enemyUI = Instantiate(enemyUIPrefab, Vector3.zero, Quaternion.identity);
        }
        else
            enemyUI = Instantiate(enemyUIPrefab, _imageContainer.transform.position, Quaternion.identity);
        enemyUI.transform.parent = _imageContainer.transform;
        _tmp.text = text;
    }
}
