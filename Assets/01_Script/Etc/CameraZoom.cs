using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    public bool zoomActive;
    public GameObject[] Target;
    public Camera cam;
    public float speed;

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        if (zoomActive)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 2, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, new Vector3(Target[1].transform.position.x,Target[1].transform.position.y,-10), speed);
        }
        else
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, 5, speed);
            cam.transform.position = Vector3.Lerp(cam.transform.position, Target[0].transform.position, speed);
        }
    }
}
