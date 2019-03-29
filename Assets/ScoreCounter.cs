using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static int scoreValue = 0;
    public static Text score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.score = GetComponent<Text>();
        ScoreCounter.score.text = "" + ScoreCounter.scoreValue;
    }

    // Update is called once per frame
    public static void UpdateScore()
    {
        ScoreCounter.scoreValue += 1;
        ScoreCounter.score.text = "" + ScoreCounter.scoreValue;
    }
}
