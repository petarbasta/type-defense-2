using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordManager : MonoBehaviour
{

    public List<Word> words;
    public WordSpawner wordSpawner;

    private void Start()
    {
        AddWord();
        AddWord();
        AddWord();        
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
                words.Remove(word);
                word.RemoveWord();
                break;
            }
        }
    }

}
