using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeTransparent : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseMenu.GameIsPaused)
        {
            return;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.clear);
        }
    }
}
