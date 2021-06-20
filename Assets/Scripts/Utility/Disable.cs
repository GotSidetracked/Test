using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disable : MonoBehaviour
{
    public void Appear()
    {
        gameObject.SetActive(true);
    }

    public void Dissapear()
    {
        gameObject.SetActive(false);
    }
}
