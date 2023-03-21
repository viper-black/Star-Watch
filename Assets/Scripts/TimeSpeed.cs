using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TimeSpeed : MonoBehaviour
{
    public InputActionProperty TimeUp;
    public InputActionProperty TimeDown;


    [SerializeField] float addTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float Ybutton = TimeUp.action.ReadValue<float>();
        float Xbutton = TimeDown.action.ReadValue<float>();

        if(Ybutton > 0.1f && Time.timeScale <= 90)
        {
            Time.timeScale += addTime;
        }
        else if (Xbutton > 0.1f)
        {
            Time.timeScale = 1;
            Debug.Log("we Good");
        }
    }
}
