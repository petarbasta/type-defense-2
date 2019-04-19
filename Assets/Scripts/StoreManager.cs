using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    public TextMeshProUGUI goldText;

    public GameObject nukeLockObject;
    public GameObject freezeLockObject;

    public Button nukeUnlockButton;
    public Button freezeUnlockButton;

    public Button backButton;

    public Image[] fontImages;

    public void SetFontImages()
    {
        for (int i = 0; i < fontImages.Length; i++)
        {
            fontImages[i].color = new Color(0,0,0,0);
        }
        fontImages[SaveLoad.playerProgress.currentFont].color = new Color(0,0,0,0.4f);
    }

    // Start is called before the first frame update
    void Start()
    {
        AddListeners();
        CheckLockedObjects();
        goldText.text = "" + SaveLoad.playerProgress.gold;
    }

    public void AddListeners()
    {
        nukeUnlockButton.onClick.AddListener(UnlockNuke);
        freezeUnlockButton.onClick.AddListener(UnlockFreeze);
        backButton.onClick.AddListener(Back);
    }

    public void CheckLockedObjects()
    {
        if (SaveLoad.playerProgress.nuke.isUnlocked)
        {
            nukeLockObject.SetActive(false);
        }

        if (SaveLoad.playerProgress.freeze.isUnlocked)
        {
            freezeLockObject.SetActive(false);
        }
    }

    public void UnlockNuke()
    {
        if (SaveLoad.playerProgress.gold > SaveLoad.playerProgress.nuke.unlockPrice)
        {
            nukeLockObject.SetActive(false);
            SaveLoad.playerProgress.gold -= SaveLoad.playerProgress.nuke.unlockPrice;
            SaveLoad.playerProgress.nuke.isUnlocked = true;
            goldText.text = "" + SaveLoad.playerProgress.gold;
            SaveLoad.Save();
        }
    }

    public void UnlockFreeze()
    {
        if (SaveLoad.playerProgress.gold > SaveLoad.playerProgress.freeze.unlockPrice)
        {
            freezeLockObject.SetActive(false);
            SaveLoad.playerProgress.gold -= SaveLoad.playerProgress.freeze.unlockPrice;
            SaveLoad.playerProgress.freeze.isUnlocked = true;
            goldText.text = "" + SaveLoad.playerProgress.gold;
            SaveLoad.Save();
        }
    }

    public void Back()
    {
        SceneManager.LoadScene(GameManager.lastScene);
    }
}
