using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static string difficulty;
    public float fallSpeed;
    public int waveIncrementer;
    public bool gameHasEnded = false;
    public bool removeAllWords = false;
    public bool generate = true;
    public int waveSize = 6;
    public int numberSpawned = 0;
    public int numberCleared = 0;
    public GameObject gameOverCanvas;
    public Button restartButton;
    public Button highscoresButton;
    public Button homeButton;
    public Text difficultyText;
    public ScoreCounter scoreCounter;
    public WordTimer wordTimer;

    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        wordTimer = FindObjectOfType<WordTimer>();

        gameOverCanvas.SetActive(false);
        restartButton.onClick.AddListener(Restart);
        homeButton.onClick.AddListener(Home);

        if (difficulty == "Easy")
        {
            Debug.Log(difficulty);
            waveIncrementer = 2;
            fallSpeed = 125;
            wordTimer.wordDelay = 1.75f;
        }
        else if (difficulty == "Medium")
        {
            Debug.Log(difficulty);
            waveIncrementer = 3;
            fallSpeed = 150;
            wordTimer.wordDelay = 1.5f;
        }
        else if (difficulty == "Hard")
        {
            Debug.Log(difficulty);
            waveIncrementer = 4;
            fallSpeed = 175;
            wordTimer.wordDelay = 1.25f;
        }

    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            difficultyText.text = difficulty;
            gameHasEnded = true;
            removeAllWords = true;
            generate = false;
            Debug.Log("Game Over");
            Debug.Log(scoreCounter.score);
            gameOverCanvas.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlayScreen");
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScreen");
    }
}
