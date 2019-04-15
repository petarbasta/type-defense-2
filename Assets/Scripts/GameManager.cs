using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public float wordDelay = 1.75f;
    public float fallSpeed;
    public int waveIncrementer;
    public int waveSize = 6;
    public int numberSpawned = 0;
    public int numberCleared = 0;
    public bool gameHasEnded = false;
    public bool removeAllWords = false;
    public bool generate;

    public Sprite lockSprite;

    public Image nukeImage;
    public Image nukeCooldownImage;
    public TextMeshProUGUI nukeText;

    public Image freezeImage;
    public Image freezeCooldownImage;
    public TextMeshProUGUI freezeText;

    public Image slowImage;
    public Image slowCooldownImage;
    public TextMeshProUGUI slowText;

    public PlayerProgress playerProgress;
    public QuitPowerup quit;

    public Button restartButton;
    public Button submitScoreButton;
    public Button storeButton;
    public Button optionsButton;
    public Button homeButton;

    public GameObject gameOverCanvas;
    public ScoreCounter scoreCounter;
    public WordTimer wordTimer;

    void Start()
    {   
        playerProgress = SaveLoad.playerProgress;

        FindObjects();
        AddListeners();
        InitializeVariables();
        playerProgress.nuke.CheckIfLocked(lockSprite, nukeImage);
        playerProgress.freeze.CheckIfLocked(lockSprite, freezeImage);

        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        playerProgress.nuke.CheckCoolDown(nukeCooldownImage);
        playerProgress.freeze.CheckCoolDown(freezeCooldownImage);
        playerProgress.slow.CheckCoolDown(slowCooldownImage);

        playerProgress.nuke.CheckIfComplete();
        playerProgress.freeze.CheckIfComplete(this, wordTimer);
        playerProgress.slow.CheckIfComplete();
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {   
            SaveLoad.playerProgress = playerProgress;
            Debug.Log(SaveLoad.playerProgress.nuke.cooldown);
            SaveLoad.Save();
            ClearScreen();
            gameOverCanvas.SetActive(true);
        }
    }

    public void ClearScreen()
    {
        playerProgress.nuke.Reset(nukeCooldownImage);
        playerProgress.freeze.Reset(freezeCooldownImage);
        playerProgress.slow.Reset(slowCooldownImage);

        gameHasEnded = true;
        removeAllWords = true;
        generate = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene("PlayScreen");
    }

    public void SubmitScore()
    {
    }

    public void Store()
    {
        SceneManager.LoadScene("StoreScreen");
    }

    public void Options()
    {
    }

    public void Home()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void TriggerQuit()
    {
        quit.Trigger();
    }

    public void TriggerNuke()
    {
        playerProgress.nuke.Trigger(nukeCooldownImage);
        
    }

    public void TriggerFreeze()
    {
        playerProgress.freeze.Trigger(this, wordTimer.nextWordTime, freezeCooldownImage);
    }

    public void TriggerSlow()
    {
        playerProgress.slow.Trigger(slowCooldownImage);
    }

    public void InitializeVariables()
    {
        waveIncrementer = 1;
        fallSpeed = 100;
        generate = true;
    }

    public void AddListeners()
    {
        restartButton.onClick.AddListener(Restart);
        submitScoreButton.onClick.AddListener(SubmitScore);
        storeButton.onClick.AddListener(Store);
        optionsButton.onClick.AddListener(Options);
        homeButton.onClick.AddListener(Home);
    }

    public void FindObjects()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        wordTimer = FindObjectOfType<WordTimer>();
    }
}
