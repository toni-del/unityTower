using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasChanger : MonoBehaviour
{
    public Canvas canvasStop;
    public Canvas canvasRun;

    public void StopShow()
    {
        canvasStop.enabled = false;
        canvasRun.gameObject.SetActive(true);
    }

}
