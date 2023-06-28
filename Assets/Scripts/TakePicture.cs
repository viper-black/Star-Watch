using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakePicture : MonoBehaviour
{
    PhotoScript[] PS;
    public InputActionProperty takePhoto;

    [SerializeField] float delayTime;
    bool delayOver = true;
    // Start is called before the first frame update
    void Start()
    {
        PS = FindObjectsOfType<PhotoScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            delayOver = false;
            for(int i = 0; i < PS.Length; i++)
            {
                PS[i].TakePicture();
            }
            Invoke("Delay", delayTime);
        }


    }
    void Delay()
    {
        delayOver = true;
    }

}
