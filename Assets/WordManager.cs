using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WordManager : MonoBehaviour
{
    public List<Word> words;
    public WordSpawner wordSpawner;
    public WordGenerator wordGenerator;

    public void Start()
    {
        wordGenerator.LoadAllWords();
    }

    public void AddWord()
    {
        WordDisplay wordDisplay = wordSpawner.SpawnWord();
        Word word = new Word(wordGenerator.GetRandomWord(3), wordDisplay);
        words.Add(word);
    }

    public bool TypeWord (string input)
    {
        foreach(Word word in words)
        {
            if (string.Compare(input,word.word) == 0)
            {
                ScoreCounter.UpdateScore();
                words.Remove(word);
                word.RemoveWord();
                return true;
            }
        }
        return false;
    }

    public void OnGUI()
    {
        int redZoneHeight = 4;
        if (Application.platform == RuntimePlatform.Android)
        {
            while (WordInput.keyboardHeight == 0)
            {
            }
            redZoneHeight = WordInput.keyboardHeight;
        }
        DrawQuad(new Rect(0,Screen.height*0.9f,Screen.width,Screen.height*0.1f), new Color(1,0,0,0.5f));

    }

    void DrawQuad(Rect position, Color color) {
     Texture2D texture = new Texture2D(1, 1);
     texture.SetPixel(0,0,color);
     texture.Apply();
     GUI.skin.box.normal.background = texture;
     GUI.Box(position, GUIContent.none);
 }

}
