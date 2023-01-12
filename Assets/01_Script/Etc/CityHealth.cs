using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CityHealth : MonoBehaviour
{
    public Image health;
    public bool boss;

    private void Update()
    {
        if(health.fillAmount == 0)
        {
            SceneManager.LoadScene("End(Fire)");
        }
    }

    public void OnDamage()
    {
        if(!boss) health.fillAmount -= 0.25f;
    }
}
