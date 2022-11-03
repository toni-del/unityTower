using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class UnitSpawner : MonoBehaviour
{
    public GameObject unitToSpawn;
    public GameObject allUnits;
    public GameObject arrowLeft, arrowRight, comb;
    public GameObject coomvinatedCard;
    public GameObject mana;
    public Material[] materials = new Material[5];
    public string element;
    public bool coombinationActive = false;

    public void changeModeT()
    {
        //if (!coombinationActive)
        //{
            arrowLeft.GetComponent<UnitSpawner>().element = element;
            arrowLeft.SetActive(true);
            arrowRight.GetComponent<UnitSpawner>().element = element;
            arrowRight.SetActive(true);
            comb.GetComponent<Coombination>().element = element;
            comb.SetActive(true);
        //}
        
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
        coomvinatedCard.SetActive(false);
    }
    public GameObject modifiedUnit(GameObject modifUn)
    {
        Debug.Log(element);
        switch (element)
        {
            case "water":
                modifUn.GetComponent<MeshRenderer>().material = materials[0];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 2;
                break;
            case "earth":
                modifUn.GetComponent<MeshRenderer>().material = materials[1];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 2;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
            case "fire":
                Debug.LogWarning("sdag");
                modifUn.GetComponent<MeshRenderer>().material = materials[2];
                modifUn.GetComponent<Stats>().damage = 2;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
            case "wind":
                modifUn.GetComponent<MeshRenderer>().material = materials[3];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 2f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
            case "swamp":
                modifUn.GetComponent<MeshRenderer>().material = materials[4];
                modifUn.GetComponent<Stats>().damage = 2;
                modifUn.GetComponent<Stats>().hp = 3;
                modifUn.GetComponent<Stats>().speed = 2f;
                modifUn.GetComponent<Stats>().cost = 5;
                break;
        }
        return modifUn;
    }
}
