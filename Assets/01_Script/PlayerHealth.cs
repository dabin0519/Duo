using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health
    {
        get { return health; }
        set { health = value; }
    }

    private void Start()
    {
        health = 3;
    }

    void Update()
    {
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
}
