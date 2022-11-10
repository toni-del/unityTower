using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotator : MonoBehaviour
{
    public GameObject light;
    void Update()
    {
        light.transform.Rotate(1f * Time.deltaTime, 0, 0); 
    }
}
