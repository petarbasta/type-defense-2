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
  }

  public void RemoveWord(float initialWordDelay)
  {
    WordCleared();
    healthManager.AddHealth(text.text.Length);
    scoreCounter.UpdateScore(text.text, initialWordDelay);

    text.color = Color.red;
    text.CrossFadeAlpha(0f, 1.0f, false);
    Destroy(gameObject, 0.5f);
  }

  private void Update()
  {
    if (gameManager.isNukeActive)
    {
      RemoveWord(wordTimer.wordDelay);
    }

    if (gameManager.removeAllWords)
    {
      Destroy(gameObject);
    }
    if (gameObject.transform.position.y > WordInput.keyboardHeight)
    {
      if (!gameManager.isFreezeActive)
      {
        transform.Translate(0f, -gameManager.fallSpeed * Time.deltaTime, 0);
      }
    }
    else
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
      gameManager.generate = true;
      wordTimer.nextWordTime = Time.time + 2f;
    }
  }
}
