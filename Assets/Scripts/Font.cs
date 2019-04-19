using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Font : MonoBehaviour
{
    public int fontID;
    public int price;

    public StoreManager storeManager;
    public Sprite checkmarkSprite;

    public Button purchaseOrSetFontButton;
    public TextMeshProUGUI purhcaseText;
    public Image coinImage;

    void Start()
    {
        price = 500;
        storeManager = FindObjectOfType<StoreManager>();
        storeManager.SetFontImages();

        if (SaveLoad.playerProgress.fontsUnlocked[fontID])
        {
            SetPurchased();
        }
    }

    public void PurchaseOrSetFont()
    {
        if (!SaveLoad.playerProgress.fontsUnlocked[fontID])
        {
            Purchase();
        }
        else
        {
            SetFont();
        }
        SaveLoad.Save();
    }

    public void SetFont()
    {
        SaveLoad.playerProgress.currentFont = fontID;
        Debug.Log(SaveLoad.playerProgress.currentFont);
        storeManager.SetFontImages();
    }

    public void Purchase()
    {
        Debug.Log("purchase");
        if (SaveLoad.playerProgress.gold > price)
        {
            SaveLoad.playerProgress.gold -= price;
            storeManager.goldText.text = "" + SaveLoad.playerProgress.gold;
            SaveLoad.playerProgress.fontsUnlocked[fontID] = true;
            SetFont();
            SetPurchased();
        }
    }

    public void SetPurchased()
    {
        coinImage.sprite = checkmarkSprite;
        purhcaseText.text = "Owned";
    }
}
