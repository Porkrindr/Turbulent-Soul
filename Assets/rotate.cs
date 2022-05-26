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
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isRotating)
        {
            rot += (rotInput);
            transform.rotation = Quaternion.Euler(rot);
        }
    }
}
