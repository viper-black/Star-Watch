using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ZoomScript : MonoBehaviour
{
    public InputActionProperty lensZoomUpKey;
    public InputActionProperty lensZoomDownKey;

    Camera cam;

    [SerializeField] float ZoomSens = 0.05f;

    [SerializeField] float minZoom;
    [SerializeField] float maxZoom;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        cam.fieldOfView = minZoom;
    }

    // Update is called once per frame
    void Update()
    {
        float buttonAPressed = lensZoomDownKey.action.ReadValue<float>();
        float buttonBPressed = lensZoomUpKey.action.ReadValue<float>();

        if(cam.fieldOfView < maxZoom)
        {
            cam.fieldOfView = maxZoom;
        }
        else if (cam.fieldOfView > minZoom)
        {
            cam.fieldOfView = minZoom;
        }
        else if(buttonAPressed > 0.1)
        {
            cam.fieldOfView += ZoomSens;
        }
        else if (buttonBPressed > 0.1)
        {
            cam.fieldOfView -= ZoomSens;
        }

    }
}
