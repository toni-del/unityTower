using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    public GameObject allUnits;
    public GameObject allyTowerL, allyTowerR, enemyTowerL, enemyTowerR;
    public GameObject allyHpText, enemyHpText;
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
                        unit.GetComponent<Stats>().frames-= Time.deltaTime;
                    } else
                    {
                        unit.GetComponent <Stats>().pushing = false;
                    }
                }
                    if (unit.transform.position.z > 9)
                {
                    enemyHP-= unit.GetComponent<Stats>().damage;
                    enemyHpText.GetComponent<Text>().text = Convert.ToString(enemyHP);
                    Destroy(unit);
                    if (enemyHP <= 0)
                    {
                        SceneManager.LoadScene(4);
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
                        unit.GetComponent<Stats>().frames-= Time.deltaTime;
                    }
                    else
                    {
                        unit.GetComponent<Stats>().pushing = false;
                    }
                }
                if (unit.transform.position.z < -9)
                {
                    allyHP -= unit.GetComponent<Stats>().damage;
                    allyHpText.GetComponent<Text>().text = Convert.ToString(allyHP);
                    Destroy(unit);
                    if (allyHP <= 0)
                    {
                        SceneManager.LoadScene(3);
                    }
                }
            }
        }
         
    }
}