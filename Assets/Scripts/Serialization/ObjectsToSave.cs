using System.Xml;
using System.Text;
using System.Collections;
using System.Xml.Serialization;
using System.Collections.Generic;
using UnityEngine;


public class ObjectsToSave
{
    [XmlAttribute("v3")]
    public float[] vector3;

    [XmlAttribute("quat")]
    public float[] quaternion;

    [XmlAttribute("scale")]
    public float[] scale;

    [XmlAttribute("color")]
    public float[] color;

    [XmlAttribute("mesh")]
    public byte[] mesh;

    [XmlAttribute("ObjRef")]
    public string ObjRef;

    [XmlAttribute("Frozen")]
    public bool isFrozen;



    public ObjectsToSave()
    { 
    }

    public ObjectsToSave(GameObject gameObject)
    {
        if (gameObject != null)
        { 
            quaternion = new float[4];
            quaternion[0] = gameObject.transform.rotation[0];
            quaternion[1] = gameObject.transform.rotation[1];
            quaternion[2] = gameObject.transform.rotation[2];
            quaternion[3] = gameObject.transform.rotation[3];

            vector3 = new float[3];
            vector3[0] = gameObject.transform.position[0];
            vector3[1] = gameObject.transform.position[1];
            vector3[2] = gameObject.transform.position[2];

            scale = new float[3];
            scale[0] = gameObject.transform.localScale.x;
            scale[1] = gameObject.transform.localScale.y;
            scale[2] = gameObject.transform.localScale.z;

            color = new float[3];
            color[0] = gameObject.GetComponent<Renderer>().material.color.r;
            color[1] = gameObject.GetComponent<Renderer>().material.color.g;
            color[2] = gameObject.GetComponent<Renderer>().material.color.b;

            if (gameObject.GetComponent<Rigidbody>().useGravity == false)
            {
                isFrozen = true;
            }

            MeshFilter TempMesh = (MeshFilter)gameObject.GetComponent("MeshFilter");

            if (TempMesh != null)
            {
                bool unChanged = false;
                if (FurnitureInfo.spawnableNames.Contains(gameObject.name))
                {
                    ObjRef = gameObject.name;
                    unChanged = true;
                }
                if (unChanged == false)
                {
                    mesh = MeshSerializerSurrogate.WriteMesh(TempMesh.mesh, true);
                }
            }
        }
    }
}
