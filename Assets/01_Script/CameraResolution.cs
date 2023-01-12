using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraResolution : MonoBehaviour
{
    private void Start()
    {
        SetResolution();   
    }

    private void SetResolution()
    {
        int setWidth = 900;
        int setHeight = 1600;

        Screen.SetResolution(setWidth, setHeight, true);
    }

    /*private void Awake()
    {
        Camera camera = GetComponent<Camera>();
        Rect rect = camera.rect;

        float scaleHegiht = ((float)Screen.width / Screen.height) / ((float) 9 / 16);
        float scaleWidth = 1f / scaleHegiht;
        if(scaleHegiht < 1)
        {
            rect.height = scaleHegiht;
            rect.y = (1f - scaleHegiht) / 2f;
        }
        else
        {
            rect.width = scaleWidth;
            rect.x = (1f - scaleWidth) / 2f;
        }
        camera.rect = rect;
    }*/
}
