using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Linq;

[XmlRoot("FurnitureCollection")]
public class SaveData
{
    [XmlArray("Furnitures")]
    [XmlArrayItem("ObjectsToSave")]
    public List<ObjectsToSave> objects = new List<ObjectsToSave>();

    public string path = Application.persistentDataPath + "/saves/RSave.save";

    public void Load()
    {
        if (File.Exists(path))
        {
            var serializer = new XmlSerializer(typeof(List<ObjectsToSave>));
            var stream = new FileStream(path, FileMode.Open);
            var container = serializer.Deserialize(stream) as List<ObjectsToSave>;
            stream.Close();
            if (FurnitureInfo.Obj != null)
            {
                foreach (GameObject itemToDelete in FurnitureInfo.Obj)
                {
                    UnityEngine.Object.Destroy(itemToDelete);
                }
            }
            foreach (ObjectsToSave a in container)
            {
                Debug.Log(a.vector3[0]);
                if (a.vector3[0] != null)
                {
                    GameObject tempObject;
                    if (a.ObjRef == null)
                    {
                        tempObject = new GameObject();
                        tempObject.AddComponent<MeshFilter>();
                        tempObject.GetComponent<MeshFilter>().mesh = MeshSerializerSurrogate.ReadMesh(a.mesh);
                        tempObject.name = "Loaded";
                        tempObject.tag = "Furniture";
                        tempObject.AddComponent<MeshRenderer>();
                        tempObject.GetComponent<MeshRenderer>().materials[0] = Resources.Load<Material>("Materials/Test");
                        tempObject.AddComponent<Rigidbody>();
                        tempObject.AddComponent<MeshCollider>().convex = true;
                        tempObject.AddComponent<ObjInfo>();
                    }
                    else
                    {
                        Debug.Log(Resources.Load<GameObject>("Furniture/" + a.ObjRef));
                        tempObject = UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Furniture/" + a.ObjRef));
                        tempObject.name = a.ObjRef;
                    }
                    tempObject.transform.position = new Vector3(a.vector3[0], a.vector3[1], a.vector3[2]);
                    tempObject.transform.rotation = new Quaternion(a.quaternion[0], a.quaternion[1], a.quaternion[2], a.quaternion[3]);
                    tempObject.transform.localScale = new Vector3(a.scale[0], a.scale[1], a.scale[2]);
                    tempObject.GetComponent<Renderer>().material.color = new Color(a.color[0], a.color[1], a.color[2], 1);
                    if (a.isFrozen == true)
                    {
                        tempObject.GetComponent<Collider>().isTrigger = true;
                        tempObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotationZ;
                        tempObject.GetComponent<Rigidbody>().useGravity = false;
                    }
                    FurnitureInfo.addObject(tempObject);
                    FurnitureInfo.Selected = tempObject;
                    Debug.Log(a.vector3[0] + " " + a.vector3[1] + " " + a.vector3[2]);
                }
            }
        }
        else
        {
            Debug.Log("Load a file into " + path);
        }
        objects.Clear();
    }


    public void Save()
    {
        if (objects == null)
        {
            objects = new List<ObjectsToSave>();
        }
        if (FurnitureInfo.Obj != null)
        {
            foreach (GameObject gObj in FurnitureInfo.Obj)
            {
                if (!objects.Contains(new ObjectsToSave(gObj)) && gObj != null)
                {
                    objects.Add(new ObjectsToSave(gObj));
                }
            }
        }
        else
        {
            Debug.Log("Nothing to save");
        }

        Stream str = File.Create(path);

        Debug.Log(objects.Count);
        XmlSerializer xmsler = new XmlSerializer(typeof(List<ObjectsToSave>));
        xmsler.Serialize(str, objects);

        str.Close();

    }
}
