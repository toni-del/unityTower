using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public GameObject allUnits;
    public GameObject allyTowerL, allyTowerR, enemyTowerL, enemyTowerR;
    public int totFram;
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
                    if (unit.GetComponent<Stats>().frames != totFram)
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * 1.5f * Time.deltaTime);
                        unit.GetComponent<Stats>().frames++;
                    } else
                    {
                        unit.GetComponent <Stats>().pushing = false;
                    }
                }
                    if (unit.transform.position.z > 9)
                        if (unit.transform.position.x < 0)
                            if (enemyTowerL.tag != "Broken")
                        {
                            enemyTowerL.tag = "Broken";
                            Destroy(unit);
                        }
                                
                            else
                            {
                                Destroy(enemyTowerL);
                                Destroy(unit);
                            }
                    if (unit.transform.position.z > 9)
                        if (unit.transform.position.x > 0)
                            if (enemyTowerR.tag != "Broken")
                        {
                            enemyTowerR.tag = "Broken";
                            Destroy(unit);
                        }
                                
                            else
                            {
                                Destroy(enemyTowerR);
                                Destroy(unit);
                            }

            } else
            {
                if (!unit.GetComponent<Stats>().pushing)
                    unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z - unit.GetComponent<Stats>().speed * Time.deltaTime);
                else
                {
                    if (unit.GetComponent<Stats>().frames != totFram)
                    {
                        unit.transform.position = new Vector3(unit.transform.position.x, unit.transform.position.y, unit.transform.position.z + unit.GetComponent<Stats>().speed * 1.5f * Time.deltaTime);
                        unit.GetComponent<Stats>().frames++;
                    }
                    else
                    {
                        unit.GetComponent<Stats>().pushing = false;
                    }
                }
                if (unit.transform.position.z < -9)
                    if (unit.transform.position.x < 0)
                        if (allyTowerL.tag != "Broken")
                        {
                            allyTowerL.tag = "Broken";
                            Destroy(unit);
                        }
                            
                        else
                        {
                            Destroy(allyTowerL);
                            Destroy(unit);
                        }
                if (unit.transform.position.z < -9)
                    if (unit.transform.position.x > 0)
                        if (allyTowerR.tag != "Broken")
                        {
                            allyTowerR.tag = "Broken";
                            Destroy(unit);
                        }
                            
                        else
                        {
                            Destroy(allyTowerR);
                            Destroy(unit);
                        }
            }
        }
         
    }
}