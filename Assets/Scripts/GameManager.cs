using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float fallSpeed;
    public int waveIncrementer;
    public bool gameHasEnded = false;
    public bool removeAllWords = false;
    public bool generate = true;
    public int waveSize;
    public int numberSpawned;
    public int numberCleared;

    public Sprite lockSprite;

    public Image nukeImage;
    public Image nukeCooldownImage;
    public bool isNukeCooldown = false;
    public bool isNukeActive = false;

    public Image freezeImage;
    public Image freezeCooldownImage;
    public bool isFreezeCooldown = false;
    public bool isFreezeActive = false;
    public float freezeStartTime;

    public Image slowCooldownImage;
    public bool isSlowCooldown = false;
    public bool isSlowActive = false;
    public float slowStartTime;

    public float timeLeftOver;

    public Button restartButton;
    public Button highscoresButton;
    public Button homeButton;

    public GameObject gameOverCanvas;
    public ScoreCounter scoreCounter;
    public WordTimer wordTimer;


    void Start()
    {
        if (!SaveLoad.playerProgress.isNukeUnlocked)
        {
            nukeImage.sprite = lockSprite;
        }

        if (!SaveLoad.playerProgress.isFreezeUnlocked)
        {
            freezeImage.sprite = lockSprite;
        }

        scoreCounter = FindObjectOfType<ScoreCounter>();
        wordTimer = FindObjectOfType<WordTimer>();

        gameOverCanvas.SetActive(false);
        restartButton.onClick.AddListener(Restart);
        homeButton.onClick.AddListener(Home);

        waveIncrementer = 1;
        fallSpeed = 100;
        wordTimer.wordDelay = 1.75f; 
        waveSize = 6;
        numberSpawned = 0;
        numberCleared = 0;
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {
            freezeCooldownImage.fillAmount = 0;
            nukeCooldownImage.fillAmount = 0;

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

    public void TriggerSlow()
    {
        slowCooldownImage.fillAmount = 1;
        isSlowCooldown = true;
        isSlowActive = true;

        slowStartTime = Time.time;
    }

    public void TriggerQuit()
    {
        SceneManager.LoadScene("StartScreen");
    }

    void Update()
    {
        if (isNukeActive)
        {
            isNukeActive = false;
        }

        if (isFreezeActive && Time.time > SaveLoad.playerProgress.freezeLength + freezeStartTime)
        {
            generate = true;
            isFreezeActive = false;
            wordTimer.nextWordTime = Time.time + timeLeftOver;
        }

        if (isSlowActive && Time.time > SaveLoad.playerProgress.slowLength + slowStartTime)
        {
            isSlowActive = false;
        }
        
        if (isNukeCooldown)
        {
            nukeCooldownImage.fillAmount -= 1.0f / SaveLoad.playerProgress.nukeCooldown * Time.deltaTime;

            if (nukeCooldownImage.fillAmount == 0)
            {
                isNukeCooldown = false;
            }
        }

        if (isFreezeCooldown)
        {
            freezeCooldownImage.fillAmount -= 1.0f / SaveLoad.playerProgress.freezeCooldown * Time.deltaTime;

            if (freezeCooldownImage.fillAmount == 0)
            {
                isFreezeCooldown = false;
            }
        }

        if (isSlowCooldown)
        {
            slowCooldownImage.fillAmount -= 1.0f / SaveLoad.playerProgress.slowCooldown * Time.deltaTime;

            if (slowCooldownImage.fillAmount == 0)
            {
                isSlowCooldown = false;
            }
        }
    }
}
