using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public string currentWord = "";
    public WordManager wordManager;
    public static Text word;
    private TouchScreenKeyboard keyboard;


    public void Start(){
        keyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.ASCIICapable, false);

        WordInput.word = GetComponent<Text>();
        WordInput.word.text = "Start Typing!";
    }

    // Update is called once per frame
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            foreach(char letter in Input.inputString)
            {
                //Backspace
                if (letter == '\b') 
                {
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
                if (completed) 
                {
                    currentWord = "";       
                }
                WordInput.word.text = currentWord;
            }
        }
		else if (Application.platform == RuntimePlatform.Android)
        {
            currentWord = keyboard.text;
            bool completed = wordManager.TypeWord(currentWord);
            if (completed) {
                currentWord = "";
                keyboard.text = "";      
            }
            WordInput.word.text = currentWord;
        }
        
      
    }
}
