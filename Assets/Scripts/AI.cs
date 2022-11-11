using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{
    int manaCount = 5;
    string chosenUnit;
    public GameObject unitToSpawn;
    public GameObject allUnits;
    public Material[] materials = new Material[4];
    private void Start()
    {
        var couratine = StartCoroutine(ChangeMana());
        var secondCouratine = StartCoroutine(spawn());
    }
    IEnumerator ChangeMana()
    {
        while (true)
        {
            
            if (manaCount != 10)
                manaCount++;
            yield return new WaitForSeconds(3);
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            if (UnityEngine.Random.Range(1, 11) <= manaCount)
            {

                string[] unitNames = new string[7];
                unitNames[0] = "water";
                unitNames[1] = "earth";
                unitNames[2] = "fire";
                unitNames[3] = "wind";
                unitNames[4] = "swamp";
                unitNames[5] = "steam";
                unitNames[6] = "lava";
                chosenUnit = unitNames[UnityEngine.Random.Range(0, 7)];
                if (UnityEngine.Random.Range(0, 2) == 1) SpawnUnitLeft();
                else SpawnUnitRight();
            }
            yield return new WaitForSeconds(1);
        }
    }
    public void SpawnUnitLeft()
    {
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(-5, 1, 9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit.tag = "Enemy";
        newUnit = modifiedUnit(newUnit);
        if (newUnit.GetComponent<Stats>().cost <= manaCount)
        {
            manaCount -= newUnit.GetComponent<Stats>().cost;
            newUnit.SetActive(true);
        }
        else
        {
            Destroy(newUnit);
        }
    }
    public void SpawnUnitRight()
    {
        GameObject newUnit = Instantiate(unitToSpawn, new Vector3(5, 1, 9), Quaternion.identity);
        newUnit.transform.SetParent(allUnits.transform);
        newUnit = modifiedUnit(newUnit);
        newUnit.tag = "Enemy";
        if (newUnit.GetComponent<Stats>().cost <= manaCount)
        {
            manaCount -= newUnit.GetComponent<Stats>().cost;
            newUnit.SetActive(true);
        }
        else
        {
            Destroy(newUnit);
        }
    }
    public GameObject modifiedUnit(GameObject modifUn)
    {
        switch (chosenUnit)
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
                modifUn.GetComponent<Stats>().ability = "swamp";
                break;
            case "steam":
                modifUn.GetComponent<MeshRenderer>().material = materials[5];
                modifUn.GetComponent<Stats>().damage = 2;
                modifUn.GetComponent<Stats>().hp = 2;
                modifUn.GetComponent<Stats>().speed = 3f;
                modifUn.GetComponent<Stats>().cost = 5;
                modifUn.GetComponent<Stats>().skip = 40;
                break;
            case "lava":
                modifUn.GetComponent<MeshRenderer>().material = materials[6];
                modifUn.GetComponent<Stats>().damage = 3;
                modifUn.GetComponent<Stats>().hp = 3;
                modifUn.GetComponent<Stats>().speed = 2f;
                modifUn.GetComponent<Stats>().cost = 6;
                modifUn.GetComponent<Stats>().ability = "lava";
                break;
        }
        return modifUn;
    }
}
