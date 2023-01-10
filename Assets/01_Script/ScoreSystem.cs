using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        scoreTxt.text = $"Score : {score}";
    }
}
