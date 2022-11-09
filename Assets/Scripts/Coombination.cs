using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coombination : MonoBehaviour
{
    public GameObject comp, arrowLeft, arrowRight, card;
    public Sprite[] cardsImage = new Sprite[3];
    public string firstElement;
    public string secondElement;
    public string element;
    public string result;
    Sprite img;

    public void AddElement()
    {
        changeModeF();
        if (firstElement == "")
        {
            firstElement = element;
            comp.SetActive(false);
        }
        else if (secondElement == "")
        {
            secondElement = element;
            comp.SetActive(false);
            CoombinateElements();
        }

        }
    public void CoombinateElements()
    {
        if ((firstElement == "water" && secondElement == "earth") || (firstElement == "earth" && secondElement == "water"))
        {
            result = "swamp";
            img = cardsImage[0];
        }
        else if ((firstElement == "water" && secondElement == "wind") || (firstElement == "wind" && secondElement == "water"))
        {
            result = "steam";
            img = cardsImage[1];
        }
        else if ((firstElement == "earth" && secondElement == "fire") || (firstElement == "fire" && secondElement == "earth"))
        {
            result = "lava";
            img = cardsImage[2];
        }
        firstElement = "";
        secondElement = "";
        arrowLeft.GetComponent<UnitSpawner>().element = result;
        arrowLeft.SetActive(true);
        arrowRight.GetComponent<UnitSpawner>().element = result;
        arrowRight.SetActive(true);
        card.GetComponent<Image>().sprite = img;
        card.SetActive(true);
    }
    public void changeModeF()
    {
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }
}
