using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    // Start is called before
    public static float timeStart = 5;
    public Text timerText;
    void Start()
    {
        timerText.text = timeStart.ToString();  
    }

    // Update is called once per frame
    void Update()
    {
        if (timeStart <= 10)
        {
            timeStart += Time.deltaTime/2;
            timerText.text = Mathf.Round(timeStart).ToString();
        }

    }
}
