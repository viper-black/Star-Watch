using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotoScript : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustum;
    Collider collider;

    PointScript ps;
    [SerializeField] int PointWorth;
    int pointsToAdd;

    public bool farPictureTaken = false;
    public bool MediumPictureTaken = false;
    public bool closePictureTaken = false;
    int pictureTakenPenalty;
    float farHeight = 40;
    [SerializeField] float mediumHeight;
    [SerializeField] float closeHeight;
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PointScript>().GetComponent<PointScript>();
        cam = FindObjectOfType<ZoomScript>().GetComponent<Camera>();
        collider = GetComponent<Collider>();
        pictureTakenPenalty = PointWorth / 3 * 2;
    }
    public void TakePicture()
    {
        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
            processPoints();
            }
    }
    void processPoints()
    {
        pointsToAdd = PointWorth - Mathf.RoundToInt(cam.fieldOfView);
        if (cam.fieldOfView <= farHeight && cam.fieldOfView > mediumHeight)
        {
            if(farPictureTaken == true)
            {
                ps.addPoints(pointsToAdd - pictureTakenPenalty);
            }
            else
            {
                ps.addPoints(pointsToAdd);
                farPictureTaken = true;
            }
        }
        else if (cam.fieldOfView <= mediumHeight && cam.fieldOfView > closeHeight)
        {
            if (MediumPictureTaken == true)
            {
                ps.addPoints(pointsToAdd - pictureTakenPenalty);
            }
            else
            {
                ps.addPoints(pointsToAdd);
                MediumPictureTaken = true;
            }
        }
        else if (cam.fieldOfView <= closeHeight)
        {
            if (closePictureTaken == true)
            {
                ps.addPoints(pointsToAdd - pictureTakenPenalty);
            }
            else
            {
                ps.addPoints(pointsToAdd);
                closePictureTaken = true;
            }
        }
    }
}
