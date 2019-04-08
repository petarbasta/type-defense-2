using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameHasEnded = false;

    public static void EndGame()
    {
        if (!gameHasEnded)
        {
            gameHasEnded = true;
            Debug.Log("Game Over");
            GameManager.Restart();
        }
    }

    public static void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene("PlayScreen");
    }
}
