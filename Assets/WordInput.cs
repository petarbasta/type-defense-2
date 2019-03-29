using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordInput : MonoBehaviour
{
    public string currentWord = "";
    public WordManager wordManager;

    // Update is called once per frame
    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            //Finished Word
            if (letter == ' ' || letter == '\r'){
                wordManager.TypeWord(currentWord);
                currentWord = "";                
            }
            //Backspace
            else if (letter == '\b' && currentWord.Length > 0){
                currentWord = currentWord.Remove(currentWord.Length -1);
            }
            //Add letter
            else
            {
                currentWord += letter;
            }
        }
    }
}
