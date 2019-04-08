using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;
    public static Text word;
    public InputField inputField;
    public static int keyboardHeight = 0;


    public void Start(){
        inputField.ActivateInputField();

        WordInput.word = GetComponent<Text>();
        WordInput.word.text = "Start Typing!";
    }

    // Update is called once per frame
    void Update()
    {

        inputField.ActivateInputField();

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            bool completed = wordManager.TypeWord(inputField.text.ToLower());
            if (completed) 
            {
                inputField.text = "";
            }
            WordInput.word.text = inputField.text;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            bool completed = wordManager.TypeWord(inputField.text.ToLower());
            if (completed) 
            {
                inputField.text = "";      
            }
        }
    }
}
