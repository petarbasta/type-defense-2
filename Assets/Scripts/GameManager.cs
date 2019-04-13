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

    public bool isNukeCooldown = false;
    public bool isNukeActive = false;
    public int nukeCooldown = 20;

    public bool isFreezeCooldown = false;
    public bool isFreezeActive = false;
    public int freezeCooldown = 15;
    public int freezeLength = 4;
    public float freezeStartTime;

    public float timeLeftOver;

    public GameObject gameOverCanvas;
    public Button restartButton;
    public Button highscoresButton;
    public Button homeButton;
    public Text difficultyText;
    public ScoreCounter scoreCounter;
    public WordTimer wordTimer;
    public Image nukeCooldownImage;
    public Image freezeCooldownImage;

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
            waveIncrementer = 1;
            fallSpeed = 110;
            wordTimer.wordDelay = 1.75f;
        }
        else if (difficulty == "Medium")
        {
            Debug.Log(difficulty);
            waveIncrementer = 1;
            fallSpeed = 135;
            wordTimer.wordDelay = 1.50f;
        }
        else if (difficulty == "Hard")
        {
            Debug.Log(difficulty);
            waveIncrementer = 1;
            fallSpeed = 160;
            wordTimer.wordDelay = 1.25f;
        }
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            freezeCooldownImage.fillAmount = 0;
            nukeCooldownImage.fillAmount = 0;

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

    public void TriggerNuke()
    {
        nukeCooldownImage.fillAmount = 1;
        isNukeCooldown = true;
        isNukeActive = true;
    }

    public void TriggerFreeze()
    {
        freezeCooldownImage.fillAmount = 1;
        isFreezeCooldown = true;
        generate = false;
        isFreezeActive = true;
        timeLeftOver = wordTimer.nextWordTime - Time.time;

        freezeStartTime = Time.time;
    }

    void Update()
    {
        if (isFreezeActive && Time.time > freezeLength + freezeStartTime)
        {
            generate = true;
            isFreezeActive = false;
            wordTimer.nextWordTime = Time.time + timeLeftOver;
        }

        if (isNukeActive)
        {
            isNukeActive = false;
        }

        if (isNukeCooldown)
        {
            nukeCooldownImage.fillAmount -= 1.0f / nukeCooldown * Time.deltaTime;

            if (nukeCooldownImage.fillAmount == 0)
            {
                isNukeCooldown = false;
            }
        }

        if (isFreezeCooldown)
        {
            freezeCooldownImage.fillAmount -= 1.0f / freezeCooldown * Time.deltaTime;

            if (freezeCooldownImage.fillAmount == 0)
            {
                isFreezeCooldown = false;
            }
        }
    }
}
