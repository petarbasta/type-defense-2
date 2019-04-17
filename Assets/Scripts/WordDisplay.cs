using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
  public Text text;
  public HealthManager healthManager;
  public GameManager gameManager;
  public ScoreCounter scoreCounter;
  public WordTimer wordTimer;
  
  public bool hasBeenTyped = false;
  public int timeBetweenWaves = 2;
  public float initialWordDelay;

  public void Start()
  {
    healthManager = FindObjectOfType<HealthManager>();
    gameManager = FindObjectOfType<GameManager>();
    scoreCounter = FindObjectOfType<ScoreCounter>();
    wordTimer = FindObjectOfType<WordTimer>();
  }

  public void SetWord(string word)
  {
    text.text = word;
    initialWordDelay = GameManager.wordDelay;
  }

  public void RemoveWord()
  {
    hasBeenTyped = true;
    WordCleared();
    healthManager.AddHealth(text.text.Length);
    scoreCounter.UpdateScore(text.text, initialWordDelay);

    text.color = Color.red;
    text.CrossFadeAlpha(0f, 1.0f, false);
    Destroy(gameObject, 0.5f);
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
  }

  private void WordCleared()
  {
    gameManager.numberCleared++;

    if (gameManager.numberCleared == gameManager.waveSize)
    {
      gameManager.waveSize += gameManager.waveIncrementer;
      gameManager.numberSpawned = 0;
      gameManager.numberCleared = 0;
      if (!SaveLoad.playerProgress.freeze.isActive)
      {
        GameManager.generate = true;
      }
      wordTimer.nextWordTime = Time.time + timeBetweenWaves;
    }
  }
}
