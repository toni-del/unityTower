using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject allUnits;
    public GameObject arrowLeft, arrowRight;
    public GameObject chosenCard;
    public GameObject mana;
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
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(-5, 1, -9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit = modifiedUnit(newUnit);
        if (newUnit.GetComponent<Stats>().cost <= Convert.ToInt32(mana.GetComponent<Text>().text))
        {
            mana.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(mana.GetComponent<Text>().text) - newUnit.GetComponent<Stats>().cost);
            newUnit.SetActive(true);
            changeModeF();
        } else
        {
            Destroy(newUnit);
        }
    }
    public void SpawnUnitRight()
    {
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(5, 1, -9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit = modifiedUnit(newUnit);
        if (newUnit.GetComponent<Stats>().cost <= Convert.ToInt32(mana.GetComponent<Text>().text))
        {
            mana.GetComponent<Text>().text = Convert.ToString(Convert.ToInt32(mana.GetComponent<Text>().text) - newUnit.GetComponent<Stats>().cost);
            newUnit.SetActive(true);
            changeModeF();
        } else
        {
            Destroy (newUnit);
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
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 1;
                break;
            case "Second Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[1];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 2;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 2;
                break;
            case "Third Card":
                Debug.LogWarning("sdag");
                modifUn.GetComponent<MeshRenderer>().material = materials[2];
                modifUn.GetComponent<Stats>().damage = 2;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 2;
                break;
            case "Fourth Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[3];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 2f;
                modifUn.GetComponent<Stats>().cost = 2;
                break;
        }
        return modifUn;
    }
}
