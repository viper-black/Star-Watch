using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScript : MonoBehaviour
{
    int points;
    void Update()
    {

    }

    public void addPoints(int pointsToAdd)
    {
        if(pointsToAdd > 0)
        {
            points += pointsToAdd;
            Debug.Log(points);
        }
    }
}
