using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public bool generate = true;
    public int waveSize = 6;
    public int numberSpawned = 0;
    public int numberCleared = 0;

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            var scoreCounter = FindObjectOfType<ScoreCounter>();
            Debug.Log(scoreCounter.score);
            Restart();
        }
    }

    public void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene("PlayScreen");
    }
}
