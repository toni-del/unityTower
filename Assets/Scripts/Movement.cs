using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public GameObject allUnits;
    public GameObject allyTowerL, allyTowerR, enemyTowerL, enemyTowerR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < allUnits.transform.childCount; i++)
        {
            GameObject unit = allUnits.transform.GetChild(i).gameObject;
            if (unit.tag == "Ally")
            {
                unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z + unit.GetComponent<Stats>().speed * Time.deltaTime);
                //if (enemyTowerL != null)
                //    if (unit.transform.position.z > 9) Destroy(enemyTowerL);

            } else
            {
                unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * Time.deltaTime);
            }
        }
         
    }
}