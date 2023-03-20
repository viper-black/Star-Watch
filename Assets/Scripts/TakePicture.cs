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
        float trigger = takePhoto.action.ReadValue<float>();
        if(trigger > 0.5f && delayOver == true)
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
