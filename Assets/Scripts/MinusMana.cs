using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinusMana : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mana.timeStart -= 3;
    }
}
