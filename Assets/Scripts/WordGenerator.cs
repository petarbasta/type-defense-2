using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class WordGenerator : MonoBehaviour
{
    public int minNumberOfLetters = 3;
    public int maxNumberOfLetters = 8;
    public string[][] words;
    public int poolNumber = 0;
    public List<List<string>> pools;
    public GameManager gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public string GetRandomWord()
    {   
        gameManager.numberSpawned++;

        if (gameManager.numberSpawned == gameManager.waveSize)
        {
            gameManager.generate = false;
        }

        if (pools[poolNumber].Count <= 0)
        {
            poolNumber++;
        }

        int randomIndex = UnityEngine.Random.Range(0,pools[poolNumber].Count);
        string randomWord = pools[poolNumber][randomIndex];
        if (poolNumber != 9)
        {
            pools[poolNumber].Remove(randomWord);
        }
        return randomWord;
    }

    public void LoadWords(int numberOfLetters)
    {
        string fileName = numberOfLetters + " Letter Words.txt";
        string filePath = Path.Combine (Application.streamingAssetsPath + "/", fileName);
        string text;
   
		if (Application.platform == RuntimePlatform.Android)
        {
            WWW reader = new WWW(filePath);
            while (!reader.isDone) { }
            text = reader.text;
            string[] tempWords = text.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            words[numberOfLetters - minNumberOfLetters] = tempWords;
		} 
        else 
        {
			text = File.ReadAllText (filePath);
            string[] tempWords = text.Split(new string[] {"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);
            words[numberOfLetters - minNumberOfLetters] = tempWords;
		}
    }

    public void LoadAllWords()
    {
        pools = new List<List<string>>();
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
        List<string> poolTwo = new List<string>();
        List<string> poolThree = new List<string>();
        List<string> poolFour = new List<string>();
        List<string> poolFive = new List<string>();
        List<string> poolSix = new List<string>();
        List<string> poolSeven = new List<string>();
        List<string> poolEight = new List<string>();
        List<string> poolNine = new List<string>();

        //Pool 0
        for (int i = 0; i < 3; i++){
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

        //Pool 2
        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[3 - minNumberOfLetters].Length);
            string randomWord = words[3 - minNumberOfLetters][randomIndex];
            poolTwo.Add(randomWord);
        }

        for (int i = 0; i < 5; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolTwo.Add(randomWord);
        }

        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolTwo.Add(randomWord);
        }

        //Pool 3
        for (int i = 0; i < 3; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[3 - minNumberOfLetters].Length);
            string randomWord = words[3 - minNumberOfLetters][randomIndex];
            poolThree.Add(randomWord);
        }

        for (int i = 0; i < 3; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolThree.Add(randomWord);
        }

        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolThree.Add(randomWord);
        } 

        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolThree.Add(randomWord);
        } 

        //Pool 4
        for (int i = 0; i < 2; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[3 - minNumberOfLetters].Length);
            string randomWord = words[3 - minNumberOfLetters][randomIndex];
            poolFour.Add(randomWord);
        }

        for (int i = 0; i < 3; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolFour.Add(randomWord);
        }

        for (int i = 0; i < 5; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolFour.Add(randomWord);
        } 

        for (int i = 0; i < 6; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolFour.Add(randomWord);
        } 

        //Pool 5
        for (int i = 0; i < 3; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolFive.Add(randomWord);
        }

        for (int i = 0; i < 5; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolFive.Add(randomWord);
        } 

        for (int i = 0; i < 8; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolFive.Add(randomWord);
        } 

        //Pool 6
        for (int i = 0; i < 3; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[4 - minNumberOfLetters].Length);
            string randomWord = words[4 - minNumberOfLetters][randomIndex];
            poolSix.Add(randomWord);
        }

        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolSix.Add(randomWord);
        } 

        for (int i = 0; i < 5; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolSix.Add(randomWord);
        } 

        for (int i = 0; i < 7; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[7 - minNumberOfLetters].Length);
            string randomWord = words[7 - minNumberOfLetters][randomIndex];
            poolSix.Add(randomWord);
        } 

        //Pool 7
        for (int i = 0; i < 7; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolSeven.Add(randomWord);
        } 

        for (int i = 0; i < 15; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolSeven.Add(randomWord);
        } 

        for (int i = 0; i < 15; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[7 - minNumberOfLetters].Length);
            string randomWord = words[7 - minNumberOfLetters][randomIndex];
            poolSeven.Add(randomWord);
        } 

        //Pool 8
        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[5 - minNumberOfLetters].Length);
            string randomWord = words[5 - minNumberOfLetters][randomIndex];
            poolEight.Add(randomWord);
        } 

        for (int i = 0; i < 4; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[6 - minNumberOfLetters].Length);
            string randomWord = words[6 - minNumberOfLetters][randomIndex];
            poolEight.Add(randomWord);
        } 

        for (int i = 0; i < 15; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[7 - minNumberOfLetters].Length);
            string randomWord = words[7 - minNumberOfLetters][randomIndex];
            poolEight.Add(randomWord);
        } 

        for (int i = 0; i < 20; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[8 - minNumberOfLetters].Length);
            string randomWord = words[8 - minNumberOfLetters][randomIndex];
            poolEight.Add(randomWord);
        } 

        //Pool 9
        for (int i = 0; i < 500; i++){
            int randomIndex = UnityEngine.Random.Range(0,words[8 - minNumberOfLetters].Length);
            string randomWord = words[8 - minNumberOfLetters][randomIndex];
            poolNine.Add(randomWord);
        } 

        pools.Add(poolZero);
        pools.Add(poolOne);
        pools.Add(poolTwo);
        pools.Add(poolThree);
        pools.Add(poolFour);
        pools.Add(poolFive);
        pools.Add(poolSix);
        pools.Add(poolSeven);
        pools.Add(poolEight);
        pools.Add(poolNine);
    }
}