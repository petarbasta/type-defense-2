using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordInput : MonoBehaviour
{
    public WordManager wordManager;
    public GameManager gameManager;
    public InputField inputField;

    public GameObject openKeyboardObject;
    public Button openKeyboardButton;
    public Text currentWordText;
    public Image keyboardHeightLine;

    public string currentWord = "";
    public static int keyboardHeight = 0;

    void Start()
    {
        keyboardHeightLine.rectTransform.sizeDelta = new Vector2(Screen.width*2, 10);

        gameManager = FindObjectOfType<GameManager>();
        openKeyboardObject = GameObject.Find("Open Keyboard Object");
        openKeyboardObject.SetActive(true);
        openKeyboardButton.onClick.AddListener(OpenKeyboard);

        inputField.ActivateInputField();

        if (Application.platform == RuntimePlatform.Android)
        {
            currentWordText.text = "";
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfGameEnded();
        CheckIfWordTyped();
        CheckIfPowerupTriggered();        

        if (Application.platform == RuntimePlatform.WindowsEditor)
        {

            currentWordText.text = inputField.text;
        }
        else if (Application.platform == RuntimePlatform.Android)
        {
            UpdateKeyboardSize();
        }
    }

    public void CheckIfGameEnded()
    {
        if (GameManager.gameHasEnded)
        {
            openKeyboardObject.SetActive(false);
            inputField.DeactivateInputField();
            keyboardHeightLine.transform.position = new Vector3(Screen.width/2, -10, 0);
        }
        else
        {
            keyboardHeightLine.transform.position = new Vector3(Screen.width/2, keyboardHeight, 0);
        }
    }

    public void CheckIfWordTyped()
    {
        bool completed = wordManager.TypeWord(inputField.text.ToLower());
        if (completed)
        {
           inputField.text = "";      
        }
    }

    public void CheckIfPowerupTriggered()
    {
        if (inputField.text.ToLower() == "nuke" && !SaveLoad.playerProgress.nuke.isOnCooldown && SaveLoad.playerProgress.nuke.isUnlocked)
        {
            gameManager.TriggerNuke();
            inputField.text = "";      

        }

        if (inputField.text.ToLower() == "freeze" && !SaveLoad.playerProgress.freeze.isOnCooldown && SaveLoad.playerProgress.freeze.isUnlocked)
        {
            gameManager.TriggerFreeze();
            inputField.text = "";      
        }

        if (inputField.text.ToLower() == "slow" && !SaveLoad.playerProgress.slow.isOnCooldown && !SaveLoad.playerProgress.freeze.isActive)
        {
            gameManager.TriggerSlow();
            inputField.text = "";      
        }

        if (inputField.text.ToLower() == "quit")
        {
            gameManager.TriggerQuit();
        }
    }

    public void OpenKeyboard()
    {
        inputField.ActivateInputField();
    }

    public void UpdateKeyboardSize()
    {
        using(AndroidJavaClass UnityClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
        {
            AndroidJavaObject View = UnityClass.GetStatic<AndroidJavaObject>("currentActivity").Get<AndroidJavaObject>("mUnityPlayer").Call<AndroidJavaObject>("getView");

            using(AndroidJavaObject Rct = new AndroidJavaObject("android.graphics.Rect"))
            {
                View.Call("getWindowVisibleDisplayFrame", Rct);

                int currentKeyboardHeight = Screen.height - Rct.Call<int>("height");

                if (currentKeyboardHeight > keyboardHeight)
                {
                    keyboardHeight = currentKeyboardHeight;
                }
            }
        }
    }
}

