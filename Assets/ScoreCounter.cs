using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public float startTime;
    public Text minutesAndSecondsTimer;
    public Text millisecondsTimer;
    public int minutes;
    public int seconds;
    public int milliseconds;


    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float t = Time.time - startTime;

        minutes = (int) t / 60;
        float temp = t % 60;
        seconds = (int) temp;
        milliseconds = (int) ((temp - seconds) *100);

        string zeroBuffer;
        if (seconds < 10)
        {
            zeroBuffer = "0";
        }
        else
        {
            zeroBuffer = "";
        }

        if (minutes != 0)
        {
            minutesAndSecondsTimer.text = minutes.ToString() + ":" + zeroBuffer + seconds.ToString();
        }
        else 
        {
            minutesAndSecondsTimer.text = zeroBuffer + seconds.ToString();
        }
        millisecondsTimer.text = milliseconds.ToString("F0");
    }
}
