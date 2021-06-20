using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureInfo : MonoBehaviour
{
    static public GameObject Selected;
    static public GameObject SpawnItem;
    static public List<GameObject> Obj;
    static public List<GameObject> allSpawnables { get; private set; }
    static public List<string> spawnableNames { get; private set; }
    static int currObj;


    void Start()
    {
        allSpawnables = new List<GameObject>();
        Obj = new List<GameObject>();
        spawnableNames = new List<string>();
        Object[] allItems = Resources.LoadAll("Furniture");
        if (allItems != null)
        {
            foreach (object item in allItems)
            {
                GameObject temp = (GameObject)item;
                allSpawnables.Add(temp);
                spawnableNames.Add(temp.name);
            }
            SpawnItem = (GameObject)allItems[0];
            currObj = 0;
        }
    }

    static public void addObject()
    {
        Obj.Add(Selected);
    }

    static public void addObject(GameObject obj)
    {
        Obj.Add(obj);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            currObj -= 1;
            if (currObj < 0)
            {
                currObj = allSpawnables.Count - 1;
            }
            SpawnItem = allSpawnables[currObj];
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            currObj += 1;
            if (currObj == allSpawnables.Count)
            {
                currObj = 0;
            }
            SpawnItem = allSpawnables[currObj];
        }

    }
}
