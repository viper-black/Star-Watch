using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotoScript : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustum;
    Collider collider;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<ZoomScript>().GetComponent<Camera>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if(GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
        {
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.red;
        }
    }
}
