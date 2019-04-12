using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Word
{
    public string word;
    WordDisplay display;
    public GameManager gameManager;
    public float initialWordDelay;

    public Word (string _word, WordDisplay _display, GameManager _gameManager, float _initialWordDelay) 
    {
        word = _word;
        display = _display;
        gameManager = _gameManager;
        initialWordDelay = _initialWordDelay;
        display.SetWord(word);
    }

    public void RemoveWord()
    {   
        display.RemoveWord(initialWordDelay);
    }
}
