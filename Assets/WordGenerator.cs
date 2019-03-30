using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WordGenerator : MonoBehaviour
{
    public int minNumberOfLetters = 3;
    public int maxNumberOfLetters = 4;
    public string[][] words;

    public string GetRandomWord(int numberOfLetters)
    {
        int randomIndex = UnityEngine.Random.Range(0,words[numberOfLetters - minNumberOfLetters].Length);
        string randomWord = words[numberOfLetters - minNumberOfLetters][randomIndex];
        return randomWord;
    }

    public IEnumerator LoadWords(int numberOfLetters)
    {

        string fileName = numberOfLetters + " Letter Words.txt";
        string filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
        string text;
	
		if (filePath.Contains ("://") || filePath.Contains (":///")) {
			UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get (filePath);
			yield return www.Send ();
			text = www.downloadHandler.text;
            string[] tempWords = text.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            words[numberOfLetters - minNumberOfLetters] = tempWords;

		} else {
			text = File.ReadAllText (filePath);
            string[] tempWords = text.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            words[numberOfLetters - minNumberOfLetters] = tempWords;
		}
    }

    public void LoadAllWords()
    {
        words = new string[maxNumberOfLetters - minNumberOfLetters + 1][];
        for (int i = minNumberOfLetters; i <= maxNumberOfLetters; i++ )
        {
            StartCoroutine ("LoadWords", i);
        }
    }
}