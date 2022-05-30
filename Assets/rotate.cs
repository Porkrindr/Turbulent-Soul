using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public bool isRotating;
    public Vector3 rotInput;
    private Vector3 rot;
    // Start is called before the first frame update
    void Start()
    {
        if (isRotating)
        {
            rot = transform.eulerAngles;
        }
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
            if (isRotating)
            {
                rot += (rotInput);
                transform.rotation = Quaternion.Euler(rot);
            }
        }
    }
}
