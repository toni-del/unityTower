using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrag : MonoBehaviour
{
    public GameObject arrowLeft, arrowRight;
    public void changeMode()
    {
        arrowLeft.SetActive(true);
        arrowRight.SetActive(true);
    }
}
