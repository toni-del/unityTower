using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Mana : MonoBehaviour
{
    public GameObject mana;
    private void Start()
    {
        var couratiner = StartCoroutine(ChangeMana());
    }
    IEnumerator ChangeMana()
    {
        while (true)
        {
            if (Convert.ToInt32(mana.GetComponent<Text>().text) != 10)
                mana.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(mana.GetComponent<Text>().text) + 1);
            yield return new WaitForSeconds(3);
        }
    }
}
