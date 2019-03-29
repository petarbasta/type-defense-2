using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public string currentWord = "";
    public WordManager wordManager;
    public static Text word;

    public void Start(){
        WordInput.word = GetComponent<Text>();
        WordInput.word.text = "Start Typing!";
    }

    // Update is called once per frame
    void Update()
    {
        foreach(char letter in Input.inputString)
        {
            //Backspace
            if (letter == '\b') {
                if (currentWord.Length > 0){
                    currentWord = currentWord.Remove(currentWord.Length -1);
                }
            }
            //Add letter
            else
            {
                currentWord += letter;
            }

            bool completed = wordManager.TypeWord(currentWord);
            if (completed) {
                currentWord = "";       
            }
            WordInput.word.text = currentWord;
        }
    }
}
