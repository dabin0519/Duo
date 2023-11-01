using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageScale : MonoBehaviour
{
    private RectTransform _rect;

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();
        _rect.sizeDelta = new Vector2(Screen.width, Screen.height);
    }
}
