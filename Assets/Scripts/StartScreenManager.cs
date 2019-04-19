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
    }

    public void LoadData()
    {
        if (SaveLoad.playerProgress == null)
        {
            SaveLoad.Load();
            //If first time playing
            if (SaveLoad.playerProgress == null)
            {   
                SaveLoad.playerProgress = new PlayerProgress();
                SaveLoad.Save();
            }
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
}
