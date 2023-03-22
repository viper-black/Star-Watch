using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class POIScript : MonoBehaviour
{
    public int pointsToAdd;
    public bool pictureTaken = false;
    private void Update()
    {
        if(pictureTaken == true)
        {
            pointsToAdd = 0;
        }
    }
}
