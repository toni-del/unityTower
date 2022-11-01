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
            Debug.Log(manaCount);
            if (manaCount != 10)
                manaCount++;
            yield return new WaitForSeconds(2);
        }
    }
    IEnumerator spawn()
    {
        while (true)
        {
            if (UnityEngine.Random.Range(1, 11) <= manaCount)
            {

                string[] unitNames = new string[4];
                unitNames[0] = "First Card";
                unitNames[1] = "Second Card";
                unitNames[2] = "Third Card";
                unitNames[3] = "Fourth Card";
                chosenUnit = unitNames[UnityEngine.Random.Range(0, 4)];
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
            case "First Card":
                Debug.LogWarning("fasf");
                modifUn.GetComponent<MeshRenderer>().material = materials[0];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 2;
                break;
            case "Second Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[1];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 2;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
            case "Third Card":
                Debug.LogWarning("sdag");
                modifUn.GetComponent<MeshRenderer>().material = materials[2];
                modifUn.GetComponent<Stats>().damage = 2;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 1f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
            case "Fourth Card":
                modifUn.GetComponent<MeshRenderer>().material = materials[3];
                modifUn.GetComponent<Stats>().damage = 1;
                modifUn.GetComponent<Stats>().hp = 1;
                modifUn.GetComponent<Stats>().speed = 2f;
                modifUn.GetComponent<Stats>().cost = 3;
                break;
        }
        return modifUn;
    }
}
