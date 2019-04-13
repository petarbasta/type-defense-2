using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Word
{
    public string word;
    WordDisplay display;

    public Word (string _word, WordDisplay _display, float _initialWordDelay) 
    {
        word = _word;
        display = _display;
        display.SetWord(_word, _initialWordDelay);
    }

    public void RemoveWord()
    {   
        display.RemoveWord();
    }
}
