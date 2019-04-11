using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelectManager : MonoBehaviour
{
    public Button easyButton;
    public Button mediumButton;
    public Button hardButton;
    
    // Start is called before the first frame update
    void Start()
    {
        easyButton.onClick.AddListener(Easy);
        mediumButton.onClick.AddListener(Medium);
        hardButton.onClick.AddListener(Hard);
    }

    public void Easy()
    {
        GameManager.difficulty = "Easy";
        SceneManager.LoadScene("PlayScreen");
    }

    public void Medium()
    {
        GameManager.difficulty = "Medium";
        SceneManager.LoadScene("PlayScreen");
    }

    public void Hard()
    {
        GameManager.difficulty = "Hard";
        SceneManager.LoadScene("PlayScreen");
    }
}
