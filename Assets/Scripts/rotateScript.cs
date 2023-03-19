using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateScript : MonoBehaviour
{
    public InputActionProperty RotateTelescope;
    public InputActionProperty SpeedUp;

    [SerializeField] float speed;
    [SerializeField] float speedMultiplier;
    float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 rotate = RotateTelescope.action.ReadValue<Vector2>();
        float clicked = SpeedUp.action.ReadValue<float>();

        if(clicked > 0.1f)
        {
            currentSpeed += speedMultiplier;
        }
        else
        {
            currentSpeed = speed;
        }
        Debug.Log(clicked);

        transform.RotateAround(transform.parent.position, new Vector3(rotate.y, rotate.x, 0), currentSpeed * Time.deltaTime);
    }
}
