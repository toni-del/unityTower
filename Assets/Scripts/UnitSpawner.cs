using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject allUnits;
    public GameObject arrowLeft, arrowRight;
    public void SpawnUnitLeft()
    {
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(-5, 1, -9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit.SetActive(true);
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }
    public void SpawnUnitRight()
    {
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(5, 1, -9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit.SetActive(true);
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }
}
