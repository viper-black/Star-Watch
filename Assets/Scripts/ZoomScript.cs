using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class ZoomScript : MonoBehaviour
{
    public InputActionProperty lensMoveUpKey;
    public InputActionProperty lensMoveDownKey;
    public InputActionProperty lensZoomUpKey;
    public InputActionProperty lensZoomDownKey;

    Camera cam;

    [SerializeField] float ZoomSens = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float buttonAPressed = lensZoomDownKey.action.ReadValue<float>();
        float buttonBPressed = lensZoomUpKey.action.ReadValue<float>();


        if(buttonBPressed > 0.1f)
        {
            cam.fieldOfView = cam.fieldOfView - ZoomSens;
        }
        else if (buttonAPressed > 0.1f)
        {
            cam.fieldOfView = cam.fieldOfView + ZoomSens;
        }
    }
}
