using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab) && menuOpen == false)
        {
            menuOpen = true;
            menu.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Tab) && menuOpen == true)
        {
            menuOpen = false;
            menu.SetActive(false);
        }
    }
}
