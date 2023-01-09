using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Image healthImage;

    public int Health
    {
        get { return health; }
        set { health = value; }
    }
    private int health = 0;

    private void Start()
    {
        health = 3;
    }

    void Update()
    {
        if(health == 0)
        {
            //player die
            Destroy(gameObject);
            healthImage.fillAmount = 0;
        }
    }

    public void OnDamage()
    {
        healthImage.fillAmount -= 0.3f;
        Health--;
    }
}
