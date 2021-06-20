using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMesh : MonoBehaviour
{
    public void Combine(List<GameObject> gameObjects)
    {
            gameObjects[1].transform.SetParent(gameObjects[0].transform);
            Quaternion oldRot = gameObjects[0].transform.rotation;
            Vector3 oldPos = gameObjects[0].transform.position;

            gameObjects[0].transform.rotation = Quaternion.identity;
            gameObjects[0].transform.position = Vector3.zero;

            MeshFilter[] filters = gameObjects[0].GetComponentsInChildren<MeshFilter>();

            Debug.Log(gameObjects[0].name);

            Mesh finalMesh = new Mesh();

            CombineInstance[] combiner = new CombineInstance[filters.Length];

            for (int a = 0; a < filters.Length; a++)
            {
                combiner[a].subMeshIndex = 0;
                combiner[a].mesh = filters[a].sharedMesh;
                combiner[a].transform = filters[a].transform.localToWorldMatrix;
            }

            finalMesh.CombineMeshes(combiner);

            gameObjects[0].transform.GetComponent<MeshFilter>().sharedMesh = finalMesh;

            gameObjects[0].transform.rotation = oldRot;
            gameObjects[0].transform.position = oldPos;

            FurnitureInfo.Obj.Remove(gameObjects[1]);
            Destroy(gameObjects[1]);
            Destroy(gameObjects[0].GetComponent<MeshCollider>());
            gameObjects[0].AddComponent<MeshCollider>().convex = true;
            gameObjects[0].name = "Edited";
            FurnitureInfo.Selected.GetComponent<ObjInfo>().NotColliding();
        
    }
}
