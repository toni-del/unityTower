using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoHomeAfterGame : MonoBehaviour
{
public void GoHome()
    {
        SceneManager.LoadScene(0);
    }
}
