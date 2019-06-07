using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WordDisplay : MonoBehaviour
{
  public TextMeshProUGUI text;
  public HealthManager healthManager;
  public GameManager gameManager;
  public ScoreCounter scoreCounter;
  public WordManager wordManager;
  
  public bool hasBeenTyped = false;
  public bool hasTriggeredNextWord = false;
  public int timeBetweenWaves = 2;

  public void Start()
  {
    wordManager = FindObjectOfType<WordManager>();
    healthManager = FindObjectOfType<HealthManager>();
    gameManager = FindObjectOfType<GameManager>();
    scoreCounter = FindObjectOfType<ScoreCounter>();
  }

  public void SetWord(string word)
  {
    text.text = word;
    text.font = GameManager.currentFont;
    text.color = GameManager.currentFontColor;
  }

  public void RemoveWord()
  {
    hasBeenTyped = true;
    WordCleared();
    healthManager.AddHealth(text.text.Length);
    scoreCounter.UpdateScore(text.text);

    text.color = Color.red;
    text.CrossFadeAlpha(0f, 1.0f, false);
  }

  private void Update()
  {
    if (SaveLoad.playerProgress.nuke.isActive)
    {
      RemoveWord();
    }

    if (gameManager.removeAllWords)
    {
      Destroy(gameObject);
    }

    if (gameObject.transform.position.y < gameManager.dropHeight && !hasTriggeredNextWord)
    {
      hasTriggeredNextWord = true;
      if (GameManager.generate)
      {
        wordManager.AddWord();
        
        if (gameManager.dropHeight < Screen.height * 1.13f)
        {
          gameManager.dropHeight += (Screen.height*1.15f - gameManager.dropHeight) * 0.016f;
        }
      }
    }
    
    if (gameObject.transform.position.y > WordInput.keyboardHeight)
    {
      if (!SaveLoad.playerProgress.freeze.isActive)
      {
        if (!SaveLoad.playerProgress.slow.isActive)
        {
          transform.Translate(0f, -GameManager.fallSpeed * Time.deltaTime, 0);
        }
        else
        {
          transform.Translate(0f, -SaveLoad.playerProgress.slow.amount * Time.deltaTime, 0);
        }
      }
    }
    else if (!hasBeenTyped)
    {
      healthManager.SubtractHealth(text.text.Length);
      WordCleared();
      Destroy(gameObject);
    }
    else 
    {
      Destroy(gameObject);
    }
  }

  private void WordCleared()
  {
    gameManager.numberCleared++;

    if (gameManager.numberCleared == gameManager.waveSize)
    {
      var currentTime = Time.time;

      gameManager.waveSize += gameManager.waveIncrementer;
      gameManager.numberSpawned = 0;
      gameManager.numberCleared = 0;
      if (!SaveLoad.playerProgress.freeze.isActive)
      {
        GameManager.generate = true;
      }
      GameManager.dropFrom = gameManager.dropHeight + 200f;
      wordManager.AddWord();
      GameManager.dropFrom = Screen.height * 1.15f;

    }
  }
}
