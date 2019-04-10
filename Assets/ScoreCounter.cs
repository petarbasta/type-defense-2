using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    // Update is called once per frame
    public void UpdateScore(string word, float initialWordDelay)
    {
        score += (int) ((float) word.Length * 4f * 1.0/initialWordDelay * 100f);
        score = ((int) (score / 10)) * 10;
        scoreText.text = score.ToString("0,0,0");
    }
}
