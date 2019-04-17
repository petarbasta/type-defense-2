using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Upgrade : MonoBehaviour
{
    public BufferPowerup bufferPowerup;

    public Sprite checkmarkSprite;
    public StoreManager storeManager;
    Image[] images;
    TextMeshProUGUI[] texts;
    Button button;

    // Start is called before the first frame update
    void Start()
    {
        storeManager = FindObjectOfType<StoreManager>();

        images = GetComponentsInChildren<Image>();
        button = GetComponentInChildren<Button>();
        texts = GetComponentsInChildren<TextMeshProUGUI>();
    }

    void Update()
    {
        SetUpgrades();
    }

    public void SetUpgrades()
    {
        if (button.interactable == true)
        {
            CheckIfMaxed();
        }
    
        int fillCheckmarks = 5;
        while (fillCheckmarks <= (3 + 2*bufferPowerup.level))
        {
            Image checkbox = images[fillCheckmarks];
            checkbox.sprite = checkmarkSprite;
            fillCheckmarks += 2;
        }
        
    }

    public void CheckIfMaxed()
    {
        if (bufferPowerup.level >= 5)
        {
            button.interactable = false;
            Image coin =  images[15];
            Destroy(coin.gameObject);
            TextMeshProUGUI priceText = texts[1];
            priceText.text = "MAX";
            Debug.Log("disabled");
        }
    }

    public bool PurchaseNextLevel()
    {        
        if (SaveLoad.playerProgress.gold > bufferPowerup.price)
        {
            SaveLoad.playerProgress.gold -= bufferPowerup.price;
            bufferPowerup.price *= 2;
            bufferPowerup.level++;

            storeManager.goldText.text = "" + SaveLoad.playerProgress.gold;
            
            TextMeshProUGUI priceText = texts[1];
            priceText.text = "" + bufferPowerup.price;

            CheckIfMaxed();

            Image checkbox = images[3 + 2*bufferPowerup.level];
            checkbox.sprite = checkmarkSprite;

            return true;
        }        
        return false;
    }

    public void DecreaseCooldown()
    {
        PurchaseNextLevel();
        bufferPowerup.powerup.cooldownLevel++;
        bufferPowerup.powerup.cooldown -= 3;
        SaveLoad.Save();

        Debug.Log("Cooldown: " + bufferPowerup.powerup.cooldown);        
    }

    public void IncreaseDuration()
    {
        PurchaseNextLevel();
        bufferPowerup.powerup.durationLevel++;
        bufferPowerup.powerup.duration += 1;
        SaveLoad.Save();

        Debug.Log("Duration: " + bufferPowerup.powerup.duration);        
    }

    public void IncreaseAmount()
    {
        PurchaseNextLevel();
        bufferPowerup.powerup.amountLevel++;
        bufferPowerup.powerup.amount -= 10;
        SaveLoad.Save();

        Debug.Log("Amount: " + bufferPowerup.powerup.amount);        
    }
}
