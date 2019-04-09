using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            var sc = FindObjectOfType<ScoreCounter>();
            Debug.Log(sc.minutes * 60 + sc.seconds + sc.milliseconds / 100.0);
            Restart();
        }
    }

    public void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene("PlayScreen");
    }
}
