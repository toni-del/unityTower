using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardsToMenu : MonoBehaviour
{
    public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
