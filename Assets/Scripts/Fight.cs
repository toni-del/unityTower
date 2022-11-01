using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Fight : MonoBehaviour
{
    public GameObject allUnits;
    UnityEngine.Coroutine allyPush;
    UnityEngine.Coroutine enemyPush;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int allyCount = 0, enemyCount, allyI = 0, enemyI = 0;
        for (int i = 0; i < allUnits.transform.childCount; i++)
        {
            GameObject unit = allUnits.transform.GetChild(i).gameObject;
            if (unit.tag == "Ally") allyCount++;
        }
        enemyCount = allUnits.transform.childCount - allyCount;
        GameObject[] allyUnits = new GameObject[allyCount];
        GameObject[] enemyUnits = new GameObject[enemyCount];
        for (int i = 0; i < allUnits.transform.childCount; i++)
        {
            GameObject unit = allUnits.transform.GetChild(i).gameObject;
            if (unit.tag == "Ally")
            {
                //unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z + unit.GetComponent<Stats>().speed * Time.deltaTime);
                allyUnits[allyI++] = unit;
                //if (enemyTowerL != null)
                //    if (unit.transform.position.z > 9) Destroy(enemyTowerL);

            }
            else
            {
                //unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * Time.deltaTime);
                enemyUnits[enemyI++] = unit;
            }
        }
        for (int i = 0; i < allyCount; i++)
        {
            for (int j = 0; j < enemyCount; j++)
            {
                if (near(allyUnits[i], enemyUnits[j]))
                {
                    //allyPush = StartCoroutine(pushing(allyUnits[i], false));
                    //enemyPush = StartCoroutine(pushing(enemyUnits[i], true));
                    allyUnits[i].transform.position = new Vector3(allyUnits[i].transform.position.x, allyUnits[i].transform.position.y, allyUnits[i].transform.position.z + -2f );
                    enemyUnits[i].transform.position = new Vector3(enemyUnits[i].transform.position.x, enemyUnits[i].transform.position.y, enemyUnits[i].transform.position.z + 2f );
                }
            }
        }
    }
    public bool near(GameObject allyUnit, GameObject enemyUnit)
    {
        if ((Math.Abs(allyUnit.transform.position.z - enemyUnit.transform.position.z) < 0.5) && (allyUnit.transform.position.x == enemyUnit.transform.position.x))
        {
            return true;
        } else
        {
            return false;
        }
    }
    //IEnumerator pushing(GameObject unitToPush, bool front)
    //{
    //    float i = 0f;
    //    while (i < 1f)
    //    {
    //        i += 0.5f;
    //        unitToPush.transform.position = new Vector3(unitToPush.transform.position.x, unitToPush.transform.position.y, unitToPush.transform.position.z + -3 * Time.deltaTime);
    //        yield return new WaitForSeconds(0.1f);
    //    }
        
    //}
}
