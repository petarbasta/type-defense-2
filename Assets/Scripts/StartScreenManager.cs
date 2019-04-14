using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreenManager : MonoBehaviour
{
    public Button playButton;
    public Button highscoresButton;
    public Button optionsButton;

    // Start is called before the first frame update
    void Start()
    {
        SaveLoad.Load();
        if (SaveLoad.playerProgress == null)
        {
            SaveLoad.playerProgress = new PlayerProgress();
        }

        playButton.onClick.AddListener(Play);
        optionsButton.onClick.AddListener(Options);

    }

    public void Play()
    {
        SceneManager.LoadScene("PlayScreen");
    }

    public void Options()
    {
    }
}
