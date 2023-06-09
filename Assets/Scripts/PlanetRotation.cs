using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    [SerializeField] Vector3 angle;
    [SerializeField] float speed;
    [SerializeField] float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(new Vector3(0, 0, 0), angle, speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotateSpeed * Time.deltaTime));
    }
}
