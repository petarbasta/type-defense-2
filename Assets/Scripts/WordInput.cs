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
    public Text word;
    public Image keyboardHeightLine;

    public string currentWord = "";
    public static int keyboardHeight = 0;

    void Start()
    {
        keyboardHeightLine.rectTransform.sizeDelta = new Vector2(Screen.width*2, 10);

        openKeyboardObject = GameObject.Find("Open Keyboard Object");
        openKeyboardObject.SetActive(true);
        openKeyboardButton.onClick.AddListener(OpenKeyboard);

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
        if (gameManager.gameHasEnded)
        {
            openKeyboardObject.SetActive(false);
            inputField.DeactivateInputField();
            keyboardHeightLine.transform.position = new Vector3(Screen.width/2, -10, 0);
        }
        else
        {
            keyboardHeightLine.transform.position = new Vector3(Screen.width/2, keyboardHeight, 0);
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

    public void OpenKeyboard()
    {
        inputField.ActivateInputField();
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

