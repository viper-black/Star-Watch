using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelescopeHeight : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Y))
        {
            transform.Translate(0, 1 * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.H))
        {
            transform.Translate(0, -1 * Time.deltaTime, 0);
        }
    }
}
