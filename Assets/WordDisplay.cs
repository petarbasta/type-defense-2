using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WordDisplay : MonoBehaviour
{
   public Text text;
   public static float fallSpeed = 100;

   public void SetWord(string word)
   {
     text.text = word;
   }

    public void RemoveWord()
    {
     text.color = Color.red;
     text.CrossFadeAlpha(0f, 1.0f, false);
     Destroy(gameObject, 1.0f);
     }

   private void Update()
   {
     if (gameObject.transform.position.y > WordInput.keyboardHeight + (Screen.height - WordInput.keyboardHeight)*0.02)
     {
        transform.Translate(0f, -fallSpeed * Time.deltaTime, 0);
     }
     if (gameObject.transform.position.y < (WordInput.keyboardHeight +(Screen.height - WordInput.keyboardHeight)*0.1f))
     {
          text.color = Color.blue;
     }

   }

}
