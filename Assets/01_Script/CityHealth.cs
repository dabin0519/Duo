using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CityHealth : MonoBehaviour
{
    public Image health;

    private void Update()
    {
        if(health.fillAmount == 0)
        {
            //Die
            Debug.Log("die");
        }
    }

    public void OnDamage()
    {
        health.fillAmount -= 0.25f;
    }
}
