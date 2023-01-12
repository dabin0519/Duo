using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreSystem : MonoBehaviour
{
    public TextMeshProUGUI scoreTxt;
    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    private int score;

    private void Update()
    {
        if(score >= 0)
        {
            scoreTxt.text = $"Score : {score}";
        }
        else if (score < 0)
        {
            score = 0;
        }
        
        if(score >= 1500)
        {
            SceneManager.LoadScene(2);
        }
    }
}
