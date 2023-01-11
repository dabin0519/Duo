using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScroll2 : MonoBehaviour
{
    public Transform target;
    public float scrollRange;
    public float moveSpeed;
    public Vector3 moveDirection = Vector3.down;

    private void Update()
    {
        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if (transform.position.y <= -scrollRange)
        {
            transform.position = target.position + Vector3.up * scrollRange;
        }
    }
}
