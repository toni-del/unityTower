using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject allUnits;
    public GameObject allyTowerL, allyTowerR, enemyTowerL, enemyTowerR;
    public int totFram, allyHP, enemyHP;
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
                if (!unit.GetComponent<Stats>().pushing)
                unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z + unit.GetComponent<Stats>().speed * Time.deltaTime);
                else
                {
                    if (unit.GetComponent<Stats>().frames < totFram)
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * 1.5f * Time.deltaTime);
                        unit.GetComponent<Stats>().frames+= Time.deltaTime;
                    } else
                    {
                        unit.GetComponent <Stats>().pushing = false;
                    }
                }
                    if (unit.transform.position.z > 9)
                        if (unit.transform.position.x < 0)
                    {
                        enemyHP--;
                        if (enemyHP == 0)
                        {
                            //здесь выигрыш
                        }
                    }
                    if (unit.transform.position.z > 9)
                        if (unit.transform.position.x > 0)
                    {
                        enemyHP--;
                        if (enemyHP == 0)
                        {
                            //здесь выигрыш
                        }
                    }
                            

            } else
            {
                if (!unit.GetComponent<Stats>().pushing)
                    unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * Time.deltaTime);
                else
                {
                    if (unit.GetComponent<Stats>().frames < totFram)
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z + unit.GetComponent<Stats>().speed * 1.5f * Time.deltaTime);
                        unit.GetComponent<Stats>().frames+= Time.deltaTime;
                    }
                    else
                    {
                        unit.GetComponent<Stats>().pushing = false;
                    }
                }
                if (unit.transform.position.z < -9)
                    if (unit.transform.position.x < 0)
                    {
                            allyHP--;
                            if (allyHP == 0)
                            {
                                //здесь проигрыш
                            }
                    }
                if (unit.transform.position.z < -9)
                    if (unit.transform.position.x > 0)
                    {
                        allyHP--;
                        if (allyHP == 0)
                        {
                            //здесь проигрыш
                        }
                    }
            }
        }
         
    }
}