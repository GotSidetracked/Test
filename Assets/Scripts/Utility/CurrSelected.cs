using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CurrSelected : MonoBehaviour
{
    TextMeshProUGUI text = new TextMeshProUGUI();
    GameObject lastOne;
    // Start is called before the first frame update
    void Start()
    {
        text = gameObject.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastOne != FurnitureInfo.SpawnItem && FurnitureInfo.SpawnItem != null)
        {
            lastOne = FurnitureInfo.SpawnItem;
            text.text = "Selected - " + lastOne.name;
        }
    }
}
