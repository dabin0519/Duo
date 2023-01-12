using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoad : MonoBehaviour
{
    public GameObject htp;

    public void Sceneload(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void OnHTP(bool on)
    {
        htp.SetActive(on);
    }
}
