using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class rotateScript : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] float speedMultiplier = 10;
    float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        currentSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftControl))
        {
            currentSpeed = speed * speedMultiplier;
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            currentSpeed = speed;
        }
        if(Input.GetKey(KeyCode.I))
        {
            transform.eulerAngles += new Vector3(0, 0, currentSpeed);
        }
        if (Input.GetKey(KeyCode.K))
        {
            transform.eulerAngles += new Vector3(0, 0, -currentSpeed);
        }
        if (Input.GetKey(KeyCode.J))
        {
            transform.eulerAngles += new Vector3(0, currentSpeed, 0);
        }
        if (Input.GetKey(KeyCode.L))
        {
            transform.eulerAngles += new Vector3(0, -currentSpeed, 0);
        }
    }
}
