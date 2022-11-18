using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GifTrofeyandMoney : MonoBehaviour
{
    public GameObject CountOfTrofeyText;
   public GameObject CountOfMoneyText;

    public static int CountOfTrofey;
    public static int CountOfMoney;

        public void Gif() {
            CountOfTrofey =Convert.ToInt32(CountOfTrofeyText.GetComponent<Text>().text)+1;
            CountOfMoney = Convert.ToInt32(CountOfMoneyText.GetComponent<Text>().text)+3;

        CountOfTrofeyText.GetComponent<Text>().text = Convert.ToString(CountOfTrofey);
        CountOfMoneyText.GetComponent<Text>().text = Convert.ToString(CountOfMoney);
    }
      
    
}
