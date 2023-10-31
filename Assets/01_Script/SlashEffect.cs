using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashEffect : MonoBehaviour
{
    [SerializeField] private Color _color1;
    [SerializeField] private Color _color2;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.color = RadomColor();
    }

    private Color RadomColor()
    {
        float g = Random.Range(_color1.g, _color2.g);
        float b = Random.Range(_color1.b, _color2.b);
        Color color = new Color(_color1.r, g, b);
        return color;
    }
}
