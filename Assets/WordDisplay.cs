using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
  public Text text;
  public float fallSpeed = 125;
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

  public void RemoveWord(float initialFallSpeed)
  {
    WordCleared();
    scoreCounter.UpdateScore(text.text, initialFallSpeed);

    text.color = Color.red;
    text.CrossFadeAlpha(0f, 1.0f, false);
    Destroy(gameObject, 1.0f);
  }

  private void Update()
  {
    if (gameObject.transform.position.y > WordInput.keyboardHeight)
    {
      transform.Translate(0f, -fallSpeed * Time.deltaTime, 0);
    }
    else
    {
      healthManager.UpdateScore(text.text.Length);
      WordCleared();
      Destroy(gameObject);
    }
  }

  private void WordCleared()
  {
    gameManager.numberCleared++;

    if (gameManager.numberCleared == gameManager.waveSize)
    {
      gameManager.waveSize +=2;
      gameManager.numberSpawned = 0;
      gameManager.numberCleared = 0;
      gameManager.generate = true;
      wordTimer.nextWordTime = Time.time + 2f;
    }
  }
}
