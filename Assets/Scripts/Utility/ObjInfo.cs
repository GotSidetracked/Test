using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjInfo : MonoBehaviour
{
    
    bool IsSelected;
    bool IsColliding;

    void Start()
    {
        IsSelected = false;
        IsColliding = false;
    }

    public void NotColliding()
    {
        IsColliding = false;
    }

    public bool GetIsColliding()
    {
        return IsColliding;
    }
    public void SetSelect()
    {
        if (IsSelected != null)
        {
            IsSelected = true;
        }
        else
            IsSelected = false;
    }

    public void UnSelect()
    {
        if (IsSelected != null)
        {
            IsSelected = false;
        }
        else
            IsSelected = false;
    }

    void OnCollisionExit(Collision other)
    {
        IsColliding = false;
    }
    
    void OnCollisionStay(Collision collisionInfo)
    {
        if (IsSelected == true)
        {
            IsColliding = true;
            //Debug.Log("You can press q");
            if (Input.GetKey(KeyCode.Q))
            {
                CombineMesh combineMesh = new CombineMesh();
                List<GameObject> temp = new List<GameObject>();
                temp.Add(gameObject);
                temp.Add(collisionInfo.gameObject);
                combineMesh.Combine(temp);
            }
        }
    }
}
