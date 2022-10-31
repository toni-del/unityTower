using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject allUnits;
    public GameObject arrowLeft, arrowRight;
    public GameObject chosenCard;
    public Material[] materials = new Material[4];

    public void changeModeT()
    {
        Debug.Log(chosenCard.name);
        arrowLeft.GetComponent<UnitSpawner>().chosenCard = chosenCard;
        arrowLeft.SetActive(true);
        arrowRight.GetComponent<UnitSpawner>().chosenCard = chosenCard;
        arrowRight.SetActive(true);
    }
    public void SpawnUnitLeft()
    {
        if (Mana.timeStart >= 3)
        {
            GameObject newUnit = Instantiate(unitToSpawn, new Vector3(-5, 1, -9), Quaternion.identity);
            newUnit.transform.SetParent(allUnits.transform);
            newUnit = modifiedUnit(newUnit);
            newUnit.SetActive(true);
            changeModeF();
            Mana.timeStart -= 3;
        }
    }
    public void SpawnUnitRight()
    {
        if (Mana.timeStart >= 3)
        {
            GameObject newUnit = Instantiate(unitToSpawn, new Vector3(5, 1, -9), Quaternion.identity);
            newUnit.transform.SetParent(allUnits.transform);
            newUnit = modifiedUnit(newUnit);
            newUnit.SetActive(true);
            changeModeF();
            Mana.timeStart -= 3;
        }
    }
    public void changeModeF()
    {
        arrowLeft.SetActive(false);
        arrowRight.SetActive(false);
    }
    public GameObject modifiedUnit(GameObject modifUn)
    {
        switch (chosenCard.name)
        {
            case "First Card":
                Debug.LogWarning("fasf");
                modifUn.GetComponent<MeshRenderer>().material = materials[0];
                break;
            case "Second Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[1];
                break;
            case "Third Card":
                Debug.LogWarning("sdag");
                modifUn.GetComponent<MeshRenderer>().material = materials[2];
                break;
            case "Fourth Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[3];
                break;
        }
        return modifUn;
    }
}
