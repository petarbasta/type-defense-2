using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public int backgroundID;

    public StoreManager storeManager;
    public Image[] images;
    public Image lockObject;

    void Start()
    {
        
        storeManager = FindObjectOfType<StoreManager>();

        if (SaveLoad.playerProgress.backgroundsUnlocked[backgroundID])
        {
            images = GetComponentsInChildren<Image>();
            lockObject = images[4];
            Destroy(lockObject.gameObject);
        }
    }

    public void SetBackground()
    {
        SaveLoad.playerProgress.currentBackground = backgroundID;
        storeManager.SetBackgroundImages();
        SaveLoad.Save();
    }
}
