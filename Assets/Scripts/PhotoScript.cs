using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotoScript : MonoBehaviour
{
    [SerializeField] GameObject tempCamPos;
    Camera cam;
    Plane[] cameraFrustum;
    Collider Dacollider;

    PointScript ps;
    [SerializeField] int PointWorth;
    int pointsToAdd;

    public bool farPictureTaken = false;
    public bool MediumPictureTaken = false;
    public bool closePictureTaken = false;
    int pictureTakenPenalty;
    [SerializeField]float farHeight = 40;
    [SerializeField] float mediumHeight;
    [SerializeField] float closeHeight;

    [SerializeField] List<GameObject> POIS;
    
    // Start is called before the first frame update
    void Start()
    {
        ps = FindObjectOfType<PointScript>().GetComponent<PointScript>();
        Dacollider = GetComponent<Collider>();
        pictureTakenPenalty = PointWorth / 3 * 2;
    }
    public void TakePicture()
    {
        getRefrenceToCamera();
        var bounds = Dacollider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
            processPoints();
            ScanForPOI();
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
    public void ScanForPOI()
    {
        for(int i = 0; i < POIS.Count; i++)
        {
            Physics.Raycast(cam.transform.position,POIS[i].transform.position - cam.transform.position, out var hit, Mathf.Infinity);
            if(hit.collider.gameObject.tag == "POI")
            {
                ps.addPoints(POIS[i].GetComponent<POIScript>().pointsToAdd);
            }
        }
    }
    public void getRefrenceToCamera()
    {
        cam = FindObjectOfType<ZoomScript>().GetComponent<Camera>();
    }
}
