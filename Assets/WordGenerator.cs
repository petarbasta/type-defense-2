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

    public int poolNumber = 0;
    public List<List<string>> pools = new List<List<string>>();


    public string GetRandomWord()
    {
        Debug.Log(poolNumber);
        if (pools[poolNumber].Count <= 0)
        {
            poolNumber++;
        }

        int randomIndex = UnityEngine.Random.Range(0,pools[poolNumber].Count);
        string randomWord = pools[poolNumber][randomIndex];
        pools[poolNumber].Remove(randomWord);
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
        MakePools();
    }

    public void MakePools()
    {
        List<string> poolZero = new List<string>();
        List<string> poolOne = new List<string>();

        /*
        List<string> poolTwo = new List<string>();
        List<string> poolThree = new List<string>();
        List<string> poolFour = new List<string>();
        List<string> poolFive = new List<string>();
        List<string> poolSix = new List<string>();
        List<string> poolSeven = new List<string>();
        List<string> poolEight = new List<string>();
        List<string> poolOne = new List<string>();
        List<string> poolNine = new List<string>();
        */

        //Pool 0
        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[3 - minNumberOfLetters].Length);
            string randomWord = words[3 - minNumberOfLetters][randomIndex];
            poolZero.Add(randomWord);
        }

        //Pool 1
        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[3 - minNumberOfLetters].Length);
            string randomWord = words[3 - minNumberOfLetters][randomIndex];
            poolOne.Add(randomWord);
        }

        for (int i = 0; i < 6; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolOne.Add(randomWord);
        }

        pools.Add(poolZero);
        pools.Add(poolOne);
    }
}