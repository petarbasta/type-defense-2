using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FontColor : MonoBehaviour
{
    public int fontColorID;

    public StoreManager storeManager;

    void Start()
    {
        storeManager = FindObjectOfType<StoreManager>();
    }

    public void SetFont()
    {
        SaveLoad.playerProgress.currentFontColor = fontColorID;
        Debug.Log(SaveLoad.playerProgress.currentFontColor);
        storeManager.SetFontColors();
        SaveLoad.Save();
    }
}
