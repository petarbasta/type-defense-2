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
        playButton.onClick.AddListener(Play);
    }

    public void Play()
    {
        SceneManager.LoadScene("PlayScreen");
    }
}
