using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class GameManager : MonoBehaviour
{
    public static string lastScene;

    public static float fallSpeed;
    public static float wordDelay;
    public int waveIncrementer;
    public int waveSize = 7;
    public int numberSpawned = 0;
    public int numberCleared = 0;
    public static bool gameHasEnded = false;
    public static int goldEarned;
    public bool removeAllWords = false;
    public static bool generate;

    public TMP_FontAsset[] fonts;
    public static TMP_FontAsset currentFont;

    public Color[] fontColors;
    public static Color currentFontColor;
    
    public Sprite[] backgrounds;
    public Image currentBackground;

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

    public QuitPowerup quit;

    public Button restartButton;
    public Button highscoresButton;
    public Button storeButton;
    public Button optionsButton;
    public Button homeButton;

    public TextMeshProUGUI highscoreText;
    public TextMeshProUGUI goldEarnedText;
    public TextMeshProUGUI totalGoldText;
    public TextMeshProUGUI careerGoldText;

    public GameObject gameOverMenu;
    public ScoreCounter scoreCounter;
    public WordTimer wordTimer;
    public HealthManager healthManager;

    void Start()
    {   
        FindObjects();
        AddListeners();
        InitializeVariables();
        SaveLoad.playerProgress.nuke.CheckIfLocked(lockSprite, nukeImage);
        SaveLoad.playerProgress.freeze.CheckIfLocked(lockSprite, freezeImage);
    }

    void Update()
    {
        SaveLoad.playerProgress.nuke.CheckCoolDown(nukeCooldownImage);
        SaveLoad.playerProgress.freeze.CheckCoolDown(freezeCooldownImage);
        SaveLoad.playerProgress.slow.CheckCoolDown(slowCooldownImage);

        SaveLoad.playerProgress.nuke.CheckIfComplete();
        SaveLoad.playerProgress.freeze.CheckIfComplete(wordTimer);
        SaveLoad.playerProgress.slow.CheckIfComplete(wordTimer);
    }

    public void EndGame()
    {
        if (!gameHasEnded)
        {   
            goldEarned = 5 + ScoreCounter.score / 2100;
            SaveLoad.playerProgress.careerGold += goldEarned;
            SaveLoad.playerProgress.gold += goldEarned;
            goldEarnedText.text = "+" + ((goldEarned).ToString("0,0,0")).TrimStart(new Char[] { '0' } );
            totalGoldText.text = "Gold: " + (SaveLoad.playerProgress.gold.ToString("0,0,0")).TrimStart(new Char[] { '0' } );
            careerGoldText.text = "Career Gold: " + (SaveLoad.playerProgress.careerGold.ToString("0,0,0")).TrimStart(new Char[] { '0' } );

            if (ScoreCounter.score > SaveLoad.playerProgress.highscore)
            {
                SaveLoad.playerProgress.highscore = ScoreCounter.score;
                highscoreText.text = "Highscore: " + SaveLoad.playerProgress.highscore.ToString("0,0,0");
            }

            unlockBackgrounds();

            SaveLoad.Save();
            ClearScreen();
            gameOverMenu.SetActive(true);
        }
    }

    public void unlockBackgrounds()
    {
        if (SaveLoad.playerProgress.careerGold > 5000)
        {
            SaveLoad.playerProgress.backgroundsUnlocked[5] = true;
        }
        else if (SaveLoad.playerProgress.careerGold > 2000)
        {
            SaveLoad.playerProgress.backgroundsUnlocked[4] = true;
        }
        else if (SaveLoad.playerProgress.careerGold > 1000)
        {
            SaveLoad.playerProgress.backgroundsUnlocked[3] = true;
        }
        else if (SaveLoad.playerProgress.careerGold > 500)
        {
            SaveLoad.playerProgress.backgroundsUnlocked[2] = true;
        }
        else if (SaveLoad.playerProgress.careerGold > 200)
        {
            SaveLoad.playerProgress.backgroundsUnlocked[1] = true;
        }
    }

    public void ClearScreen()
    {
        SaveLoad.playerProgress.nuke.Reset(nukeCooldownImage);
        SaveLoad.playerProgress.freeze.Reset(freezeCooldownImage);
        SaveLoad.playerProgress.slow.Reset(slowCooldownImage);

        gameHasEnded = true;
        removeAllWords = true;
        generate = false;
    }

    public void Restart()
    {
        gameHasEnded = false;
        SceneManager.LoadScene("PlayScreen");
    }

    public void Highscores()
    {
    }

    public void Store()
    {
        lastScene = "PlayScreen";
        SceneManager.LoadScene("StoreScreen");
    }

    public void Options()
    {
    }

    public void Home()
    {
        gameHasEnded = false;
        SceneManager.LoadScene("StartScreen");
    }

    public void TriggerQuit()
    {
        quit.Trigger();
    }

    public void TriggerNuke()
    {
        SaveLoad.playerProgress.nuke.Trigger(nukeCooldownImage);
    }

    public void TriggerFreeze()
    {
        SaveLoad.playerProgress.freeze.Trigger(wordTimer, freezeCooldownImage);
    }

    public void TriggerSlow()
    {
        SaveLoad.playerProgress.slow.Trigger(slowCooldownImage);
    }

    public void InitializeVariables()
    {
        if (!gameHasEnded)
        {
            gameOverMenu.SetActive(false);
            ScoreCounter.score = 0;
            goldEarned = 0;
            HealthManager.health = 100;
            generate = true;
        }
        else
        {   
            gameOverMenu.SetActive(true);
        }

        goldEarnedText.text = "+" + ((goldEarned).ToString("0,0,0")).TrimStart(new Char[] { '0' } );
        totalGoldText.text = "Total: " + (SaveLoad.playerProgress.gold.ToString("0,0,0")).TrimStart(new Char[] { '0' } );
        careerGoldText.text = "Career Gold: " + (SaveLoad.playerProgress.careerGold.ToString("0,0,0")).TrimStart(new Char[] { '0' } );

        highscoreText.text = "Highscore: " + SaveLoad.playerProgress.highscore.ToString("0,0,0");
        scoreCounter.scoreText.text = "" + ScoreCounter.score;
        healthManager.healthText.text = "" + HealthManager.health;

        currentFont = fonts[SaveLoad.playerProgress.currentFont];
        currentFontColor = fontColors[SaveLoad.playerProgress.currentFontColor];
        currentBackground.sprite = backgrounds[SaveLoad.playerProgress.currentBackground];

        waveIncrementer = 2;
        fallSpeed = 125;
        wordDelay = 1.15f;
    }

    public void AddListeners()
    {
        restartButton.onClick.AddListener(Restart);
        highscoresButton.onClick.AddListener(Highscores);
        storeButton.onClick.AddListener(Store);
        optionsButton.onClick.AddListener(Options);
        homeButton.onClick.AddListener(Home);
    }

    public void FindObjects()
    {
        scoreCounter = FindObjectOfType<ScoreCounter>();
        wordTimer = FindObjectOfType<WordTimer>();
        healthManager = FindObjectOfType<HealthManager>();
    }
}
