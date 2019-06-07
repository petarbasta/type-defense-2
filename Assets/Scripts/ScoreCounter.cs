using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    public static int score = 0;
    public TextMeshProUGUI scoreText;

    // Update is called once per frame
    public void UpdateScore(string word)
    {
        score += (int) ((float) word.Length * 348f + score * 0.03f);
        score = ((int) (score / 10)) * 10;
        scoreText.text = score.ToString("0,0,0");
    }
}
