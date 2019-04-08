using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public static float startTime;
    public static Text score;

    // Start is called before the first frame update
    void Start()
    {
        ScoreCounter.score = GetComponent<Text>();
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("F2");

        ScoreCounter.score.text = minutes + ":" + seconds;;
    }
}
