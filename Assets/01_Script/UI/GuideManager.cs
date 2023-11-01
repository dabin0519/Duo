using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct Guide
{
    [TextArea(3, 5)]public string text;
    public GameObject prefab;
    public bool isBoss;
}

public class GuideManager : MonoBehaviour
{
    [SerializeField] private Guide[] _guide;
    [SerializeField] private GuideElement _guideElementPrefab;
    [SerializeField] private float _offset;

    private void Awake()
    {
        for (int i = 0; i < _guide.Length; ++i)
        {
            if(_guide[i].text == null || _guide[i].prefab == null)
            {
                Debug.LogError("Guide Element에 요소가 추가가 안되어있음");
            }

            GuideElement g = Instantiate(_guideElementPrefab, new Vector3(0, 4 - i * _offset), Quaternion.identity);
            
            g.isBoss = _guide[i].isBoss;
            g.text = _guide[i].text;
            g.enemyUIPrefab = _guide[i].prefab;

            g.Init();
        }
    }
}
