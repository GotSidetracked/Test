using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml;
using System.Xml.Serialization;

using UnityEngine;

public class SerializationManager : MonoBehaviour
{
    string saveName = "RSave";

    public void test()
    {
        SaveList();
    }

    public void Load()
    {
        SaveData temp = new SaveData();
        temp.Load();
    }

    public bool SaveList()
    {
        SaveData temp = new SaveData();
        temp.Save();
        return true;
    }
}
