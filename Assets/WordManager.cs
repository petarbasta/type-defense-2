using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{

    public List<Word> words;
    public WordSpawner wordSpawner;
    private TouchScreenKeyboard keyboard;

    public void Start()
    {
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false);
    }

    public void AddWord()
    {
        WordDisplay wordDisplay = wordSpawner.SpawnWord();
        Word word = new Word(WordGenerator.GetRandomWord(), wordDisplay);
        Debug.Log(word.word);
        words.Add(word);
    }

    public void TypeWord (string input)
    {
        foreach(Word word in words)
        {
            if (string.Compare(input,word.word) == 0)
            {
                ScoreCounter.UpdateScore();
                words.Remove(word);
                word.RemoveWord();
                break;
            }
        }
    }

}
