using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public string currentWord = "";
    public WordManager wordManager;
    public Text word;
    public static int keyboardHeight = 0;
    public InputField inputField;
    public GameManager gameManager;

    void Start()
    {
        inputField.ActivateInputField();

        gameManager = FindObjectOfType<GameManager>();
        if (Application.platform == RuntimePlatform.Android)
        {
            word.text = "";
        }

        inputField.onEndEdit = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.gameHasEnded)
        {
            inputField.ActivateInputField();
        }
        else
        {
            inputField.DeactivateInputField();
        }

        bool completed = wordManager.TypeWord(inputField.text.ToLower());
        if (completed) 
        {
           inputField.text = "";      
        }

        if (inputField.text.ToLower() == "nuke" && !gameManager.isNukeCooldown)
        {
            gameManager.TriggerNuke();
            inputField.text = "";      

        }

        if (inputField.text.ToLower() == "freeze" && !gameManager.isFreezeCooldown)
        {
            gameManager.TriggerFreeze();
            inputField.text = "";      
        }

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {
            
            word.text = inputField.text;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            int temp = (int) (GetKeyboardSize());
            if (temp > keyboardHeight)
            {
                keyboardHeight = temp;
            }
        }
    }

    public int GetKeyboardSize()
    {
        using(AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

            using(AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
            {
                View.Call("getWindowVisibleDisplayFrame", Rct);

                return Screen.height - Rct.Call<int>("height");
            }
        }
    }
}

