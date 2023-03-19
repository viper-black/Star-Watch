using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PhotoScript : MonoBehaviour
{
    Camera cam;
    Plane[] cameraFrustum;
    Collider collider;

    [SerializeField] PointScript ps;
    [SerializeField] int PointWorth;

    [SerializeField] float delayTime = 10f;
    bool delayOver = true;

    public InputActionProperty takePhoto;
    // Start is called before the first frame update
    void Start()
    {
        cam = FindObjectOfType<ZoomScript>().GetComponent<Camera>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        TakePicture();
    }
    void TakePicture()
    {
        float trigger = takePhoto.action.ReadValue<float>();

        var bounds = collider.bounds;
        cameraFrustum = GeometryUtility.CalculateFrustumPlanes(cam);
        if (trigger > 0.5f && delayOver == true)
        {
            delayOver = false;
            Invoke("Delay", delayTime);
            if (GeometryUtility.TestPlanesAABB(cameraFrustum, bounds))
            {
                int pointsToAdd = PointWorth - Mathf.RoundToInt(cam.fieldOfView);
                GetComponent<MeshRenderer>().material.color = Color.green;
                if (pointsToAdd > 0)
                {
                    ps.addPoints(pointsToAdd);
                }
            }
            else
            {
                GetComponent<MeshRenderer>().material.color = Color.red;
            }
        }
    }
    void Delay()
    {
        delayOver = true;
    }
}
