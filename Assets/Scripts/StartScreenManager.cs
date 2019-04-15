using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public Button playButton;
    public Button highscoresButton;
    public Button storeButton;
    public Button optionsButton;

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
        AddListeners();
    }

    public void AddListeners()
    {
        playButton.onClick.AddListener(Play);
        highscoresButton.onClick.AddListener(Highscores);
        storeButton.onClick.AddListener(Store);
        optionsButton.onClick.AddListener(Options);
    }

    public void LoadData()
    {
        SaveLoad.Load();
        if (SaveLoad.playerProgress == null)
        {
            SaveLoad.playerProgress = new PlayerProgress();
        }
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayScreen");
    }

    public void Highscores()
    {
    }

    public void Store()
    {
        GameManager.lastScene = "StartScreen";
        SceneManager.LoadScene("StoreScreen");
    }

    public void Options()
    {
    }
}
